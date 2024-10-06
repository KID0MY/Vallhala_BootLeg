using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    //Variables to make the dice Movement
    public int oneD6;
    public bool DiceRolled;

    public Text playerRoll;

   
    public int i = -1;
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
        oneD6 = Random.Range(1, 7);
        playerRoll.text = oneD6.ToString();
        PlayerMovement.players[i].PlayerMove();
        //print(oneD6);
    }
    public void GetRandomPlayerToGoBack()
    {
        int x = Random.Range(1, 5);
        if (i != x)
        {
            PlayerMovement.players[x].PlayerMoveBack();
        }
        else
        {
            GetRandomPlayerToGoBack();
        }
    }
}
