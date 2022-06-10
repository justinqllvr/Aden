using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public static bool PhoneIsOn = false;

    public GameObject phoneUI;
    public GameObject score1;
    public GameObject score2;
    public GameObject options;
    public GameObject response;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            if(PhoneIsOn) {
                Resume();
            } else {
                OpenPhone();
            }
        }

        if(Input.GetKeyDown(KeyCode.A)) {
            options.SetActive(false);
            response.SetActive(true);
            score1.SetActive(false);
            score2.SetActive(true);
            StartCoroutine(MyCoroutine());
        }

        if(Input.GetKeyDown(KeyCode.B)) {
            options.SetActive(false);
            response.SetActive(true);
            score1.SetActive(false);
            score2.SetActive(true);
            StartCoroutine(MyCoroutine());
        }
    }

    IEnumerator MyCoroutine() {
        yield return new WaitForSeconds(3);
        phoneUI.SetActive(false);
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
