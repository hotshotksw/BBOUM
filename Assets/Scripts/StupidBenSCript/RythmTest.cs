using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class RythmTest : MonoBehaviour
{
    [Serializable]
    public struct Beat
    {
        // 
        public float setOffTime;
        public AudioClip audio;
        public float marginError;
    }
    [SerializeField] List<Beat> beats;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float turnTime = 15.0f;
    [SerializeField] float beatTime = 0;
    [SerializeField] int current = 0;
    [SerializeField, Range(0.1f, 1f)] float speedMod = 1;
    public bool start = false;

    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        beatTime = beats[current].setOffTime;
    }

    // Deranged ben code
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !start)
        {
            turnTime = 15;
            start = true;
            current = 0;
        }

        if (start)
        {
            turnTime -= Time.deltaTime;
            beatTime -= Time.deltaTime;

			if (turnTime <= 0)
			{
				start = false;
			}

			if (Input.GetMouseButtonDown(0))
			{
                float test = 0;
				float startpoint = (beats[current].setOffTime * speedMod);
                float midpoint = startpoint * 0.5f;
                
                if (midpoint - beatTime < 0)
                {
                    test = MathF.Abs(midpoint-beatTime)/midpoint;
                } else if (midpoint - beatTime > 0)
                {
                    test = Mathf.Abs((beatTime/midpoint) - 1);
                }

                string howgood = "Kill yourself...";

                if (test > 0.95f)
                {
					howgood = "Ultimate!!!";
				} else if (test > 0.8f)
                {
					howgood = "Nice Form!!";
				} else if (test > 0.3f)
                {
					howgood = "Needs Work!";
				}

                text.text = beatTime + " / " + startpoint + "\n" + howgood + ": " + test;
			}

			if (beatTime <= 0)
            {
                audioSource.PlayOneShot(beats[current].audio);
                current++;
                if (current >= beats.Count)
                {
                    current = 0;
                }
                beatTime = beats[current].setOffTime * speedMod;
            }
		}
    }
}
