using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CardChooser : MonoBehaviour
{
    public GameObject Card;
    public GameObject PlayButton;
    public Text cardtext;
    public Image cardImage;

    public Sprite _forward, _giant, _god, _hourse, _wealth;

    int cardIndex;
    Dictionary<int, string> cardTypes = new Dictionary<int, string>();
    System.Random random = new System.Random();

    public DiceRoll script;

    // Start is called before the first frame update

    //Everytime it gets enable it wil run this code
    public void OnEnable()
    {
        cardIndex = random.Next(1, cardTypes.Count + 1);
        print(cardIndex);
        CardStuff(cardIndex);
    }
    void Awake()
    {
        cardTypes[1] = "MoveForward";
        cardTypes[2] = "GetCoins";
        cardTypes[3] = "PrayGods";
        cardTypes[4] = "BearEncounter";
        cardTypes[5] = "FoundHourse";
    }

    public void AcceptCard()
    {
        Card.SetActive(false);
        PlayerMovement.players[script.i].CardEffects(cardIndex);
        PlayButton.SetActive(true);
    }

    public void CardStuff(int i)
    {
        switch (cardTypes[i])
        {
            case "MoveForward":
                cardtext.text = "You Found A Missing bag full of food. More suplies for your journey, move 2 Space.";
                cardImage.sprite = _forward;
                break;
            case "GetCoins":
                cardtext.text = "You found tresure box with coins! gain 5 points.";
                cardImage.sprite = _wealth;
                break;
            case "PrayGods":
                cardtext.text = "You pray for the gods, choose player to go back 3 spaces.";
                cardImage.sprite = _god;
                break;
            case "BearEncounter":
                cardtext.text = "You encounter an bear, move back 3 spaces.";
                cardImage.sprite = _giant;
                break;
            case "FoundHourse":
                cardtext.text = "You got a horse to help you, go to the last tile of the board.";
                cardImage.sprite = _hourse;
                break;
        }
    }
}