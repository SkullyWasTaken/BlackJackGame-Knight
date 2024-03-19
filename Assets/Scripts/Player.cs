using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////
//Assignment/Lab/Project: Black Jack Game
//Name: Isiah Knight
//Section: SGD.213.2172
//Instructor: Mr. Sowers 
//Date: 03/04/2024
/////////////////////////////////////////////

public class Player
{
    private int totalhandSize;
    protected List<Card> hand = new List<Card>();
    private int total = 0;

    public virtual void AddCard(Card card)
    {
        hand.Add(card);
        totalhandSize = GetHandValue();
    }

    public int GetHandValue()
    {
        total = 0;
        int aceCount = 0;

        foreach (Card card in hand)
        {
            if (card.Value == "Jack" || card.Value == "Queen" || card.Value == "King")
            {
                total += 10;
            }
            else if (card.Value == "Ace")
            {
                aceCount++;
            }
            else
            {
                total += int.Parse(card.Value);
            }
        }

        for (int i = 0; i < aceCount; i++)
        {
            if (total + 11 <= 21)
            {
                total += 11;
            }
            else
            {
                total += 1;
            }
        }

        return total;
    }

    public class Human : Player
    {
        public List<Card> humanHand = new List<Card>();
        public override void AddCard(Card card)
        {
            humanHand.Add(card);
            base.AddCard(card);
        }
    }

    public class Computer : Player
    {
        public List<Card> computerHand = new List<Card>();
        public override void AddCard(Card card)
        {
            computerHand.Add(card);
            base.AddCard(card);
        }
    }
}