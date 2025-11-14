using TMPro;
using UnityEngine;


public class Colecccionables : MonoBehaviour
{
    int contador;
    [SerializeField]TextMeshProUGUI num;
    private void Start()
    {
        contador = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coleccionable"))
        {
            
            Vector3 vector3 = collision.transform.position;
            AudioSource.PlayClipAtPoint(collision.gameObject.GetComponent<AudioSource>().clip, vector3);


            contador++;
            collision.gameObject.SetActive(false);
            num.text = contador.ToString();

        }
        
    }

    


}
