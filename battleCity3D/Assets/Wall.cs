using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    GameObject wallbreak;                //wallbreakプレハブ

    // Use this for initialization
    void Start () {
        //WallBreakプレハブをGameObject型で取得
        //wallbreak = (GameObject)Resources.Load("WallBreak");
        wallbreak = (GameObject)Resources.Load("Explosion_Wall");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision c)
    {
        //WallBreakプレハブを元に、インスタンスを生成、
        Instantiate(wallbreak, transform.position, Quaternion.identity);
        //壁を消す
        Destroy(gameObject);
    }
}
