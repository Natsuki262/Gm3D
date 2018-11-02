/*********************************************
  敵戦車を処理するプログラム
**********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;      //Rigidbody取得用
    Vector3 position;  //位置
    float speed;       //速度
    int vector;        //移動方向

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        position = rb.position;
        speed = 0.05f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        EnemyMove();		
	}

    //----------------------------
    // 敵戦車を移動させる
    //----------------------------
    void EnemyMove()
    {
        position += new Vector3(0.0f, 0.0f, speed);  //値を加算
        rb.position = position;                      //更新
    }
}
