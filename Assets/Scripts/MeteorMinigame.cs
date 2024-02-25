using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMinigame : MonoBehaviour
{
    [SerializeField] FloatVariable strength;
    [SerializeField] FloatVariable stamina;
    [SerializeField] FloatVariable health;
    [SerializeField] FloatVariable friendship;
    [SerializeField] int maxlevelpower;

    [SerializeField] float powerlevel;
	[SerializeField] float playerMotion;

    [SerializeField] float desiredMotion;
    [SerializeField] float motion;

	[SerializeField] float movingPower;

    [SerializeField] float position;

    [SerializeField] bool friendshipActive;
    [SerializeField] float frienshipPower;

    [SerializeField] Transform winpos;
    [SerializeField] Transform losepos;

    [SerializeField] float speedmod = 0.1f;

    [SerializeField] VoidEvent winEvent;
    [SerializeField] VoidEvent loseEvent;
    [SerializeField] FloatEvent bounceEvent;

    // Start is called before the first frame update
    void OnEnable()
    {
        powerlevel = 1;
        powerlevel += (Mathf.Min(strength.value, 40)/40) * maxlevelpower;
        powerlevel += (Mathf.Min(stamina.value, 40) / 40) * maxlevelpower;
        powerlevel += (Mathf.Min(health.value, 40) / 40) * maxlevelpower;
        powerlevel += (Mathf.Min(friendship.value, 40) / 40) * maxlevelpower;
        if (friendship.value >= 40)
        {
            friendshipActive = true;
        }

        position = 40;

        desiredMotion = 200 + (powerlevel/2);
        motion = desiredMotion * (powerlevel/100);
        speedmod = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (position < 100 && position > 0)
        {
            speedmod = Mathf.Lerp(speedmod, 1, 0.05f * Time.deltaTime);

			transform.position = Vector3.Lerp(winpos.position, losepos.position, position * 0.01f);

			position += movingPower * Time.deltaTime * speedmod;

			movingPower = motion - playerMotion;

            motion = Mathf.Lerp(motion, desiredMotion, 0.75f * Time.deltaTime);

            playerMotion = Mathf.Lerp(playerMotion, 0, (playerMotion/motion) * Time.deltaTime);
			if (Input.GetKeyDown(KeyCode.Space))
			{
				playerMotion += powerlevel;
				bounceEvent.RaiseEvent(0.15f + Mathf.Abs(-0.5f + 1f * (position / 100f)));
			}

			if (position > 90f && friendshipActive)
			{
                motion = playerMotion;
				playerMotion += frienshipPower;
				powerlevel *= 1.5f;
				friendshipActive = false;
			}

			if (position > 98f)
			{
                position = 101f;
                loseEvent.RaiseEvent();
			}

			if (position < 2f)
			{
                position = -1f;
                winEvent.RaiseEvent();
			}
		}
    }
}
