using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Trampas : MonoBehaviour
{
    Animator animatorJugador;
    Animator animatorBola;
    Animator animatorFuego;
    Jugador movimientoJugador;
    [SerializeField]TextMeshProUGUI texto;
    int num;
    
    
    
    private void Start()
    {
        animatorJugador = GetComponent<Animator>();
        movimientoJugador = GetComponent<Jugador>();
        num = 0;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
      
            if(collision.gameObject.CompareTag("BolaPinchos"))
            {
                animatorBola = collision.gameObject.GetComponent<Animator>();
                AudioSource.PlayClipAtPoint(collision.GetComponent<AudioSource>().clip, collision.transform.position);
                animatorBola.Play("BolaPinchos");
                collision.gameObject.transform.localScale = new Vector2(1f, 1f);
                
                movimientoJugador.enabled = false;
                animatorJugador.Play("Desaparece");
                Invoke("ReiniciarEscena", 1f);
            }else if (collision.gameObject.CompareTag("Fuego"))
            {
                animatorFuego = collision.gameObject.GetComponent<Animator>();
                AudioSource.PlayClipAtPoint(collision.GetComponent<AudioSource>().clip,collision.transform.position);
                animatorFuego.Play("Encendido");

                collision.gameObject.transform.localScale = new Vector2(1f, 1f);

                movimientoJugador.enabled = false;
                animatorJugador.Play("Desaparece");
                Invoke("ReiniciarEscena", 1f);
            } else if (collision.gameObject.CompareTag("Trampa"))
        {

                AudioSource.PlayClipAtPoint(collision.GetComponent<AudioSource>().clip, collision.transform.position);
                collision.gameObject.transform.localScale = new Vector2(1f, 1f);
                //Desabilito
                movimientoJugador.enabled = false;
                animatorJugador.Play("Desaparece");
                Invoke("ReiniciarEscena", 1f);

            }
            

        
    }
    



        void ReiniciarEscena()

        {
        texto.text = num.ToString();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
}
