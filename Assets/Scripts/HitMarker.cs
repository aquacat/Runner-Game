using UnityEngine;


public class HitMarker : MonoBehaviour
{

    private Rigidbody rb;
    private object other;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Dummie"))
        {
            other.gameObject.SetActive(false);
        }
		
		if (other.gameObject.CompareTag("Dummie2"))
        {
            other.gameObject.SetActive(false);
        }
		
		if (other.gameObject.CompareTag("Dummie3"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
