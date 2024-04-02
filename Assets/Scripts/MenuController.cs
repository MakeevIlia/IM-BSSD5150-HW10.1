using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI titleText;
    [SerializeField]
    TMP_InputField inputField;
    [SerializeField]
    TMP_Dropdown rockNameDrop;

    private const string rockKey = "rockChoice";
    private const string nameKey = "userName";


    void Start()
    {
        CheckPlayerPrefs();
    }

    public void RegisterName() 
    {
        string name = inputField.text.ToString();
        PlayerPrefs.SetString(nameKey, name);
        CheckPlayerPrefs();
    }

    public void OpenGame() 
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsScene", LoadSceneMode.Single);
    }
    public void ClearPreferences()
    {
        PlayerPrefs.DeleteAll();    
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    public void RockNameChanged(int choice)
    {
        PlayerPrefs.SetInt(rockKey, choice);
    }
    void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(nameKey))
        {
            string name = PlayerPrefs.GetString(nameKey);
            int choice = PlayerPrefs.GetInt(rockKey, 0);
            if (inputField != null)
            {
                inputField.text = name;
            }

            if (rockNameDrop != null)
            {
                rockNameDrop.value = choice;
            }
        }
    }

}
