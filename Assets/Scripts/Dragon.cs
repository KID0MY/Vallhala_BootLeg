using System;
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


    private int winnerPoints;
    private int winner;

    private bool tie;
    public static string PlayerWinner;

    // Start is called before the first frame update
    void Start()
    {
        // Initializes dragon health
        dragonHealth = dragonMaxHealth;
        healthBar.setMaxHealth(dragonMaxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dragonHealth <= 0)
        {
            DetermineWinner();
            // Handle victory conditions (e.g., load a victory screen)
        }
    }

    // Inflict damage to dragon health
    public void takeDamage(int damage)
    {
        dragonHealth -= damage;
        FindObjectOfType<AudioManager>().Play("DragonHit");
        healthBar.setHealth(dragonHealth);
    }
    public int getHealth()
    {
        return dragonHealth;
    }

    private void DetermineWinner()
    {
        winnerPoints = PlayerMovement.players[0].PlayerPoints;
        winner = 1;
        int tiedPlayersCount = 1; // Count of players with the highest points

        for (int i = 1; i < 4; i++)
        {
            if (PlayerMovement.players[i].PlayerPoints > winnerPoints)
            {
                winnerPoints = PlayerMovement.players[i].PlayerPoints;
                winner = i + 1;
                tiedPlayersCount = 1; // Reset tied players count
            }
            else if (PlayerMovement.players[i].PlayerPoints == winnerPoints)
            {
                tiedPlayersCount++;
            }
        }

        if (tiedPlayersCount > 1)
        {
            tie = true;
            // Handle tie conditions (e.g., display a tie message)
            PlayerWinner = "its a tie!";
            SceneManager.LoadScene("VictoryScreen");
        }
        else
        {
            // Handle victory conditions (e.g., load a victory screen)
            Debug.Log("Player " + winner + "is the mightiest viking, with" + PlayerMovement.players[winner].PlayerPoints);
            PlayerWinner = "Player " + winner + " is the mightiest viking!";
            SceneManager.LoadScene("VictoryScreen");
        }
    }

    private void DontDestroyOnLoad(string playerWinner)
    {
        throw new NotImplementedException();
    }
}
// Health bar Code courtesy of Brackeys youtube channel
