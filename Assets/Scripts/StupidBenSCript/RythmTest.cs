using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    [SerializeField] float turnTime = 15.0f;
    [SerializeField] float beatTime = 0;
    [SerializeField] int current = 0;

    public bool start = false;

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
            start = true;
        }

        if (start)
        {


			if (turnTime < 0)
			{
				start = false;
			}

		}
    }
}
