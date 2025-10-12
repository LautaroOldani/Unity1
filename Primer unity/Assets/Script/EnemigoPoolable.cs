using UnityEngine;

public class EnemigoPoolable : MonoBehaviour
{
 
    public void RetornoAlPool()
    {
        
        ObjectPooler.Instance.ReturnToPool("Enemigo", this.gameObject);
    }
}