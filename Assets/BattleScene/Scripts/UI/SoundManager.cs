using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static AudioClip BallPaddle, BallBad, BallWall;
    private static AudioSource audioSRC;

    private void Start () {
        BallPaddle = Resources.Load<AudioClip>("BallPaddle");
        BallBad = Resources.Load<AudioClip>("BallBad");
        BallWall = Resources.Load<AudioClip>("BallWall");


        audioSRC = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip) {
        switch(clip) {
            case "BallPaddle":
                audioSRC.PlayOneShot(BallPaddle);
                break;
            case "BallBad":
                audioSRC.PlayOneShot(BallBad);
                break;
            case "BallWall":
                audioSRC.PlayOneShot(BallWall);
                break;
        }
    }
}
