using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{

    [Header("Configuracion")]
    [SerializeField] private float fuerzaSalto = 5f;


    private bool puedoSaltar = true;
    private bool saltando = false;


    private Rigidbody2D miRigidbody2D;


    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            puedoSaltar = false;
        }
    }

    private void FixedUpdate()
    {
        if (!puedoSaltar && !saltando)
        {
           
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySound(AudioManager.Instance.saltoJugador);
            }

            
            Animator playerAnimator = GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetBool("IsJumping", true);
            }

            miRigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltando = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        puedoSaltar = true;
        saltando = false;

       
        if (collision.gameObject.CompareTag("Ground"))
        {
            Animator playerAnimator = GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetBool("IsJumping", false);
            }
        }
    }

}