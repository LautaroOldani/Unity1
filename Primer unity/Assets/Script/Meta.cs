using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events; 

public class meta : MonoBehaviour 
{
    

    public UnityEvent OnVictoria; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Meta alcanzada! ¡Ganaste!");

            
            OnVictoria.Invoke();

            StartCoroutine(ReiniciarNivel());
        }
    }

    private IEnumerator ReiniciarNivel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}