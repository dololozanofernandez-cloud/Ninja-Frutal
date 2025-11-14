using UnityEngine;

public class CajaDesaparece : MonoBehaviour
{
    public GameObject fragmentos;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(fragmentos,transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(audioSource.clip,new Vector3 (1, 1, 1));
            Destroy(gameObject);
        }
    }
}
