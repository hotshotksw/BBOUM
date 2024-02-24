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
        public float setOffTime; // time till the beat  plays
        public AudioClip audio; // the beat sound that plays
        public string stringtopass; // string that is passed into the beat event for animator to use
        public float beatStrength; // string that is passed into the beat event for animator to use
    }
	public AudioClip Metronome; // sound that happens when every beat should be played
    public StringEvent beatEvent; // event that happens when a beat is hit by the player. signifies a change in animation
	public FloatEvent beatFloatEvent; // event that happens when a beat happens. does not matter if the player hits it on time.
	public FloatEvent newBeatEvent; // event that happens when a beat happens. does not matter if the player hits it on time.

    [SerializeField] List<Beat> beats; // list of repeating beats
    [SerializeField] AudioSource audioSource;
    [SerializeField] float InitialTime = 15.0f; // initial time spent in the minigame
    float turnTime; // the time that is spent in the minigame
    [SerializeField] float beatTime = 0; // time till the next beat plays
    [SerializeField] int current = 0; // current beat to be played
    [SerializeField, Range(0.1f, 1f)] float speedMod = 1; // modifier for beat speed if we do speed up mechanic
    public bool start = false;
    [SerializeField] private float totalLevel = 0; // amount of level given to player for stat

    [SerializeField] private int beatActivated; // if the beat is activated it is 
	private bool earlyBeat;

    public FloatVariable rewardLevels; // stat that is rewards with level

    public TMP_Text text;// replace with dedicated ranking thing

    public void Activate()
    {
		turnTime = InitialTime;
		start = true;
        totalLevel = 0;
		current = 0;
		beatTime = beats[current].setOffTime;
	}

    // Deranged ben code
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !start)
        {
            Activate();
        }

        if (start)
        {
            turnTime -= Time.deltaTime;
            beatTime -= Time.deltaTime;

			if (turnTime <= 0)
			{
				start = false;
                if (rewardLevels)
                {
                    rewardLevels.value += totalLevel;
                }
			}

			float midpoint = (beats[current].setOffTime * speedMod) * 0.5f;

			if (Input.GetMouseButtonDown(0))
			{
                float test = 0;

				if (beatActivated == 0)
				{
					if (midpoint - beatTime < 0)
					{
						test = MathF.Abs(midpoint - beatTime) / midpoint;

						beatActivated = 1;

						int prev = current - 1;
						if (prev < 0)
						{
							prev = beats.Count - 1;
						}
						beatEvent.RaiseEvent(beats[prev].stringtopass);

						audioSource.PlayOneShot(beats[prev].audio);
					}
					else if (midpoint - beatTime > 0)
					{
						beatActivated = 2;
						test = Mathf.Abs((beatTime / midpoint) - 1);

						beatEvent.RaiseEvent(beats[current].stringtopass);
						audioSource.PlayOneShot(beats[current].audio);
					}
					test = (2 * test) - 1;

					string howgood = "Bogus";

					if (test > 0.9f)
					{
						howgood = "Ultimate!!!";
					}
					else if (test > 0.5f)
					{
						howgood = "Nice Form!!";
					}
					else if (test > 0.1f)
					{
						howgood = "Needs Work!";
					} else
					{

					}

					text.text = beatTime + " / " + (beats[current].setOffTime * speedMod) + "\n" + howgood + ": " + test;
					totalLevel += test;
					if (totalLevel < 0)
					{
						totalLevel = 0;
					}
				}
			}

			if (beatTime <= 0)
            {
				if (beatActivated == 2)
				{
					beatActivated = 1;
				}
				earlyBeat = false;
				beatFloatEvent.RaiseEvent(beats[current].beatStrength);
				audioSource.PlayOneShot(Metronome);
				current++;
                if (current >= beats.Count)
                {
                    current = 0;
                }
				beatTime = beats[current].setOffTime * speedMod;
			}

			if (beatTime < midpoint && beatActivated == 1)
			{
				beatActivated = 0;
			}

			if (beatTime < midpoint && !earlyBeat)
			{
				earlyBeat = true;
				newBeatEvent.RaiseEvent(beatTime * 2);
			}
		}
    }
}
