using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kariPlayer : MonoBehaviour
{
    Vector3 position;
    float speed = 0.3f;

	// Use this for initialization
	void Start ()
    {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.RightArrow))
        {
            position.x += speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= speed;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            position.z += speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            position.z -= speed;
        }

        transform.position = position;
    }
}
