using Unity.VisualScripting;
using UnityEngine;

public class MovimientoCaja : MonoBehaviour
{
    [SerializeField] GameObject punto1;
    [SerializeField] GameObject punto2;
    GameObject puntoRef;
    [SerializeField] float velocidad;
    private void Start()
    {
        puntoRef = punto1;
    }
    private void Update()
    {
        if (Vector2.Distance(puntoRef.transform.position, transform.position) < 0.1f)
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


        transform.position = Vector2.MoveTowards(transform.position, puntoRef.transform.position, velocidad * Time.deltaTime);
    }

    
}
