using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{

    public int delayCam2;
    public int delayCam3;
    public Camera[] cameras;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(cam2());
    }

    IEnumerator cam2() {
        yield return new WaitForSeconds(delayCam2);
        cameras[0].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(true);
        StartCoroutine(cam3());
    }

    IEnumerator cam3() {
        yield return new WaitForSeconds(delayCam3);
        cameras[1].gameObject.SetActive(false);
        cameras[2].gameObject.SetActive(true);
    }

}
