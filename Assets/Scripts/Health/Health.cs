using UnityEngine;
using UnityEngine.UI;


//encapsulation is the concept of taking all the elements required for an object and putting them into a single class.
//This is the concept of encapsulation.
//The Health class encapsulates all the elements required for health management, including current health, maximum health, and methods for healing and taking damage.
public class Health : MonoBehaviour
{
    public float currentHealth;

    public float maxHealth;

    private Death death;

    public Image healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        death = GetComponent<Death>(); 
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }

        //check for health being less than or equal to 0 and call the Die method on the death component
        if (currentHealth <= 0 && death != null)
        {
            death.Die();
        }
    }
}
