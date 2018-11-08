/*********************************
  敵の弾を発射するプログラム
**********************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject eBullet; //発射する弾
    public GameObject tank;    //戦車の向き

    float endTime;      //カウント終了時間
    float elapsedTime;  //カウント経過時間

    // Use this for initialization
    void Start ()
    {
        endTime = 1.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= endTime)
        {
            Instantiate(eBullet, transform.position, tank.transform.rotation);

            elapsedTime = 0.0f;
        }
    }
}
