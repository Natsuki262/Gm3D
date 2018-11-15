/*********************************************
  敵戦車を処理するプログラム
**********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject symbol;  //シンボル(プレイヤー側の基地)
    Vector3 symbolPos;         //シンボルの位置

    Rigidbody rb;      //Rigidbody取得用
    Vector3 position;  //位置
    float speed;       //移動速度
    float turnSpeed;   //回転速度
    float step;

    [SerializeField]
    int vector;        //移動方向( 0：停止　1：前　2：後　3：右　4：左 )
    int before;        //直前の向き
    int rotVector;     //回転用方向
    int vectorSelect;  //方向転換時の確立操作用変数

    [SerializeField]
    float endTime;     //カウント終了時間
    float elapsedTime; //カウント経過時間

	// Use this for initialization
	void Start ()
    {
        symbolPos = symbol.transform.position;

        rb = GetComponent<Rigidbody>();
        position = rb.position;
        speed = 0.05f;
        turnSpeed = 2.0f;
        vector = 1;
        rotVector = 0;

        endTime = Random.Range(1.0f, 6.0f);
        elapsedTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //経過時間取得
        elapsedTime += Time.deltaTime;

        //移動
        EnemyMove();

        //方向転換
        if (elapsedTime >= endTime)
        {
            //EnemyVectorChenge();
            vector = 0;
            EnemyRotation();
            endTime = Random.Range(1.0f, 6.0f);
            elapsedTime = 0.0f;
        }
        	
	}

    //----------------------------
    // 敵戦車を移動させる
    //----------------------------
    void EnemyMove()
    {
        switch (vector)
        {
            case 1:
                position -= new Vector3(0.0f, 0.0f, speed);  //前
                rb.rotation = Quaternion.AngleAxis(180.0f, Vector3.up);
                break;

            case 2:
                position += new Vector3(0.0f, 0.0f, speed);  //後
                rb.rotation = Quaternion.AngleAxis(0.0f, Vector3.up);
                break;

            case 3:
                position -= new Vector3(speed, 0.0f, 0.0f);  //左
                rb.rotation = Quaternion.AngleAxis(-90.0f, Vector3.up);
                break;

            case 4:
                position += new Vector3(speed, 0.0f, 0.0f);  //右
                rb.rotation = Quaternion.AngleAxis(90.0f, Vector3.up);
                break;
        }
       
        rb.position = position;  //更新
    }


    //-------------------------
    // 回転
    //-------------------------
    void EnemyRotation()
    {
        if(vector == 0)
        {
            rotVector = 2;

            switch(rotVector)
            {
                case 2:
                    step = turnSpeed * Time.deltaTime;
                    rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), step));
                    if (rb.rotation.y == 0.0f) vector = rotVector;
                    break;
            }

                        
        }
    }

    //---------------------------------
    // 方向転換
    //---------------------------------
    void EnemyVectorChenge()
    {
        //基本的にシンボルを目指す様に動かす
        vectorSelect = Random.Range(0, 100);
        //敵戦車がシンボルより左側にいる場合
        if(rb.position.x < symbolPos.x)
        {
            if(vectorSelect >= 0 && vectorSelect <= 40)
            {
                vector = 1;
            }
            else if (vectorSelect > 40 && vectorSelect <= 60)
            {
                vector = 2;
            }
            else if (vectorSelect > 60 && vectorSelect <= 75)
            {
                vector = 3;
            }
            else if (vectorSelect > 75 && vectorSelect < 100)
            {
                vector = 4;
            }
        }
        //敵戦車がシンボルより右側にいる場合
        else if (rb.position.x > symbolPos.x)
        {
            if (vectorSelect >= 0 && vectorSelect <= 40)
            {
                vector = 1;
            }
            else if (vectorSelect > 40 && vectorSelect <= 60)
            {
                vector = 2;
            }
            else if (vectorSelect > 60 && vectorSelect <= 85)
            {
                vector = 3;
            }
            else if (vectorSelect > 85 && vectorSelect < 100)
            {
                vector = 4;
            }
        }
        //敵戦車とシンボルのｘ軸が同じの場合
        else if(rb.position.x == symbolPos.x)
        {
            vector = Random.Range(1, 5); 
        }

    }


    //------------------------
    // 衝突判定
    //------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Enemy")
        {
            //同じ向きを取らないようにする
            do
            {
                before = vector;
                EnemyVectorChenge();

            } while (before == vector);
        }
    }
    
}
