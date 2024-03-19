using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField] TMPro.TextMeshProUGUI playerhandText;
    [SerializeField] private Image[] cardImages;
    [SerializeField] private Sprite cardBack;
    
    private Deck deck;
    private Player.Human newHuman;
    private Player.Computer newComputer;
    private HashSet<Card> dealtCards;

    public void Start()
    {
        deck = new Deck();
    }

    public void OnStartButtonClick()
    {

        newHuman = new Player.Human();
        newComputer = new Player.Computer();
        dealtCards = new HashSet<Card>();


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
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void DealHands(int p)
    {
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
                    if(newHuman.GetHandValue() > 21)
                    {
                        CompareHands();
                        return;
                    }
                    outputText.text = $"Total: {newHuman.GetHandValue()}";
                    i++;
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
        playerhandText.text = "Human hand is \n" + string.Join(", ", newHuman.humanHand);
        Debug.Log("Computer hand is " + string.Join(", ", newComputer.computerHand));
    }

    public void CompareHands()
    {
        int humanTotal = newHuman.GetHandValue();
        int computerTotal = newComputer.GetHandValue();

        if (humanTotal > 21 && computerTotal > 21)
        {
            endText.text = "Both players bust!";
        }
        else if (humanTotal > 21)
        {
            endText.text = "Player bust! Human total is " + humanTotal + " Computer total is " + computerTotal;
        }
        else if (computerTotal > 21)
        {
            endText.text = "House busts! Human total is " + humanTotal + " Computer total is " + computerTotal;
        }
        else if (humanTotal == computerTotal)
        {
            endText.text = "It's a tie! Human total is " + humanTotal + " Computer total is " + computerTotal;
        }
        else if (humanTotal > computerTotal)
        {
            endText.text = "Player wins! Human total is " + humanTotal + " Computer total is " + computerTotal;
        }
        else
        {
            endText.text = "Computer wins! Human total is " + humanTotal + " Computer total is " + computerTotal;
        }

        gamePanel.SetActive(false);
        endPanel.SetActive(true);
        titleText.SetActive(false);
    }

    // private void UpdateCardImages(List<Card> hand)
    // {
    //     for (int i = 0; i < hand.Count; i++)
    //     {
    //         cardImages[i].sprite =  GetCardSprite(hand[i]);
    //     }
    //     for (int i = hand.Count; i < cardImages.Length; i++)
    //     {
    //         cardImages[i].sprite = cardBack;
    //     }
    // }

    // private Sprite GetCardSprite(string cardName)
    // {
    //     if( cardSprites.ContainsKey(cardName))
    //     {
    //         return cardSprites[cardName];
    //     }
    //     else
    //     {
    //         Debug.LogError($"Sprite for card {cardName} not found!");
    //         return null;
    //     }
    // }
}