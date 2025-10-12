
using UnityEngine;

public class Mover : MonoBehaviour
{
    
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    
    private float moverHorizontal;

   
    private Rigidbody2D miRigidbody2D;

    
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        
        miRigidbody2D.linearVelocity = new Vector2(moverHorizontal * velocidad, miRigidbody2D.linearVelocity.y);
    }
}