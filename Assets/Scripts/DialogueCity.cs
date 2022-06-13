using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCity : MonoBehaviour
{

    public int delaySubtitle1;
    public int delaySubtitle2;
    public int delayPhone;
    public int delayQueteTitle;
    public int delayQuete;
    public GameObject subtitle1;
    public GameObject subtitle2;
    public GameObject phoneUI;
    public GameObject queteTitle;
    public GameObject quete;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(subtitle1Appear());
    }

    IEnumerator subtitle1Appear() {
        yield return new WaitForSeconds(delaySubtitle1);
        subtitle1.SetActive(true);
        StartCoroutine(subtitle2Appear());
    }

    IEnumerator subtitle2Appear() {
        yield return new WaitForSeconds(delaySubtitle2);
        subtitle1.SetActive(false);
        subtitle2.SetActive(true);
        StartCoroutine(subtitle2Disappear());
    }

    IEnumerator subtitle2Disappear() {
        yield return new WaitForSeconds(2);
        subtitle2.SetActive(false);
        StartCoroutine(PhoneAppear());
    }

    IEnumerator PhoneAppear() {
        yield return new WaitForSeconds(delayPhone);
        phoneUI.SetActive(true);
        StartCoroutine(QueteTitleAppear());
    }

    IEnumerator QueteTitleAppear() {
        yield return new WaitForSeconds(delayQueteTitle);
        queteTitle.SetActive(true);
        StartCoroutine(QueteAppear());
    }

    IEnumerator QueteAppear() {
        yield return new WaitForSeconds(delayQuete);
        queteTitle.SetActive(false);
        quete.SetActive(true);
    }
}
