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

    public virtual void AddCard(Card card)
    {
        hand.Add(card);
    }

    public class Human : Player
    {
        public List<Card> humanHand = new List<Card>();
        public override void AddCard(Card card)
        {
            humanHand.Add(card);
        }

        public int GetHandValue()
        {
            return 0;
        }
    }

    public class Computer : Player
    {
        public List<Card> computerHand = new List<Card>();
        public override void AddCard(Card card)
        {
            computerHand.Add(card);
        }
    }
}


