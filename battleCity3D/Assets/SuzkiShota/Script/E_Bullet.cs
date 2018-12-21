/***********************************
  敵の弾を処理するプログラム
************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bullet : MonoBehaviour
{
    Rigidbody rb;  //Rigidbody取得用

    [SerializeField]
    float speed;   //弾のスピード

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        speed = 1.5f;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //rb.AddForce(transform.forward * speed);
        rb.position += transform.forward * speed;
	}


    //-------------------------
    // 弾の消去
    //-------------------------
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "box")
        {
            Destroy(gameObject);
        }
    }
}
