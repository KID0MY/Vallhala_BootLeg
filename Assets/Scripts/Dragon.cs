using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragon : MonoBehaviour
{

    // Dragon health pool
    private int dragonMaxHealth = 25;
    public int dragonHealth;

    // Call HealthBar script
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        // Initializes dragon health
        dragonHealth = dragonMaxHealth;
        healthBar.setMaxHealth(dragonMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if game over, if yes, load victory screen
        /*if (dragonHealth <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene ();
        }*/
    }

    // Inflict damage to dragon health
    public void takeDamage(int damage)
    {
        dragonHealth -= damage;

        healthBar.setHealth(dragonHealth);
    }
    public int getHealth()
    {
        return dragonHealth;
    }
}
// Health bar Code courtesy of Brackeys youtube channel
