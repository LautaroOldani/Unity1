using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 100f;

    [Header("HUD")]
    public TextMeshProUGUI vidaText;
    public GameObject textoDerrota;

    void Start()
    {
        if (textoDerrota != null)
        {
            textoDerrota.SetActive(false);
        }
        ActualizarHUD();
    }

    public void ModificarVida(float puntos)
    {
        vida += puntos;

        vida = Mathf.Clamp(vida, 0, 100);

        ActualizarHUD();

        if (vida <= 0)
        {
            Perdiste();
        }
    }

    private void ActualizarHUD()
    {
        if (vidaText != null)
        {
            vidaText.text = "Vida: " + vida.ToString();
        }
    }

    private void Perdiste()
    {
        Debug.Log("PERDISTE");

        if (textoDerrota != null)
        {
            textoDerrota.SetActive(true);
        }

        StartCoroutine(ReiniciarNivel());
    }

    IEnumerator ReiniciarNivel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}