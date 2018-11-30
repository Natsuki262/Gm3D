using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject explosion;                   //Explosionプレハブ
    GameObject bullet;                      //Bulletプレハブ
    GameObject shoteffect;                  //ShotEffectプレハブ

    int timer;                          //弾発射時間

    private EnemyManager em;

    // Use this for initialization
    void Start () {
        //ExplosionプレハブをGameObject型で取得
        explosion = (GameObject)Resources.Load("Explosion");
        //BulletプレハブをGameObject型で取得
        bullet = (GameObject)Resources.Load("Bullet1");
        //ShotEffectプレハブをGameObject型で取得
        shoteffect = (GameObject)Resources.Load("ShotEffect");

        timer = 0;

        em = GameObject.Find("GameManager").GetComponent<EnemyManager>();
    }
	
	// Update is called once per frame
	void Update () {
        //時間をプラス(1秒60カウント)
        timer++;
        //2.5秒ごとに弾を出す
        if(timer >= 150)
        {
            //Bulletプレハブを元に、インスタンスを生成、
            Instantiate(bullet, new Vector3(0.0f, 1.5f, 0.0f), new Quaternion(0, 180, 0, 0));
            //ShotEffectプレハブを元に、インスタンスを生成、
            Instantiate(shoteffect, new Vector3(0.0f, 1.5f, 0.0f), Quaternion.identity);
            timer = 0;
        }
	}

    private void OnCollisionEnter(Collision c)
    {
        //Exprosionプレハブを元に、インスタンスを生成、
        Instantiate(explosion, transform.position, Quaternion.identity);
        //敵の再出現設定
        em.EnemyRespawn();
        //敵を消す
        Destroy(gameObject);
    }
}
