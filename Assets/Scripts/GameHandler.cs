using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//////////////////////////////////////////////
//Assignment/Lab/Project: Black Jack Game
//Name: Isiah Knight
//Section: SGD.213.2172
//Instructor: Mr. Sowers 
//Date: 03/04/2024
/////////////////////////////////////////////
public class GameHandler : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject endPanel;
    [SerializeField] GameObject instructionPanel;
    [SerializeField] GameObject dealButton;
    [SerializeField] GameObject titleText;
    [SerializeField] TMPro.TextMeshProUGUI endText;
    [SerializeField] TMPro.TextMeshProUGUI outputText;
    [SerializeField] private Image[] cardImages;
    [SerializeField] private Dictionary<string, Sprite> cardSprites;
    

    private Player.Human newHuman;
    private Player.Computer newComputer;
    private HashSet<Card> dealtCards;

    public void OnStartButtonClick()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        DealHands(2);
        outputText.text = $"Total: {newHuman.GetHandValue()}";
    }

    public void OnInstructionButtonClick()
    {
        startPanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void OnMainMenuButtonClick()
    {
        instructionPanel.SetActive(false);
        startPanel.SetActive(true);
    }
    public void OnQuitButtonClick()
    {
        Debug.Log("Its working!");
        Application.Quit();
    }

    public void OnHitButtonClick()
    {
        DealHands(1);
    }

    public void OnStandButtonClick()
    {
        CompareHands();
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
        titleText.SetActive(false);
    }

    public void DealHands(int p)
    {
        Deck deck = new Deck();
        newHuman = new Player.Human();
        newComputer = new Player.Computer();
        dealtCards = new HashSet<Card>();

        int i = 0;
        while (i < p)
        {
            if (newHuman.humanHand.Count < 5 && newComputer.computerHand.Count < 5)
            {
                Card randCard = deck.DealRandomCard();
                Card randComputerCard = deck.DealRandomCard();

                if (!dealtCards.Contains(randCard))
                {
                    newHuman.AddCard(randCard);
                    dealtCards.Add(randCard);
                    // UpdateCardImage(newHuman.humanHand.Count -1, randCard);
                    i++;

                    int totalvalue = GetHandValue(newHuman.humanHand);
                    outputText.text = $"Total: {totalvalue}";
                }

                if (!dealtCards.Contains(randComputerCard))
                {
                    newComputer.AddCard(randComputerCard);
                    dealtCards.Add(randComputerCard);
                }
            }
            else
            {
                outputText.text = "You have a full hand!";
                dealButton.SetActive(false);
                break; 
            }
        }
        Debug.Log("Human hand is " + string.Join(", ", newHuman.humanHand));
        Debug.Log("Computer hand is " + string.Join(", ", newComputer.computerHand));
    }

    // private void UpdateCardImage(int index, Card card)
    // {
    //     string cardName = $"{card.Value}_{card.Suit}";
    //     cardImages[index].sprite = cardSprites[cardName];
    // }

    public void CompareHands()
    {
        int humanTotal = GetHandValue(newHuman.humanHand);
        int computerTotal = GetHandValue(newComputer.computerHand);

        if (humanTotal > 21 && computerTotal > 21)
        {
            endText.text = "Both players bust!";
        }
        else if (humanTotal > 21)
        {
            endText.text = "Computer wins! " + humanTotal + " > " + computerTotal;
        }
        else if (computerTotal > 21)
        {
            endText.text = "Player wins! " + humanTotal + " < " + computerTotal;
        }
        else if (humanTotal == computerTotal)
        {
            endText.text = "It's a tie!";
        }
        else if (humanTotal > computerTotal)
        {
            endText.text = "Player wins! " + humanTotal + " > " + computerTotal;
        }
        else
        {
            endText.text = "Computer wins! " + humanTotal + " < " + computerTotal;
        }
    }

    private int GetHandValue(List<Card> hand)
    {
        int total = 0;
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
}
