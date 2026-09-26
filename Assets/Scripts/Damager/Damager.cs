using Unity.VisualScripting;
using UnityEngine;


//Abstraction is one of four concepts in object-oriented programming that allows you to define the essential characteristics of an object while hiding unnecessary details.
//In this case, the Damager class is an abstraction that represents an object capable of dealing damage to other objects.
//It defines the essential properties and behaviors of a Damager, such as the amount of damage it can deal and whether it is an instant kill.
//The implementation details of how the damage is applied to other objects are hidden within the class, allowing other parts of the code to interact with the Damager without needing to know how it works internally.
public class Damager : MonoBehaviour
{

    public float damageAmount;

    public bool isInstakill;

    private Health otherHealthComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //collider acts as a physical barrier while trigger acts as a sensor, allowing objects to pass through it and triggering events when they do. In this case, the trigger is used to detect when another object enters the area of the Damager, allowing it to apply damage to that object without physically blocking its movement.
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        otherHealthComponent = collision.GetComponent<Health>();

        if (otherHealthComponent != null)
        {
            //polymorphism is the concept of using a single interface to represent different types of objects.
            //In this case, the TakeDamage method is polymorphic because it can be called on any object that has a Health component, regardless of the specific implementation of that component.
            if (isInstakill)
            {
                otherHealthComponent.TakeDamage(otherHealthComponent.maxHealth);
            }
            else
            {
                otherHealthComponent.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
        }
    }
}
