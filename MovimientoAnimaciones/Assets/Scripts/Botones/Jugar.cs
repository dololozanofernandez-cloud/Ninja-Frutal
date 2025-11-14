using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
    public void Entrar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
