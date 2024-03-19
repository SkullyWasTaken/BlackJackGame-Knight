using UnityEngine;
using System.Collections.Generic;

//////////////////////////////////////////////
//Assignment/Lab/Project: Black Jack Game
//Name: Isiah Knight
//Section: SGD.213.2172
//Instructor: Mr. Sowers 
//Date: 03/04/2024
/////////////////////////////////////////////
public class Deck 
{
    private List<Card> cards;

    public Deck()
    {
        InitializeDeck();
    }

    private void InitializeDeck()
    {
        cards = new List<Card>();
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] values = { "2" ,"3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        foreach(string suit in suits)
        {
            foreach(string value in values)
            {
                cards.Add(new Card(suit, value));
            }
        }

    }

    public Card DealRandomCard()
    {
        int index = Random.Range(0, cards.Count);
        Card card = cards[index];
        cards.RemoveAt(index);
        return card;
    }
}
