using UnityEngine;

public class Moneda : MonoBehaviour
{

    [SerializeField] private GameObject prefabParticulas;
    [SerializeField] private int valorPuntos = 1; 


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
           
            if (GameManager.instance != null)
            {
                GameManager.instance.SumarPuntos(valorPuntos);
            }
           

            if (prefabParticulas != null)
            {

                Instantiate(prefabParticulas, transform.position, Quaternion.identity);
            }


            Destroy(gameObject);
        }
    }
}