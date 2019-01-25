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
    GameObject turret;

    [SerializeField]
    GameObject player;

    [SerializeField]
    float speed;   //弾のスピード

    float direction;

    Vector3 v;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        turret = GameObject.Find("ShotPosition");
        player = GameObject.Find("pz4_II");
        speed = 30f;

        direction = GetAtan(player.transform.position, this.transform.position);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //rb.AddForce(turret.transform.forward * speed);

        v.x = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
        v.z = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;

        rb.velocity = v;
	}

    //------------------------------------
    // 自身とプレイヤーとの角度を求める
    //------------------------------------
    float GetAtan(Vector3 player, Vector3 bullet)
    {
        float dx = (player.x - bullet.x);
        float dz = (player.z - bullet.z);

        float rad = Mathf.Atan2(dz, dx);

        return rad * Mathf.Rad2Deg;
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
