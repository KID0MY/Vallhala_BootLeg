using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    // Calling the DiceRoll Script 
    public DiceRoll script;

    // Calling Dragon script
    public Dragon dragon;

    //Making the player list
    public static List<PlayerMovement> players = new List<PlayerMovement>();

    //Storing which tile the player is and how many points they have 
    public int playersTile;
    public int PlayerPoints;

    [SerializeField]private Text PlayerPointsDisplay;

    public void start()
    {
        PlayerPointsDisplay = GetComponent<Text>();
    }
    //Awake is called when the script object is initialised, regardless of whether or not the script is enabled. 
    public void Awake()
    {
        //add player to list
        players.Add(this);
        PlayerPointsDisplay.text = PlayerPoints.ToString();
        print(players);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if player passed the 12 tile if so return him to base and add poitns
        if (playersTile >= 12)
        {
            PlayerPoints += playersTile - 11;
            print("Player Points:" + PlayerPoints);
            PlayerPointsDisplay.text = PlayerPoints.ToString();
            transform.position -= Vector3.right * playersTile;
            dragon.takeDamage(playersTile - 11);
            playersTile = 0;
        }
    }

    //Player Movement(transform its position and add the ammount of tiles to the variable) when button is pressed
    public void PlayerMove()
    {
        FindObjectOfType<AudioManager>().Play("PlayerMovement");
        transform.position += Vector3.right * script.oneD6;
        playersTile += script.oneD6;
        //print("PlayerTiles: "+ playersTile);
    }

    public void PlayerMoveBack()
    {
        int PmoveBack;
        if (playersTile >= 4)
        {
            PmoveBack = 3;
        }
        else
        {
            if (playersTile == 0)
            {
                PmoveBack = 0;
            }
            else
            {
                PmoveBack = playersTile;
            }
        }
        FindObjectOfType<AudioManager>().Play("PlayerMovement");
        transform.position -= Vector3.right * PmoveBack;
        playersTile -= PmoveBack;
    }

    public void CardEffects(int i)
    {
        switch (i)
        {
            case 1:
                //You Found A Missing bag full of food, move two Space
                transform.position += Vector3.right * 2;
                playersTile += 2;
                break;
            case 2:
                //You found tresure box with coins! gain 5 points
                PlayerPoints += 5;
                FindObjectOfType<AudioManager>().Play("Coins");
                PlayerPointsDisplay.text = PlayerPoints.ToString();
                break;
            case 3:
                //You pray for the gods, One player will go back 3 spaces
                script.GetRandomPlayerToGoBack();
                break;
            case 4:
                //You encounter an bear, move back 3 spaces.
                transform.position -= Vector3.right * 3;
                playersTile -= 3;
                break;
            case 5:
                //You got a horse to help you, go to the last tile of the board
                transform.position += Vector3.right * (11 - playersTile);
                playersTile = 11;
                break;
        }
    }
}
