using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Trampolin : MonoBehaviour
{
    
    [SerializeField] float velocidadSalto;
    Rigidbody2D rb2D;
    Animator animator;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        animator = collision.gameObject.GetComponent<Animator>();
        if (collision.gameObject.CompareTag("Trampolin"))
        {
            animator.Play("TrampolinActivo");
            rb2D.linearVelocityY = velocidadSalto;
          
        }
        

    }
    

}
