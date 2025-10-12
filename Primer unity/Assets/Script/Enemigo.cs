using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Configuracion")]
   
    public float vidaMaxima = 30f;
    public float vida = 30f;
    public float experienciaADar = 10f;

   
    public void ResetearEnemigo()
    {
        vida = vidaMaxima; 
        
    }

    public void TomarDaño(float cantidad)
    {
        vida -= cantidad;
        Debug.Log("El enemigo tiene " + vida + " de vida restante.");

        if (vida <= 0)
        {
            DerrotarEnemigo();
        }
    }

    private void DerrotarEnemigo()
    {
        if (ProgressionManager.Instance != null)
        {
            ProgressionManager.Instance.AddExperience(experienciaADar);
        }

        
        ObjectPooler.Instance.ReturnToPool("Enemigo", this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            Vector2 normal = collision.contacts[0].normal;

            if (normal.y < 0)
            {
                TomarDaño(jugador.danioAlEnemigo);
                jugador.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            }
            else
            {
                jugador.ModificarVida(-10);
            }
        }
    }
}