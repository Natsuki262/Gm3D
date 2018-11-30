using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    int SpawnTimer;                     //敵が出てくるまでの時間(1秒60カウント)

    GameObject spawnlight;              //SpownLightプレハブ

    // Use this for initialization
    void Start () {
        //最初は1秒で登場する
        SpawnTimer = 60;
        //SpawnLightプレハブをGameObject型で取得
        spawnlight = (GameObject)Resources.Load("SpawnLight");
    }
	
	// Update is called once per frame
	void Update () {

        //カウントが残っている
        if(SpawnTimer > 0)
        {
            //カウントを減らす
            SpawnTimer--;
            //カウントが0になった
            if (SpawnTimer == 0)
            {
                //SpawnLightプレハブを元に、インスタンスを生成、
                Instantiate(spawnlight, new Vector3(0, 1.5f, 2.0f), Quaternion.identity);
            }
        }
    }

    //敵の再出現の時間設定(外部から読み込む)
    public void EnemyRespawn()
    {
        //再出現時間を3秒に設定
        SpawnTimer = 180;
    }

}
