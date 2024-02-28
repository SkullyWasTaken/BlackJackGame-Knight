using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        Application.Quit();
    }
}
