using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 0.2f;      //弾の速度
    GameObject fire;                //FireRainプレハブ

    // Use this for initialization
    void Start () {
        //FireRainプレハブをGameObject型で取得
        fire = (GameObject)Resources.Load("FireRain");
    }
	
	// Update is called once per frame
	void Update () {
        //弾を移動
        this.transform.Translate(0, 0, speed);
        //一定座標で弾を消す
        if (transform.position.z > 10.0f || transform.position.z < -10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        //FireRainプレハブを元に、インスタンスを生成、
        Instantiate(fire, transform.position, new Quaternion(0, transform.rotation.y - 180.0f, 0,0));
        Destroy(gameObject);
    }

}
