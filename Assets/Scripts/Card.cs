using UnityEngine;

//////////////////////////////////////////////
//Assignment/Lab/Project: Black Jack Game
//Name: Isiah Knight
//Section: SGD.213.2172
//Instructor: Mr. Sowers 
//Date: 03/04/2024
/////////////////////////////////////////////
public class Card 
{
    // [SerializeField] private Sprite[] cardImages;

    public string Suit {get; set; }
    public string Value {get; set; }

    public Card(string suit, string value)
    {
        Suit = suit;
        Value = value;
    }

    public override string ToString()
    {
        return Value + " of " + Suit;
    }
}
