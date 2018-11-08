/*********************************************
  敵戦車を処理するプログラム
**********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;      //Rigidbody取得用
    Vector3 position;  //位置
    float speed;       //移動速度
    float turnSpeed;   //回転速度

    [SerializeField]
    int vector;        //移動方向( 0：前　1：後　2：右　3：左 )
    int before;        //直前の向き

    [SerializeField]
    float endTime;     //カウント終了時間
    float elapsedTime; //カウント経過時間

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        position = rb.position;
        speed = 0.05f;
        turnSpeed = 2.0f;
        vector = 0;

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
        if(elapsedTime >= endTime)
        {
            vector = Random.Range(0, 4);
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
            case 0:
                position += new Vector3(0.0f, 0.0f, speed);  //前
                rb.rotation = Quaternion.AngleAxis(0.0f, Vector3.up);
                break;

            case 1:
                position -= new Vector3(0.0f, 0.0f, speed);  //後
                rb.rotation = Quaternion.AngleAxis(180.0f, Vector3.up);
                break;

            case 2:
                position += new Vector3(speed, 0.0f, 0.0f);  //右
                rb.rotation = Quaternion.AngleAxis(90.0f, Vector3.up);
                break;

            case 3:
                position -= new Vector3(speed, 0.0f, 0.0f);  //左
                rb.rotation = Quaternion.AngleAxis(-90.0f, Vector3.up);
                break;
        }
       
        rb.position = position;  //更新
    }


    //------------------------
    // 衝突判定
    //------------------------
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            //壁にぶつかった時の方向転換
            switch (vector)
            {
                //前進
                case 0:
                    /*rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turnSpeed, 0));
                    if (rb.rotation.y == 180.0f)
                    {
                        rb.rotation = Quaternion.AngleAxis(180.0f, Vector3.up);
                        vector = 1;
                    }*/
                    
                    break;
　　　　　　　　
               //後退
                case 1:
                    
                    break;

                //右
                case 2:
                    
                    break;

                //左
                case 3:
                   
                    break;
            }

            //同じ向きを取らないようにする
            do
            {
                before = vector;
                vector = Random.Range(0, 4);

            } while (before == vector);
        }
    }

}
