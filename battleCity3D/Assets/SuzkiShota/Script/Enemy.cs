/*********************************************
  敵戦車を処理するプログラム
**********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //定数
    const int DOWN  = 1;
    const int UP    = 2;
    const int LEFT  = 3;
    const int RIGHT = 4;


    public GameObject symbol;  //シンボル(プレイヤー側の基地)
    Vector3 symbolPos;         //シンボルの位置

    public GameObject wall;

    Rigidbody rb;      //Rigidbody取得用
    Vector3 position;  //位置
    float speed;       //移動速度
    float turnSpeed;   //回転速度
    float step;

    public bool bulletFlg;  //弾発射フラグ

    [SerializeField]
    int vector;        //移動方向( 0：停止　1：前　2：後　3：右　4：左 )
    int before;        //直前の向き
    int beforeR;
    [SerializeField]
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
        turnSpeed = 120.0f;
        vector = 1;
        rotVector = 0;

        bulletFlg = true;

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
            vector = 0;
            bulletFlg = false;
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
       
        rb.position = position;  //更新
    }


    //---------------------------------
    // 方向転換
    //---------------------------------
    void EnemyVectorChenge()
    {
        wall.SetActive(false);

        if(rotVector == 0)
        {
            //基本的にシンボルを目指す様に動かす
            vectorSelect = Random.Range(0, 100);
            //敵戦車がシンボルより左側にいる場合
            if (rb.position.x < symbolPos.x)
            {
                if (vectorSelect >= 0 && vectorSelect <= 40)
                {
                    rotVector = DOWN;
                }
                else if (vectorSelect > 40 && vectorSelect <= 60)
                {
                    rotVector = UP;
                }
                else if (vectorSelect > 60 && vectorSelect <= 75)
                {
                    rotVector = LEFT;
                }
                else if (vectorSelect > 75 && vectorSelect < 100)
                {
                    rotVector = RIGHT;
                }
            }
            //敵戦車がシンボルより右側にいる場合
            else if (rb.position.x > symbolPos.x)
            {
                if (vectorSelect >= 0 && vectorSelect <= 40)
                {
                    rotVector = DOWN;
                }
                else if (vectorSelect > 40 && vectorSelect <= 60)
                {
                    rotVector = UP;
                }
                else if (vectorSelect > 60 && vectorSelect <= 85)
                {
                    rotVector = LEFT;
                }
                else if (vectorSelect > 85 && vectorSelect < 100)
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

        wall.SetActive(true);

        endTime = Random.Range(1.0f, 6.0f);
        elapsedTime = 0.0f;
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
                vector = Random.Range(1, 5);

            } while (before == vector);

            
        }
    }
    
}
