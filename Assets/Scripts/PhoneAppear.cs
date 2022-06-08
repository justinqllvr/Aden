using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneAppear : MonoBehaviour
{

    public GameObject phoneUI;
    public static AudioClip ringSound;
    static AudioSource audioSrc;

    private void Start() {
        ringSound = Resources.Load<AudioClip> ("ring");
        audioSrc = GetComponent <AudioSource> ();
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine() {
        yield return new WaitForSeconds(2);
        phoneUI.SetActive(true);
        audioSrc.PlayOneShot(ringSound);
    }
}
