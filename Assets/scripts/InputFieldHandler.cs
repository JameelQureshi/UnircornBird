using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InputFieldHandler : MonoBehaviour
{
    public InputField NameField;
    void Start()
    {
        if ( PlayerPrefs.GetString("Player") == "")
            {
            NameField.gameObject.SetActive(true);
        } 
        else
        {
            NameField.gameObject.SetActive(false);
        }    
    }

   
    private string playerName;

    public void OnEnter()
    {


        if (PlayerPrefs.GetString("Player") == "")
        {
            if (NameField.text == "")
            {
                return;
            }
            playerName = NameField.text;
            print(playerName);
            PlayerPrefs.SetString("Player", playerName);
            print(PlayerPrefs.GetString("Player"));
        }

        SceneManager.LoadScene(1);
    }
}
