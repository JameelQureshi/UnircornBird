using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class UIInputManager : MonoBehaviour
{
    [Header("SignUp Input Area")]
    public InputField nameInput;
    public InputField emailInput;
    public InputField passwordInput;
    public InputField confirmInput;


    [Header("Signin Input Area")]
    public InputField s_emailInput;
    public InputField s_passwordInput;

    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


    [Header("Panels Area")]
    public GameObject signUpPanel;
    public GameObject signInPanel;

    private void Start()
    {
        signUpPanel.SetActive(false);

        if (AuthManager.UserId == 0)
        {
            signInPanel.SetActive(true);

        }
        else
        {
            signInPanel.SetActive(false);
        }
    }


    public void CreateUser()
    {
        if (nameInput.text == "")
        {
            ConsoleManager.instance.ShowMessage("Name Cannot be empty");
            return;
        }
        if (emailInput.text == "")
        {
            ConsoleManager.instance.ShowMessage("Email Cannot be empty");
            return;
        }
        if (passwordInput.text == "")
        {
            ConsoleManager.instance.ShowMessage("Password Cannot be empty");
            return;
        }
        if (confirmInput.text == "")
        {
            ConsoleManager.instance.ShowMessage("Password Cannot be empty");
            return;
        }
        if (confirmInput.text != passwordInput.text)
        {
            ConsoleManager.instance.ShowMessage("Password Does not match");
            return;
        }
        if ( passwordInput.text.Length<8)
        {
            ConsoleManager.instance.ShowMessage("Password should be 8 characters");
            return;
        }

        if (!ValidateEmail(emailInput.text))
        {
            ConsoleManager.instance.ShowMessage("Please enter valid email");
            return;
        }

        AuthManager.instance.CreateUser(nameInput.text,emailInput.text,passwordInput.text);
    }


    public void SignInUser()
    {
       
        if (s_emailInput.text == "")
        {
            ConsoleManager.instance.ShowMessage("Email Cannot be empty");
            return;
        }
        if (s_passwordInput.text == "")
        {
            ConsoleManager.instance.ShowMessage("Password Cannot be empty");
            return;
        }
        
        if (s_passwordInput.text.Length < 8)
        {
            ConsoleManager.instance.ShowMessage("Password should be 8 characters");
            return;
        }

        if (!ValidateEmail(s_emailInput.text))
        {
            ConsoleManager.instance.ShowMessage("Please enter valid email");
            return;
        }

        AuthManager.instance.LoginUser(s_emailInput.text, s_passwordInput.text);
    }


    public bool ValidateEmail(string email)
    {
        if (email != null)
            return Regex.IsMatch(email, MatchEmailPattern);
        else
            return false;
    }

}
