using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{


    [Header("SignUp Input Area")]
    public InputField nameInput;
    public InputField emailInput;
    public InputField passwordInput;
    public InputField confirmInput;


    [Header("Signin Input Area")]
    public InputField s_emailInput;
    public InputField s_passwordInput;

    private void Start()
    {
        s_emailInput.onEndEdit.AddListener(val =>
        {
            // TouchScreenKeyboard.Status.Done: Keyboard disappeared when something like "Done" button in mobilekeyboard
            // TouchScreenKeyboard.Status.Canceled: Keyboard disappeared when "Back" Hardware Button Pressed in Android
            // TouchScreenKeyboard.Status.LostFocus: Keyboard disappeared when some area except keyboard and input area
            if (s_emailInput.touchScreenKeyboard.status == TouchScreenKeyboard.Status.Done)
            {
                s_passwordInput.ActivateInputField();
            }
        });


        nameInput.onEndEdit.AddListener(val =>
        {
            // TouchScreenKeyboard.Status.Done: Keyboard disappeared when something like "Done" button in mobilekeyboard
            // TouchScreenKeyboard.Status.Canceled: Keyboard disappeared when "Back" Hardware Button Pressed in Android
            // TouchScreenKeyboard.Status.LostFocus: Keyboard disappeared when some area except keyboard and input area
            if (nameInput.touchScreenKeyboard.status == TouchScreenKeyboard.Status.Done)
            {
                emailInput.ActivateInputField();
            }
        });


        emailInput.onEndEdit.AddListener(val =>
        {
            // TouchScreenKeyboard.Status.Done: Keyboard disappeared when something like "Done" button in mobilekeyboard
            // TouchScreenKeyboard.Status.Canceled: Keyboard disappeared when "Back" Hardware Button Pressed in Android
            // TouchScreenKeyboard.Status.LostFocus: Keyboard disappeared when some area except keyboard and input area
            if (emailInput.touchScreenKeyboard.status == TouchScreenKeyboard.Status.Done)
            {
                passwordInput.ActivateInputField();
            }
        });
        passwordInput.onEndEdit.AddListener(val =>
        {
            // TouchScreenKeyboard.Status.Done: Keyboard disappeared when something like "Done" button in mobilekeyboard
            // TouchScreenKeyboard.Status.Canceled: Keyboard disappeared when "Back" Hardware Button Pressed in Android
            // TouchScreenKeyboard.Status.LostFocus: Keyboard disappeared when some area except keyboard and input area
            if (passwordInput.touchScreenKeyboard.status == TouchScreenKeyboard.Status.Done)
            {
                confirmInput.ActivateInputField();
            }
        });
    }
   




}
