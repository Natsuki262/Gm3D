using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// DamageSystem 
public class DamageSystem : MonoBehaviour {

     //最大HP、半端な数にした
    [SerializeField]
    int maxHP = 137;
    //現在のHP
    [SerializeField]
    float currentHP;

    GameObject textObj;
    Text text;
    GameObject hpSystem;
    void Start()
    {
        //TextをGameObjectとして取得する
        textObj = GameObject.Find("Text");
        //HPSystemを取得する
        hpSystem = GameObject.Find("HPSystem");
        Debug.Log(hpSystem);
    }

    void Update()
    {
        //TextのTextコンポーネントにアクセス
        //(int)はfloatを整数で表示するためのもの
        textObj.GetComponent<Text>().text = ((int)currentHP).ToString();

      
        //HPSystemのスクリプトのHPDown関数に2つの数値を送る
        hpSystem.GetComponent<HPSystem>().HPDown(currentHP, maxHP);
    }

    //FixedUpdateは一定に呼ばれるので持続的に使う処理
    void FixedUpdate()
    {
        //currentHPが0以上ならTrue
        if (0 <= currentHP)
        {
            //maxHPから秒数（×10）を引いた数がcurrentHP
            currentHP = maxHP - Time.time * 10;
        }
    }
}
