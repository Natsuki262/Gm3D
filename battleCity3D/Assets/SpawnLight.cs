using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLight : MonoBehaviour {

    GameObject enemy;                //Enemyプレハブ
    GameObject scatter;              //ScatterLightプレハブ

    // Use this for initialization
    void Start()
    {
        //EnemyプレハブをGameObject型で取得
        enemy = (GameObject)Resources.Load("Enemy");
        //ScatterLightプレハブをGameObject型で取得
        scatter = (GameObject)Resources.Load("ScatterLight");

        //1秒後に散っていく光を出して敵を出す
        Invoke("SpownEnemy", 1.0f);
        //2秒後に消す
        Invoke("LightDestroy", 2.0f);
    }

    void SpownEnemy()
    {
        //Enemyプレハブを元に、インスタンスを生成、
        Instantiate(enemy, transform.position, Quaternion.identity);
        //ScatterLightプレハブを元に、インスタンスを生成、
        Instantiate(scatter, transform.position, Quaternion.identity);
    }

    void LightDestroy()
    {
        Destroy(gameObject);
    }
}
