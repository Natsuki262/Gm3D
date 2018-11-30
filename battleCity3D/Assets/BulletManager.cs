using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    GameObject bullet;                //Bulletプレハブ
    GameObject shoteffect;                  //ShotEffectプレハブ

    float xx;                         //x座標
    float zz;                         //z座標
    
    // Use this for initialization
    void Start () {
        //BulletプレハブをGameObject型で取得
        bullet = (GameObject)Resources.Load("Bullet1");
        //ShotEffectプレハブをGameObject型で取得
        shoteffect = (GameObject)Resources.Load("ShotEffect");
    }
	
	// Update is called once per frame
	void Update () {

        //左移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-0.1f, 0, 0);
            if(this.transform.position.x <= -4.5f)
            {
                this.transform.Translate(0.1f, 0, 0);
            }
        }
        //右移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(0.1f, 0, 0);
            if (this.transform.position.x >= 4.5f)
            {
                this.transform.Translate(-0.1f, 0, 0);
            }
        }
        //スペースキーで弾発射
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //座標の取得
            xx = this.transform.position.x;
            zz = this.transform.position.z + 0.7f;
            //Bulletプレハブを元に、インスタンスを生成、
            Instantiate(bullet, new Vector3(xx, 1.5f, zz), Quaternion.identity);
            //ShotEffectプレハブを元に、インスタンスを生成、
            Instantiate(shoteffect, new Vector3(xx, 1.5f, zz), Quaternion.identity);
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Bulletプレハブを元に、インスタンスを生成、
            Instantiate(bullet, new Vector3(-4.0f,1.5f,-10.0f), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            //Bulletプレハブを元に、インスタンスを生成、
            Instantiate(bullet, new Vector3(0f, 1.5f, -10.0f), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Bulletプレハブを元に、インスタンスを生成、
            Instantiate(bullet, new Vector3(4.0f, 1.5f, -10.0f), Quaternion.identity);
        }
    }
}
