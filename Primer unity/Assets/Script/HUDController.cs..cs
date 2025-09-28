using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    // Variables para la vida del jugador
    [Header("UI Vida")]
    public TextMeshProUGUI textoVida;

    // Variables para el sistema de progresión
    [Header("UI Progresión")]
    public Slider barraExp;
    public TextMeshProUGUI textoNivel;

    // Variables para los mensajes de victoria/derrota
    [Header("Mensajes de Juego")]
    public TextMeshProUGUI textoDerrota;
    public TextMeshProUGUI textoVictoria;

    // Este método se llama cuando el juego empieza.
    void Start()
    {
        // Esto inicializa el texto del nivel con el valor actual del jugador.
        if (ProgressionManager.Instance != null && ProgressionManager.Instance.playerData != null)
        {
            ActualizarNivel(ProgressionManager.Instance.playerData.currentLevel);
            ActualizarExp(ProgressionManager.Instance.playerData.currentExperience, ProgressionManager.Instance.playerData.expToNextLevel);
        }
    }

    public void ActualizarVida(float vida)
    {
        if (textoVida != null)
        {
            textoVida.text = "Vida: " + vida.ToString();
        }
    }

    public void ActualizarExp(float expActual, float expParaSiguienteNivel)
    {
        if (barraExp != null)
        {
            barraExp.maxValue = expParaSiguienteNivel;
            barraExp.value = expActual;
        }
    }

    public void ActualizarNivel(int nivel)
    {
        if (textoNivel != null)
        {
            textoNivel.text = "Nivel: " + nivel.ToString();
        }
    }

    public void MostrarMensajeDerrota()
    {
        if (textoDerrota != null)
        {
            textoDerrota.gameObject.SetActive(true);
        }
    }

    public void MostrarMensajeVictoria()
    {
        if (textoVictoria != null)
        {
            textoVictoria.gameObject.SetActive(true);
        }
    }
}