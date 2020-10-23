using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    static AudioSource audioSrc;
    public static AudioClip jumpSound;

    public static AudioClip chop;
    public static AudioClip note1;
    public static AudioClip note2;
    public static AudioClip note3;
    public static AudioClip note4;
    public static AudioClip note5;
    public static AudioClip note6;
    public static AudioClip note7;
    public static AudioClip note8;
    public float yo;

    void Start(){
        audioSrc = GetComponent<AudioSource>();
        jumpSound = Resources.Load<AudioClip>("jump");
       
        note1 = Resources.Load<AudioClip>("note1");
        note2 = Resources.Load<AudioClip>("note2");
        note3 = Resources.Load<AudioClip>("note3");
        note4 = Resources.Load<AudioClip>("note4");
        note5 = Resources.Load<AudioClip>("note5");
        note6 = Resources.Load<AudioClip>("note6");
        note7 = Resources.Load<AudioClip>("note7");
        note8 = Resources.Load<AudioClip>("note8");


    }

    public static void playSound(string clip) {

        if(clip == "jump"){
            audioSrc.pitch = (Random.Range(-0.3f,1.1f)); //changes pitch 
            audioSrc.PlayOneShot(jumpSound, 0.05F);
            
        }


        if (clip == "collect") {
            //addScore();
            var number = Random.Range(1, 8);
            if(number == 1) {
                audioSrc.PlayOneShot(note1, 0.35F);

            } else if (number == 2) {
                audioSrc.PlayOneShot(note2, 0.35F);

            }
            else if (number == 3) {
                audioSrc.PlayOneShot(note3, 0.35F);

            }
            else if (number == 4) {
                audioSrc.PlayOneShot(note4, 0.35F);

            }
            else if (number == 5) {
                audioSrc.PlayOneShot(note5, 0.35F);

            }
            else if (number == 6) {
                audioSrc.PlayOneShot(note6, 0.35F);

            }
            else if (number == 7) {
                audioSrc.PlayOneShot(note7, 0.35F);

            }
            else if (number == 8) {
                audioSrc.PlayOneShot(note8, 0.35F);

            }
           // audioSrc.PlayOneShot(chop, 0.5F);
        }
    }

   

}
