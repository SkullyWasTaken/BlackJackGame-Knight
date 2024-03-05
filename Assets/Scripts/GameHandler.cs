using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    public void OnStartButtonClick()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        DealHands(3);
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

    public void DealHands(int p)
    {

        Player.Human newHuman = new Player.Human();
        Player.Computer newComputer = new Player.Computer();
        int randcard = Random.Range(1, 11);
        int randcomputercard = Random.Range(1, 11);
        int i = 0;
        for (i = 0; i < p; i++)
        {
            newHuman.AddCard(randcard);
            newComputer.AddCard(randcomputercard);
        }
        Debug.Log("Human hand is" + newHuman.humanHand);
        Debug.Log("Computer hand is" + newComputer.computerHand);
    }
}
