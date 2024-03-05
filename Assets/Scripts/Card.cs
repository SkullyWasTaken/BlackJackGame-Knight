using UnityEngine;

public class Card 
{
    [SerializeField] private Sprite[] cardImages;

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
