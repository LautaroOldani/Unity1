using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Configuracion")]
    public float vida = 30f;
    public float experienciaADar = 10f;

    public void TomarDa�o(float cantidad)
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
        // El enemigo notifica al ProgressionManager que el jugador gan� experiencia.
        if (ProgressionManager.Instance != null)
        {
            ProgressionManager.Instance.AddExperience(experienciaADar);
        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Revisa si el objeto que colision� es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtiene la referencia al script del jugador.
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();

            // Obtiene la direcci�n del impacto (el vector normal)
            Vector2 normal = collision.contacts[0].normal;

            // Si el jugador golpe� desde arriba (el normal.y es negativo)
            if (normal.y < 0)
            {
                // El enemigo toma da�o.
                TomarDa�o(jugador.danioAlEnemigo);
                jugador.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            }
            // Si el golpe vino de lado
            else
            {
                // El jugador choca con el enemigo y recibe da�o.
                jugador.ModificarVida(-10);
            }
        }
    }
}