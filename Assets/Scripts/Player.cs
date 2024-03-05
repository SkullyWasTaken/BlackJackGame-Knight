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
    protected List<int> currentHand = new List<int>() {0, 0, 0, 0, 0};
    
    public virtual void AddCard(int card)
    {
        currentHand.Add(card);
    }

    public class Human : Player
    {
        public List<int> humanHand = new List<int>();
        public override void AddCard(int card)
        {
            humanHand.Add(card);
        }

        // public int GetHumanHandSum()
        // {
        //     // return humanHand.Sum();
        // }
    }

    public class Computer : Player
    {
        public List<int> computerHand = new List<int>();
        public override void AddCard(int card)
        {
            computerHand.Add(card);
        }

        // public void GetComputerHandSum()
        // {
        //     // return computerHand.Sum();
        // }
    }

}
