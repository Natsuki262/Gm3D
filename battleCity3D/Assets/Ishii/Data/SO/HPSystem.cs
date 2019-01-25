using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//HPSystm
public class HPSystem : MonoBehaviour
{

    GameObject image;

    void Start()
    {
        //ImageをGameObjectとして取得
        image = GameObject.Find("Image");
    }

    //()の中身は引数、他のところから数値を得て{}の中で使う
    public void HPDown(float current, int max)
    {
        //ImageというコンポーネントのfillAmountを取得して操作する
        image.GetComponent<Image>().fillAmount = current / max;
    }
}