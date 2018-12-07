/**********************************************
  敵の生成と管理を行うプログラム
***********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    const int MAX_ENEMY = 10;       //フィールド上に出現する敵の最大数
    const float NEXT_TIME = 3.0f;  //敵の出現時間間隔

    [SerializeField]
    GameObject[] entryPos = new GameObject[3];  //出現位置の格納配列

    [SerializeField]
    GameObject[] entryEnemy;  //出現する敵

    int posSelect;         //出現位置選択用（左端から0番、1番・・・）
    public int nowEntry;   //現在出現している敵の数

    [SerializeField]
    float elapsedTime;    //経過時間測定用変数


	// Use this for initialization
	void Start ()
    {
        nowEntry = 0;
        posSelect = 0;
        elapsedTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //経過時間取得
        elapsedTime += Time.deltaTime;

        //フィールド上の敵の総数が最大値を超えたら何もしない
        if(nowEntry >= MAX_ENEMY)
        {
            return;
        }

        //経過時間を過ぎたら敵出現
        if(elapsedTime >= NEXT_TIME)
        {
            EnemyEntry();
        }
	}

    //------------------------------------------
    // 指定位置から敵を出現
    //------------------------------------------
    void EnemyEntry()
    {
        Instantiate(entryEnemy[0], entryPos[posSelect].transform.position, transform.rotation);

        if(posSelect < 2)
        {
            posSelect++;
        }
        else if(posSelect >= 2)
        {
            posSelect = 0;
        }

        nowEntry++;
        elapsedTime = 0.0f;
    }
}
