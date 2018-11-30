using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterLight : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //2秒後に消す
        Invoke("LightDestroy", 2.0f);
    }

    void LightDestroy()
    {
        Destroy(gameObject);
    }
}
