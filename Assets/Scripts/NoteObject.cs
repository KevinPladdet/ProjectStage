using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;

    public string keyToPress;

    private bool obtained;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    void Start()
    {
      
    }

    void Update()
    {
        if (name == "BlueSquare")
        {
            keyToPress = PlayerPrefs.GetString("CustomKeyBlue");
        }
        if (name == "RedSquare")
        {
            keyToPress = PlayerPrefs.GetString("CustomKeyRed");
        }
        if (name == "YellowSquare")
        {
            keyToPress = PlayerPrefs.GetString("CustomKeyYellow");
        }
        if (name == "GreenSquare")
        {
            keyToPress = PlayerPrefs.GetString("CustomKeyGreen");
        }
        if (Input.GetKeyDown(keyToPress.ToLower()))
        {
            if(canBePressed)
            {
                //GameManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.y) > 0.25)
                {
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }

                obtained = true;

                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            if (!obtained)
            {
                GameManager.instance.NoteMiss();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}
