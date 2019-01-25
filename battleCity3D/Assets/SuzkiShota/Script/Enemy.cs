/*********************************************
  敵戦車を処理するプログラム
**********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //定数
    const int DOWN  = 1;  //後
    const int UP    = 2;  //前
    const int LEFT  = 3;  //左
    const int RIGHT = 4;  //右

    const float MAX_X = 86.5f;   //最大座標値(x軸)
    const float MIN_X = 0.05f;  //最小座標値(x軸)
    const float MAX_Z = 54.0f;   //最大座標値(z軸)
    const float MIN_Z = -6.0f;  //最小座標値(z軸)

    const int HP_MAX = 2;  //体力(最大値)

    int hp; //体力

    [SerializeField]GameObject emManager;  //EnemyManager

    [SerializeField]GameObject symbol;  //シンボル(プレイヤー側の基地)
    Vector3 symbolPos;                  //シンボルの位置

    Rigidbody rb;      //Rigidbody取得用
    Vector3 position;  //位置
    float speed;       //移動速度
    float turnSpeed;   //回転速度計算用
    float step;        //回転速度

    public bool bulletFlg;   //弾発射フラグ
    [SerializeField]bool hitFlg;  //衝突フラグ

    [SerializeField]int vector;     //移動方向( 0：停止　1：前　2：後　3：右　4：左 )
    int before;                     //直前の向き
    [SerializeField]int rotVector;  //回転用方向
    int vectorSelect;               //方向転換時の確立操作用変数

    [SerializeField]float endTime; //カウント終了時間
    [SerializeField]float elapsedTime;             //カウント経過時間

	// Use this for initialization
	void Start ()
    {
        emManager = GameObject.Find("EnemyManager");
        symbol = GameObject.Find("symbol");

        symbolPos = symbol.transform.position;

        rb = GetComponent<Rigidbody>();
        position = rb.position;
        speed = 0.1f;
        turnSpeed = 60.0f;
        vector = 1;
        rotVector = 0;

        bulletFlg = true;
        hitFlg = false;
        
        endTime = Random.Range(3.0f, 15.0f);
        elapsedTime = 0.0f;

        hp = HP_MAX;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //経過時間取得
        elapsedTime += Time.deltaTime;

        //移動
        EnemyMove();
        
        //弾発射の停止
        if(elapsedTime >= (endTime - 1.0f))
        {
            bulletFlg = false;
        }
        //方向転換
        if (elapsedTime >= endTime)
        {
            EnemyVectorChenge();
            EnemyRotation();            
        } 
           	
	}

    //----------------------------
    // 敵戦車を移動させる
    //----------------------------
    void EnemyMove()
    {
        switch (vector)
        {
            case DOWN:
                position -= new Vector3(0.0f, 0.0f, speed);  //前
                rb.rotation = Quaternion.AngleAxis(180.0f, Vector3.up);
                break;

            case UP:
                position += new Vector3(0.0f, 0.0f, speed);  //後
                rb.rotation = Quaternion.AngleAxis(0.0f, Vector3.up);
                break;

            case LEFT:
                position -= new Vector3(speed, 0.0f, 0.0f);  //左
                rb.rotation = Quaternion.AngleAxis(-90.0f, Vector3.up);
                break;

            case RIGHT:
                position += new Vector3(speed, 0.0f, 0.0f);  //右
                rb.rotation = Quaternion.AngleAxis(90.0f, Vector3.up);
                break;
        }

        rb.position = new Vector3(Mathf.Clamp(position.x, MIN_X, MAX_X), 0, Mathf.Clamp(position.z, MIN_Z, MAX_Z));
        //rb.position = position;
    }


    //---------------------------------
    // 方向転換
    //---------------------------------
    void EnemyVectorChenge()
    {
        before = vector;
        vector = 0;

        if (rotVector == 0)
        {
            //基本的にシンボルを目指す様に動かす
            vectorSelect = Random.Range(0, 100);

            //壁際にいる場合は直前と同じ方向を向かない
            if(hitFlg == true)
            {
                do
                {
                    rotVector = Random.Range(1, 5);
                }
                while (before == rotVector);
            }
            else if(hitFlg == false)
            {
                //敵戦車がシンボルより左側にいる場合
                if (rb.position.x < symbolPos.x)
                {
                    if (vectorSelect >= 0 && vectorSelect <= 35)
                    {
                        rotVector = DOWN;
                    }
                    else if (vectorSelect > 35 && vectorSelect <= 60)
                    {
                        rotVector = UP;
                    }
                    else if (vectorSelect > 60 && vectorSelect <= 70)
                    {
                        rotVector = LEFT;
                    }
                    else if (vectorSelect > 70 && vectorSelect < 100)
                    {
                        rotVector = RIGHT;
                    }
                }
                //敵戦車がシンボルより右側にいる場合
                else if (rb.position.x > symbolPos.x)
                {
                    if (vectorSelect >= 0 && vectorSelect <= 35)
                    {
                        rotVector = DOWN;
                    }
                    else if (vectorSelect > 35 && vectorSelect <= 60)
                    {
                        rotVector = UP;
                    }
                    else if (vectorSelect > 60 && vectorSelect <= 90)
                    {
                        rotVector = LEFT;
                    }
                    else if (vectorSelect > 90 && vectorSelect < 100)
                    {
                        rotVector = RIGHT;
                    }
                }
                //敵戦車とシンボルのｘ軸が同じの場合
                else if (rb.position.x == symbolPos.x)
                {
                    rotVector = Random.Range(1, 5);
                }
            }
            
        }

    }


    //-------------------------
    // 回転
    //-------------------------
    void EnemyRotation()
    {
        step = turnSpeed * Time.deltaTime;

        switch(rotVector)
        {
            case DOWN:
                rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, Quaternion.Euler(0, 180, 0), step));
                if ((int)transform.localEulerAngles.y == 180) TimeResrt();
                break;
            case UP:
                rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, Quaternion.Euler(0, 0, 0), step));
                if ((int)transform.localEulerAngles.y == 0) TimeResrt();
                break;
            case LEFT:
                rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, Quaternion.Euler(0, -90, 0), step));
                if ((int)transform.localEulerAngles.y == 270) TimeResrt();
                break;
            case RIGHT:
                rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, Quaternion.Euler(0, 90, 0), step));
                if ((int)transform.localEulerAngles.y == 90) TimeResrt();
                break;
        }
    }

    void TimeResrt()
    {
        vector = rotVector;
        rotVector = 0;
        bulletFlg = true;

        endTime = Random.Range(3.0f, 15.0f);
        elapsedTime = 0.0f;
    }

    //------------------------
    // 衝突判定
    //------------------------
    private void OnCollisionEnter(Collision collision)
    {
        //壁または敵戦車同士が当たったら方向転換
        if (collision.gameObject.tag == "box" || collision.gameObject.tag == "Enemy")
        {
            if (hitFlg == false)
            {
                hitFlg = true;
                elapsedTime = endTime;
            }

        }
        //プレイヤーの弾に当たった時、自身を消去する
        if (collision.gameObject.tag == "BulletFast")
        {
            if (hp > 0)
            {
                hp--;
                Debug.Log("HIT!");
            }
            else if (hp <= 0)
            {
                emManager.GetComponent<EnemyManager>().nowEntry--;
                Destroy(gameObject);
            }

        }
        else if(collision.gameObject.tag == "BulletSlow")
        {
            emManager.GetComponent<EnemyManager>().nowEntry--;
            emManager.GetComponent<EnemyManager>().remEnemy--;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "box" || other.gameObject.tag == "Enemy")
        {
            if (hitFlg == true)
            {
                hitFlg = false;
            }
        }
        
    }

}
