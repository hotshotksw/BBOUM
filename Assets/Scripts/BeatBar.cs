using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BeatBar : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] GameObject hitbar;
    [SerializeField] Transform end;


    public void DoBeat(float time)
    {
        Instantiate(hitbar, transform).TryGetComponent(out BeatOnTheBar botb);
        botb.SetupBeat(start.position, end.position, Vector2.Distance(start.position, end.position) / time);
	}
}
