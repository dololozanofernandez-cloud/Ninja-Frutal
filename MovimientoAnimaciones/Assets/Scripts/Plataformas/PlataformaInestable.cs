using UnityEngine;

public class PlataformaInestable : MonoBehaviour
{

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    
   
}

