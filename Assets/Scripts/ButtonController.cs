using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer SR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    private Keybinds KB;
    private GameObject keybind;

    public string keyToPress;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        keybind = GameObject.Find("Keybind");
        KB = keybind.GetComponent<Keybinds>();
    }

    void Update()
    {
        if (name == "Buttons_Blue")
        {
            keyToPress = PlayerPrefs.GetString("CustomKeyBlue");
        }
        if (name == "Buttons_Red")
        {
            keyToPress = PlayerPrefs.GetString("CustomKeyRed");
        }
        if (name == "Buttons_Yellow")
        {
            keyToPress = PlayerPrefs.GetString("CustomKeyYellow");
        }
        if (name == "Buttons_Green")
        {
            keyToPress = PlayerPrefs.GetString("CustomKeyGreen");
        }
    
            if (Input.GetKeyDown(keyToPress.ToLower()))
            {
                SR.sprite = pressedImage;
            }

            if (Input.GetKeyUp(keyToPress.ToLower()))
            {
                SR.sprite = defaultImage;
            }
    }
}
