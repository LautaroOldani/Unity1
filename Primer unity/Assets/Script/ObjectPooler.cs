using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    
    public static ObjectPooler Instance;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            poolDictionary = new Dictionary<string, Queue<GameObject>>();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    
    void Start()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    

    
    public GameObject GetPooledObject(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag) || poolDictionary[tag].Count == 0)
        {
            Debug.LogWarning("Pool con tag " + tag + " no existe o está vacío. Revisa Object Pooler.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        
        Enemigo enemigoScript = objectToSpawn.GetComponent<Enemigo>();
        if (enemigoScript != null)
        {
            enemigoScript.ResetearEnemigo();
        }

        
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    
    public void ReturnToPool(string tag, GameObject objectToReturn)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Intentando devolver objeto a un Pool que no existe: " + tag);
            return;
        }

        objectToReturn.SetActive(false);
        poolDictionary[tag].Enqueue(objectToReturn);
    }
}