using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class Healer : MonoBehaviour
{

    public float healAmount;

    public bool isFullHeal;

    private Health otherHealthComponent;
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        otherHealthComponent = collision.GetComponent<Health>();
        if (otherHealthComponent != null)
        {
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
