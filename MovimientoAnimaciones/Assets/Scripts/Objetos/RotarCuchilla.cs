using UnityEngine;

public class RotarCuchilla : MonoBehaviour
{
    [SerializeField] int velocidadRotacion;
    
    void Update()
    {
        transform.Rotate(0,0, velocidadRotacion * Time.deltaTime);
    }
}
