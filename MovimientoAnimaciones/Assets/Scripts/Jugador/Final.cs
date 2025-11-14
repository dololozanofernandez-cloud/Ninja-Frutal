using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            

            Invoke("Fin", 0.8f);
            

        }else if (collision.gameObject.CompareTag("SiguienteNivel"))
        {
            Invoke("SiguienteNivel", 0.8f);
        }
    }



    void Fin()
    {
        SceneManager.LoadScene("Fin");
    }

    void SiguienteNivel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
