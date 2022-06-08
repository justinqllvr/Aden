using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoIntro : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }


    public void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Fade.setFadeIn(true);
    }
}
