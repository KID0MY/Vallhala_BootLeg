using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Calling the DiceRoll Script 
    public DiceRoll script;

    //Making the player list
    public static List<PlayerMovement> players = new List<PlayerMovement>();
    
    //Storing which tile the player is and how many points they have 
    public int playersTile;
    public int PlayerPoints;

    //Awake is called when the script object is initialised, regardless of whether or not the script is enabled. 
    void Awake()
    {
        //add player to list
        players.Add(this);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if player passed the 12 tile if so return him to base and add poitns
        if (playersTile >= 12)
        {
            PlayerPoints += playersTile - 12;
            transform.position -= Vector3.right * playersTile;
            playersTile = 0;
        }
    }

    //Player Movement(transform its position and add the ammount of tiles to the variable)
    public void PlayerMove()
    {
        transform.position += Vector3.right * script.oneD6;
        playersTile += script.oneD6;
        print("PlayerTiles: "+ playersTile);

    }
}
