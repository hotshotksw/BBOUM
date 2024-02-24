using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMinigame : MonoBehaviour
{
    [SerializeField] int powerlevel;

    [SerializeField] float desiredMotion;
    [SerializeField] float motion;
    [SerializeField] float position;

    [SerializeField] bool friendship;
    [SerializeField] float frienshipPower;

    [SerializeField] Transform winpos;
    [SerializeField] Transform losepos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(winpos.position, losepos.position, position * 0.01f);

        position += motion * Time.deltaTime;

        float comeback = (desiredMotion - motion);
        if (comeback > 50)
        {
            comeback = 50;
        }

		motion = Mathf.Lerp(motion, desiredMotion, Time.deltaTime * (1 + comeback));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            motion = desiredMotion-powerlevel;
        }

        if (position > 90f && friendship)
        {
            motion = -frienshipPower;
            powerlevel *= 2;
            friendship = false;
        }
    }
}
