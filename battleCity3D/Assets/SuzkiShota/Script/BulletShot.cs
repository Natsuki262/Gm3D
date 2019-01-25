/*********************************
  敵の弾を発射するプログラム
**********************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject eBullet; //発射する弾
    public GameObject tank;    //戦車オブジェクト

    [SerializeField]
    GameObject turret;  //砲台の向き

    Enemy enemyScript;

    Quaternion turretRot;

    float endTime;      //カウント終了時間
    float elapsedTime;  //カウント経過時間

    // Use this for initialization
    void Start ()
    {
        endTime = 2.5f;

        enemyScript = tank.GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= endTime && enemyScript.bulletFlg == true)
        {
            turretRot = Quaternion.Euler(new Vector3(0, transform.rotation.y, transform.rotation.z));
            Instantiate(eBullet, transform.position, turretRot);

            elapsedTime = 0.0f;
        }
    }
}
