using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Jugador : MonoBehaviour
{

    InputAction movimiento;
    InputAction saltar;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;
    BoxCollider2D coll;
    Animator animator;

    [SerializeField] LayerMask suelo;

    [SerializeField]float velocidad;
    [SerializeField]float velocidadSalto;
    private bool dobleSalto;



    void Start()
    {

        
        rb2D = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        movimiento = InputSystem.actions.FindAction("Move");
        saltar = InputSystem.actions.FindAction("Jump");
       
        dobleSalto = false;

    }
    
    
    void Update()
    {
        Mover();
        Animar();

    }

    private void Animar()
    {
        Vector2 mover = movimiento.ReadValue<Vector2>();
        if(rb2D.linearVelocityY > 0 && dobleSalto == true)
        {
            animator.Play("Salto");
        }else if (rb2D.linearVelocityY > 0 && dobleSalto == false)
        {
            animator.Play("DobleSalto");
        }
        else if (rb2D.linearVelocityY < 0)
        {
            animator.Play("Caer");
        }
        else if (mover.x > 0)
        {
            animator.Play("Corriendo");
            spriteRenderer.flipX = false;
        }
        else if (mover.x < 0)
        {
            animator.Play("Corriendo");
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.Play("Parado");
        }


    }

    private void Mover()
    {
       
        Vector2 mover = movimiento.ReadValue<Vector2>();
        //Aqui verificamos la posicion y le añadimos velocidad
        rb2D.linearVelocityX = mover.x * velocidad;
        if (esSuelo())
        {
            dobleSalto = true;
        }

        if (saltar.WasPressedThisFrame())
        {
            if (esSuelo())
            {
               
                //Aqui se le da el valor una vez y luego se hace cargo la gravedad
                rb2D.linearVelocityY = velocidadSalto;
                dobleSalto = true;
                
            }
            else if (dobleSalto)
            {
                rb2D.linearVelocityY = velocidadSalto;
                dobleSalto = false;
            }
            

        }
        
    
    }

   


    public bool esSuelo()
    {    
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, suelo);
    }
}
