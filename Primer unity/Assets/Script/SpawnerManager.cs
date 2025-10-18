using System.Collections;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public string enemigoTag = "Enemigo";
    public Transform[] puntosDeGeneracion;

    void Start()
    {
        
        StartCoroutine(IniciarGeneracionConRetraso());
    }

    
    IEnumerator IniciarGeneracionConRetraso()
    {
        
        yield return new WaitForSeconds(1f);

        
        GenerarObjetosInstantaneos();
    }

    void GenerarObjetosInstantaneos()
    {
        if (ObjectPooler.Instance == null || puntosDeGeneracion.Length == 0)
        {
            Debug.LogError("ERROR: Configuración del Spawner incompleta.");
            return;
        }

        foreach (Transform punto in puntosDeGeneracion)
        {
            ObjectPooler.Instance.GetPooledObject(
                enemigoTag,
                punto.position,
                Quaternion.identity);
        }
    }
}