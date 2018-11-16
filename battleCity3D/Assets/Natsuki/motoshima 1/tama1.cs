using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tama1 : MonoBehaviour {
    [SerializeField]
    private GameObject cannonObject;
	// Use this for initialization
	void Start () {
    }   
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * 0.01f;
    }
}
