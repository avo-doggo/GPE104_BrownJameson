using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class Healer : MonoBehaviour
{

    public float healAmount;

    public bool isFullHeal;

    private Health otherHealthComponent;

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

            rb.AddForce(-tf.up * force);
        }

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        otherHealthComponent = collision.GetComponent<Health>();
        if (otherHealthComponent != null)
        {       AudioSource.PlayClipAtPoint(
                GameManager.instance.healSound,
                transform.position,
                GameManager.instance.SFXVolume);
            if (isFullHeal)
            {
                otherHealthComponent.Heal(otherHealthComponent.maxHealth);
            }
            else
            {
  

                otherHealthComponent.Heal(healAmount);
            }
            Destroy(gameObject);
        }
    }
}
