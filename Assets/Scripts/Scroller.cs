using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{

    [SerializeField] float destinationX; //19.1f default

	[SerializeField] float wrapX; //19.1f default

	void Update()
    {
        transform.position += new Vector3(-3 * Time.deltaTime, 0);

        if (transform.position.x < wrapX)
        {
            transform.position = new Vector3(destinationX, 0);
        }
    }
}
