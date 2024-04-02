using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]

    Text computerChoice;

    [SerializeField]

    Text gameResults;

    [SerializeField]

    TMP_Text rockButton;

    string[] choices = new string[] { "Rock", "Paper", "Scissors" };

    private const string rockKey = "rockChoice";
    private const string nameKey = "userName";

    private string playerName;
    void Start()
    {
        CheckPlayerPrefs();
    }

    void CheckPlayerPrefs()
    {
        string name = PlayerPrefs.GetString(nameKey, "You");
        int choice = PlayerPrefs.GetInt(rockKey, 0);

        playerName = name;
        if (choice == 0)
        {
            rockButton.text = "Rock";
        }
        else 
        {
            rockButton.text = "Cupcake";
        }
    }

    // Update is called once per frame
    public void RPSClicked(string userChoice)
    {
        int randomIndex = Random.Range(0, choices.Length);
        string randomChoice = choices[randomIndex];
        computerChoice.text = randomChoice;
        CheckWinner(userChoice, randomChoice);
    }

    private void CheckWinner(string p1, string p2)
    {
        if (string.Equals(p1, p2))
        {
            gameResults.text = "Draw";
            gameResults.color = Color.white;
        }
        else if (string.Equals(p1, "Rock"))
        {
            if (string.Equals(p2, "Paper"))
            {
                gameResults.text = "Computer Wins";
                gameResults.color = Color.red;
            }
            else
            {
                gameResults.text = playerName + " Wins!";
                gameResults.color = Color.green;
            }
        }
        else if (string.Equals(p1, "Paper"))
        {
            if (string.Equals(p2, "Scissors"))
            {
                gameResults.text = "Computer Wins";
                gameResults.color = Color.red;
            }
            else
            {
                gameResults.text = playerName + " Wins!";
                gameResults.color = Color.green;
            }
        }
        else if (string.Equals(p1, "Scissors"))
        {
            if (string.Equals(p2, "Rock"))
            {
                gameResults.text = "Computer Wins";
                gameResults.color = Color.red;
            }
            else
            {
                gameResults.text = playerName + " Wins!";
                gameResults.color = Color.green;
            }
        }
    }
    public void ResetGame()
    {
        computerChoice.text = "Ready";
        gameResults.text = "";
        gameResults.color = Color.white; // I don't know why, just in case
    }
}
