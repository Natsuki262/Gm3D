using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aa : MonoBehaviour {
    [SerializeField]
    private GameObject[] tama;
    int a;
	// Use this for initialization
	void Start () {
        a = 0;
	}
	
	// Update is called once per frame
	void Update () {
        shoot();
	}
   
    void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(tama[0], this.transform.position, Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(tama[1], this.transform.position, Quaternion.identity);
        }
    }
}
