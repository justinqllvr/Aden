using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public static bool isPlaying = true;

    public static bool getIsPlaying() {
        return isPlaying;
    }

    public static void setIsPlaying(bool state) {
        isPlaying = state;
    }

}
