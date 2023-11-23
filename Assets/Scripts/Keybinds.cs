using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keybinds : MonoBehaviour
{

    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI blueButton;
    [SerializeField] private TextMeshProUGUI redButton;
    [SerializeField] private TextMeshProUGUI yellowButton;
    [SerializeField] private TextMeshProUGUI greenButton;


    private void Start()
    {
        blueButton.text = PlayerPrefs.GetString("CustomKeyBlue");
        redButton.text = PlayerPrefs.GetString("CustomKeyRed");
        yellowButton.text = PlayerPrefs.GetString("CustomKeyYellow");
        greenButton.text = PlayerPrefs.GetString("CustomKeyGreen");
    }

    private void Update()
    {
        if (blueButton.text == "Awaiting Input")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    blueButton.text = keycode.ToString();
                    PlayerPrefs.SetString("CustomKeyBlue", keycode.ToString());
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
                    redButton.text = keycode.ToString();
                    PlayerPrefs.SetString("CustomKeyRed", keycode.ToString());
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
                    yellowButton.text = keycode.ToString();
                    PlayerPrefs.SetString("CustomKeyYellow", keycode.ToString());
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
                    greenButton.text = keycode.ToString();
                    PlayerPrefs.SetString("CustomKeyGreen", keycode.ToString());
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
