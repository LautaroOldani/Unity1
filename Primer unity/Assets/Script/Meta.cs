using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
   
    public GameObject textoVictoria;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Meta alcanzada! ¡Ganaste!");

            
            if (textoVictoria != null)
            {
                textoVictoria.SetActive(true);
            }

            
            StartCoroutine(ReiniciarNivel());
        }
    }

    
    private IEnumerator ReiniciarNivel()
    {
       
        yield return new WaitForSeconds(2);

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}