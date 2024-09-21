using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public DiceRoll script;
    public static List<PlayerMovement> players = new List<PlayerMovement>();
    public int playersTile;
    public int PlayerPoints;
    // Start is called before the first frame update

    void Awake()
    {
        players.Add(this);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (playersTile >= 12)
        {
            PlayerPoints += playersTile - 12;
            transform.position -= Vector3.right * playersTile;
            playersTile = 0;
        }
    }

    public void PlayerMove()
    {
        transform.position += Vector3.right * script.oneD6;
        playersTile += script.oneD6;
        print("PlayerTiles: "+ playersTile);

    }
}
