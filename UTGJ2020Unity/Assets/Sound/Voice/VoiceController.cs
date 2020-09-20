using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoiceController : MonoBehaviour
{
    [SerializeField]
    private AudioSource bathroom, key1, library1, library2, scienceLab1, scienceLab2, computerLab1, 
        computerLab2, lounge1, lounge2;

    private bool bathPlayed = true, key1Played = false, library1Played = false, library2Played = false, scienceLab1Played = false,
        scienceLab2Played = false, computerLab1Played = false, computerLab2Played = false, lounge1Played = false, lounge2Played = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bathroom")
        {
            bathroom.Play();
            bathPlayed = true;
            Destroy(bathroom);
        }
        else if (collision.tag == "key1")
        {
        	key1.Play();
            key1Played = true;
        }
        else if (collision.tag == "library1" && key1Played)
        {
        	library1.Play();
            library1Played = true;
            Destroy(key1);
        }
        else if (collision.tag == "library2" && library1Played)
        {
        	library2.Play();
            library2Played = true;
            Destroy(library1);
        }
        else if (collision.tag == "scienceLab1" && library2Played)
        {
        	scienceLab1.Play();
            scienceLab1Played = true;
            Destroy(library2);
        }
        else if (collision.tag == "scienceLab2" && scienceLab1Played)
        {
        	scienceLab2.Play();
            scienceLab2Played = true;
            Destroy(scienceLab1);
        }
        else if (collision.tag == "computerLab1" && scienceLab2Played)
        {
        	computerLab1.Play();
            computerLab1Played = true;
            Destroy(scienceLab2);
        }
        else if (collision.tag == "computerLab2" && computerLab1Played)
        {
        	computerLab2.Play();
            computerLab2Played = true;
            Destroy(computerLab1);
        }
        else if (collision.tag == "lounge1" && computerLab2Played)
        {
        	lounge1.Play();
            lounge1Played = true;
            Destroy(computerLab2);
        }
        else if (collision.tag == "lounge2" && lounge1Played)
        {
        	lounge2.Play();
            lounge2Played = true;
            Destroy(lounge1);
        }
    }
}
