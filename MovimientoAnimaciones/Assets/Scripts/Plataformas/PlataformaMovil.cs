using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            //Le digo al objeto que colisiona que se asuma como padre el transform de la plataforma
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            //Le digo al objeto que colisiona que se asuma como padre el valor nulo cuando no se termina la colision
            collision.gameObject.transform.SetParent(null);
        }
    }
}
