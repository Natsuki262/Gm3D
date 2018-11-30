using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //2秒後に消す
        Invoke("ExplosionDestroy", 2.0f);
    }

    void ExplosionDestroy()
    {
        Destroy(gameObject);
    }
}
