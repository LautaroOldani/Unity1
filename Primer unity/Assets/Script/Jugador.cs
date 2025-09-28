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

    void Start()
    {
        
        OnVidaCambiada.Invoke(vida);
    }

    public void ModificarVida(float puntos)
    {
        vida += puntos;
        vida = Mathf.Clamp(vida, 0, 100);

        
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