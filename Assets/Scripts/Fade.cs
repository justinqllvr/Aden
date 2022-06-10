using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private static float Transparence;
    public static bool FadeOut = false;
    public static bool FadeIn = false;
    public float Step;

    
    void Start()
    {
        Transparence = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Transparence = Mathf.Clamp(Transparence, 0, 1);

        if(FadeOut)
        {
            Transparence += Step;
        }
        else if(FadeIn)
        {
            Transparence -= Step;
        }

        GetComponent<CanvasGroup>().alpha = Transparence;
    }

    public static void setFadeIn(bool state)
    {
        Transparence = 1;
        FadeIn = state;
    }

    public static void setFadeOut(bool state)
    {
        FadeOut = state;
    }
}
