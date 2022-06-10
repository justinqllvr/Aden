using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneAppear : MonoBehaviour
{

    public GameObject tutoUI;
    public GameObject queteTitleUI;
    public GameObject queteUI;
    public GameObject phoneUI;
    public static AudioClip ringSound;
    static AudioSource audioSrc;
    public int queteDelay;
    public int tutoDelay;
    public int phoneDelay;

    private void Start() {
        ringSound = Resources.Load<AudioClip> ("ring");
        audioSrc = GetComponent <AudioSource> ();
        StartCoroutine(queteCoroutine());
    }

    IEnumerator queteCoroutine() {
        yield return new WaitForSeconds(queteDelay);
        queteTitleUI.SetActive(true);
        StartCoroutine(queteEnd());
    }

    IEnumerator queteEnd() {
        yield return new WaitForSeconds(5);
        queteTitleUI.SetActive(false);
        queteUI.SetActive(true);
        StartCoroutine(tutoCoroutine());
    }

    IEnumerator tutoCoroutine() {
        yield return new WaitForSeconds(tutoDelay);
        tutoUI.SetActive(true);
        StartCoroutine(tutoEnd());
    }

    IEnumerator tutoEnd() {
        yield return new WaitForSeconds(5);
        tutoUI.SetActive(false);
        StartCoroutine(phoneCoroutine());
    }

    IEnumerator phoneCoroutine() {
        yield return new WaitForSeconds(phoneDelay);
        phoneUI.SetActive(true);
        audioSrc.PlayOneShot(ringSound);
    }
}
