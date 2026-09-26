using UnityEngine;
// inheritance is the concept of creating a new class based on an existing class.
// The new class inherits all the properties and methods of the existing class, and can also have its own properties and methods.
// Inheritance allows for code reuse and can make it easier to create new classes that share common functionality.

//This class inherits from the Death class and implements the Die method to destroy the game object when it dies.
public class DeathDestroy : Death
{
    public override void Die()
    {
                Destroy(gameObject);
    }

    public override void Start()
    {

    }

    public override void Update()
    {

    }
}
