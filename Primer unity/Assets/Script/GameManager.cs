using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;


    public HUDController hudController;

    private int puntuacion = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

       
        if (hudController != null)
        {
            // Llama al método del HUD para inicializar el texto
            hudController.ActualizarTextoPuntuacion(puntuacion);
        }
    }

    
    public void SumarPuntos(int cantidad)
    {
        puntuacion += cantidad;

        
        if (hudController != null)
        {
            hudController.ActualizarTextoPuntuacion(puntuacion);
        }
    }
}