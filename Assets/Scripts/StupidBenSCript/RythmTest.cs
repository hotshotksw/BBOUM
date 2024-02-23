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

    [SerializeField] float turnTime = 4.0f;

    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Deranged ben code
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !start)
        {
            start = true;
        }

        if(turnTime < 0)
        {
            start = false;
        }
        if (start)
        {

        }
    }


}
