using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public int oneD6;
    public bool DiceRolled;
    int i = -1;

    // Update is called once per frame
    void Update()
    {
    }

    public void RollDice()
    {
        if (i < PlayerMovement.players.Count && i < 3)
        {
            i++;
        }
        else
        {
            i = 0;
        }
        oneD6 = UnityEngine.Random.Range(1, 7);
        PlayerMovement.players[i].PlayerMove();
        //print(oneD6);
    }
}
