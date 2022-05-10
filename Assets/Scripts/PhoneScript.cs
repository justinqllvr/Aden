using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public static bool PhoneIsOn = false;

    public GameObject phoneUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Text: " + PhoneIsOn);
            if(PhoneIsOn) {
                Resume();
            } else {
                OpenPhone();
            }
        }
    }

    void Resume() {
        phoneUI.SetActive(false);
        PhoneIsOn = false;
    }

    void OpenPhone() {
        phoneUI.SetActive(true);
        PhoneIsOn = true;
    }
}
