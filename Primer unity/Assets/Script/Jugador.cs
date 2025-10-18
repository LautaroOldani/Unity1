using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 100f;
    [SerializeField] public float danioAlEnemigo = 10f;
    public UnityEvent<float> OnVidaCambiada;
    public UnityEvent OnDerrota;


    [Header("Audio")]
   

    [Header("Efectos")]
    [SerializeField] private GameObject prefabParticulasDanio; 

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (anim == null || spriteRenderer == null)
        {
            Debug.LogError("El Jugador necesita componentes Animator y SpriteRenderer.");
        }
    }

    void Start()
    {
        OnVidaCambiada.Invoke(vida);
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");


        if (anim != null)
        {

            anim.SetFloat("Speed", Mathf.Abs(movimientoHorizontal));
        }


        if (spriteRenderer != null)
        {
            if (movimientoHorizontal > 0.01f)
            {
                spriteRenderer.flipX = true;
            }
            else if (movimientoHorizontal < -0.01f)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    public void ModificarVida(float puntos)
    {
        vida += puntos;
        vida = Mathf.Clamp(vida, 0, 100);


        if (puntos < 0 && anim != null)
        {
            anim.SetTrigger("Hit");


            if (prefabParticulasDanio != null)
            {
             
                Vector3 posicionParticulas = transform.position;
                posicionParticulas.z = -1f; 

                Instantiate(prefabParticulasDanio, posicionParticulas, Quaternion.identity);
                
            }
        }

        if (vida <= 0)
        {
            Perdiste();
        }

        OnVidaCambiada.Invoke(vida);
    }

    private void Perdiste()
    {
        Debug.Log("PERDISTE");
        OnDerrota.Invoke();
        StartCoroutine(ReiniciarNivel());
    }

    IEnumerator ReiniciarNivel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}