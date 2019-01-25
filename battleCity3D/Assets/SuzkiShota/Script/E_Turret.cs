using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Turret : MonoBehaviour
{
    const int DEFAULT_X = 270;

    [SerializeField]
    private GameObject target; //ターゲット(プレイヤー)

    Transform myPosition;  //自身のtransform情報

    float step;
    float speed;  //回転速度

    bool outFlg;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.Find("pz4_II");

        myPosition = transform;

        step = 0;
        speed = 0.01f;

        outFlg = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(outFlg == true)
        {
            step += speed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(270, 0, 0), step);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //プレイヤーが一定範囲内に近づいたら砲台をプレイヤーに向けて回転
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("in");

            outFlg = false;

            step += speed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(myPosition.rotation, 
                Quaternion.LookRotation(target.transform.position - myPosition.position).normalized, step);

            //余計な縦回転を制御する
            if((int)transform.rotation.eulerAngles.x != DEFAULT_X)
            {
                transform.rotation = Quaternion.Euler(DEFAULT_X, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }     
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //プレイヤーが範囲内から出たら正面に向き直る
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("out");

            outFlg = true;
        }
    }
}
