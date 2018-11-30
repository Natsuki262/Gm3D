using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRain : MonoBehaviour {


    // Use this for initialization
    void Start () {
        //1秒後に消す
        Invoke("FireDestroy", 1.0f);
    }

    void FireDestroy()
    {
        Destroy(gameObject);
    }
}
