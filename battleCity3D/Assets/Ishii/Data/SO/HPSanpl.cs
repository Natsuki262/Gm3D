using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSanpl : MonoBehaviour
{ 
    Slider slider;

    float hp;

    [SerializeField]
    public bool dFlg;

    void Start()
    {
        // スライダーを取得する
        slider = GameObject.Find("Slider").GetComponent<Slider>();

        hp = 1;

        dFlg = false;
    }

    
    void Update()
    {
        // HPゲージに値を設定
        slider.value = hp;

        if(dFlg == true)
        {
            hp -= 0.1f;
            dFlg = false;
        }
    }
}
