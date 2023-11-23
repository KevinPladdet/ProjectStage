using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System.Text.RegularExpressions;

public class Keybinds : MonoBehaviour
{

    [Header("Objects")]
    [SerializeField] public TextMeshProUGUI blueButton;
    [SerializeField] public TextMeshProUGUI redButton;
    [SerializeField] public TextMeshProUGUI yellowButton;
    [SerializeField] public TextMeshProUGUI greenButton;


    private void Start()
    {
        blueButton.text = PlayerPrefs.GetString("CustomKeyBlue");
        redButton.text = PlayerPrefs.GetString("CustomKeyRed");
        yellowButton.text = PlayerPrefs.GetString("CustomKeyYellow");
        greenButton.text = PlayerPrefs.GetString("CustomKeyGreen");
    }

    private void Update()
    {
        Regex reg = new("^[A-z]$");
        if (blueButton.text == "Awaiting Input")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    if (reg.IsMatch(keycode.ToString()))
                    {
                        blueButton.text = keycode.ToString();
                        PlayerPrefs.SetString("CustomKeyBlue", keycode.ToString());
                    }
                    else
                    {
                        blueButton.text = "A";
                        EditorUtility.DisplayDialog("You cannot use mouse button, only keyboard buttons.", "Please use a key from your keyboard.", "OK");
                        PlayerPrefs.SetString("CustomKeyBlue", blueButton.text.ToString());
                    }
                    PlayerPrefs.Save();
                }
            }
        }

        if (redButton.text == "Awaiting Input")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    if (reg.IsMatch(keycode.ToString()))
                    {
                        redButton.text = keycode.ToString();
                        PlayerPrefs.SetString("CustomKeyRed", keycode.ToString());
                    }
                    else
                    {
                        redButton.text = "D";
                        EditorUtility.DisplayDialog("You cannot use mouse button, only keyboard buttons.", "Please use a key from your keyboard.", "OK");
                        PlayerPrefs.SetString("CustomKeyRed", redButton.text.ToString());
                    }
                    PlayerPrefs.Save();
                }
            }
        }

        if (yellowButton.text == "Awaiting Input")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    if (reg.IsMatch(keycode.ToString()))
                    {
                        yellowButton.text = keycode.ToString();
                        PlayerPrefs.SetString("CustomKeyYellow", keycode.ToString());
                    }
                    else
                    {
                        yellowButton.text = "J";
                        EditorUtility.DisplayDialog("You cannot use mouse button, only keyboard buttons.", "Please use a key from your keyboard.", "OK");
                        PlayerPrefs.SetString("CustomKeyYellow", yellowButton.text.ToString());
                    }
                    PlayerPrefs.Save();
                }
            }
        }

        if (greenButton.text == "Awaiting Input")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    if (reg.IsMatch(keycode.ToString()))
                    {
                        greenButton.text = keycode.ToString();
                        PlayerPrefs.SetString("CustomKeyGreen", keycode.ToString());
                    }
                    else
                    {
                        greenButton.text = "L";
                        EditorUtility.DisplayDialog("You cannot use mouse button, only keyboard buttons.", "Please use a key from your keyboard.", "OK");
                        PlayerPrefs.SetString("CustomKeyGreen", greenButton.text.ToString());
                    }
                    PlayerPrefs.Save();
                }
            }
        }
    }

    public void ChangeKeyBlue()
    {
        blueButton.text = "Awaiting Input";
    }

    public void ChangeKeyRed()
    {
        redButton.text = "Awaiting Input";
    }

    public void ChangeKeyYellow()
    {
        yellowButton.text = "Awaiting Input";
    }

    public void ChangeKeyGreen()
    {
        greenButton.text = "Awaiting Input";
    }
}
