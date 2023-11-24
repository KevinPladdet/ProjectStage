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

    [Header("Keys")]
    [SerializeField] public TextMeshProUGUI Key1;
    [SerializeField] public TextMeshProUGUI Key2;
    [SerializeField] public TextMeshProUGUI Key3;
    [SerializeField] public TextMeshProUGUI Key4;

    [Header("Other")]
    public GameObject StartMenu;


    private void Start()
    {
        blueButton.text = PlayerPrefs.GetString("CustomKeyBlue");
        redButton.text = PlayerPrefs.GetString("CustomKeyRed");
        yellowButton.text = PlayerPrefs.GetString("CustomKeyYellow");
        greenButton.text = PlayerPrefs.GetString("CustomKeyGreen");

        Key1.text = blueButton.text;
        Key2.text = redButton.text;
        Key3.text = yellowButton.text;
        Key4.text = greenButton.text;

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
                        if (blueButton.text != redButton.text && blueButton.text != yellowButton.text && blueButton.text != greenButton.text)
                        {
                            PlayerPrefs.SetString("CustomKeyBlue", keycode.ToString());
                            Key1.text = blueButton.text;
                        }
                        else
                        {
                            blueButton.text = "Wrong Input";
                            EditorUtility.DisplayDialog("Skill issue", "You can't use the same key twice.", "OK");
                        }
                    }
                    else
                    {
                        blueButton.text = "Wrong Input";
                        EditorUtility.DisplayDialog("You cannot use mouse button, only keyboard buttons.", "Please use a key from your keyboard.", "OK");
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
                        if (redButton.text != blueButton.text && redButton.text != yellowButton.text && redButton.text != greenButton.text)
                        {
                            PlayerPrefs.SetString("CustomKeyRed", keycode.ToString());
                            Key2.text = redButton.text;
                        }
                        else
                        {
                            redButton.text = "Wrong Input";
                            EditorUtility.DisplayDialog("Skill issue", "You can't use the same key twice.", "OK");
                        }
                    }
                    else
                    {
                        redButton.text = "Wrong Input";
                        EditorUtility.DisplayDialog("You cannot use mouse button, only keyboard buttons.", "Please use a key from your keyboard.", "OK");
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
                        if (yellowButton.text != redButton.text && yellowButton.text != blueButton.text && yellowButton.text != greenButton.text)
                        {
                            PlayerPrefs.SetString("CustomKeyYellow", keycode.ToString());
                            Key3.text = yellowButton.text;
                        }
                        else
                        {
                            yellowButton.text = "Wrong Input";
                            EditorUtility.DisplayDialog("Skill issue", "You can't use the same key twice.", "OK");
                        }
                    }
                    else
                    {
                        yellowButton.text = "Wrong Input";
                        EditorUtility.DisplayDialog("You cannot use mouse button, only keyboard buttons.", "Please use a key from your keyboard.", "OK");
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
                        if (greenButton.text != redButton.text && greenButton.text != blueButton.text && greenButton.text != yellowButton.text)
                        {
                            PlayerPrefs.SetString("CustomKeyGreen", keycode.ToString());
                            Key4.text = greenButton.text;
                        }
                        else
                        {
                            greenButton.text = "Wrong Input";
                            EditorUtility.DisplayDialog("Skill issue", "You can't use the same key twice.", "OK");
                        }
                    }
                    else
                    {
                        greenButton.text = "Wrong Input";
                        EditorUtility.DisplayDialog("You cannot use mouse button, only keyboard buttons.", "Please use a key from your keyboard.", "OK");
                    }
                    PlayerPrefs.Save();
                }
            }
        }

        if (blueButton.text == "Wrong Input" || redButton.text == "Wrong Input" || yellowButton.text == "Wrong Input" || greenButton.text == "Wrong Input")
        {
            StartMenu.GetComponent<StartMenu>().CantStart = true;
        }
        else
        {
            StartMenu.GetComponent<StartMenu>().CantStart = false;
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
