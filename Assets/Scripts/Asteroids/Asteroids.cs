using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float force;

    private Rigidbody2D rb;

    private Transform tf;

    public float lifetime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tf = GetComponent<Transform>();

        if (rb != null && tf != null)
        {
            rb.AddForce(tf.up * -force);
        }

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
