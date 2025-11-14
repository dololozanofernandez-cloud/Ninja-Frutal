using UnityEngine;

public class Pedazos : MonoBehaviour
{
    [SerializeField] int fuerza;

    private void Start()
    {
        foreach(Transform fragmento in transform)
        {
            Rigidbody2D rigidbody2D = fragmento.GetComponent<Rigidbody2D>();
            Vector2 aleatorio = Random.insideUnitCircle.normalized;
            rigidbody2D.AddForce(aleatorio * fuerza, ForceMode2D.Impulse);
            rigidbody2D.AddTorque(Random.Range(-3f, 3f));
        }

        Destroy(gameObject, 2f);
    }
}
