using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    //Variables to make the dice Movement
    public int oneD6;
    public bool DiceRolled;
   
    
    int i = -1; // the int i is just a index pointer to find the players

    // Update is called once per frame
    void Update()
    {
    }

    // Function to make the dice roll
    public void RollDice()
    {
        //Checking if i is bigger then the player count and if i is smaller then i 
        if (i < PlayerMovement.players.Count && i < 3)
        {
            i++;
        }
        else
        {
            i = 0;
        }

        // Run a randomizer from 1 to 6 and then add the roll to the players movement
        oneD6 = UnityEngine.Random.Range(1, 7);
        PlayerMovement.players[i].PlayerMove();
        //print(oneD6);
    }
}
