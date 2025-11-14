using UnityEngine;

public class PlataformaMovilV2 : MonoBehaviour
{
    [SerializeField] GameObject punto1;
    [SerializeField] GameObject punto2;
    [SerializeField] float velocidad;
    GameObject puntoRef;
    Collider2D plataforma;
    private void Start()
    {
        puntoRef = punto1;
    }
    private void Update()
    {
        

        if(Vector2.Distance(puntoRef.transform.position, transform.position) < 0.1f)
        {
            if (puntoRef == punto1) 
            {
                puntoRef = punto2;
            }

            else 
            {
                puntoRef = punto1;
            } 
            
        }

        transform.position = Vector2.MoveTowards(transform.position,puntoRef.transform.position, velocidad * Time.deltaTime);

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Le digo al objeto que colisiona que se asuma como padre el transform de la plataforma
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Le digo al objeto que colisiona que se asuma como padre el valor nulo cuando no se termina la colision
            collision.gameObject.transform.SetParent(null);
        }
    }
}
