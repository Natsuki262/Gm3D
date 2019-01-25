using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEnemy : MonoBehaviour
{
    const int NUM = 20;

    [SerializeField]
    Text emText;

    [SerializeField]
    GameObject emManager;
    EnemyManager emScript;


	// Use this for initialization
	void Start ()
    {
        emManager = GameObject.Find("EnemyManager");
        emScript = emManager.GetComponent<EnemyManager>();

        emText.text = "残り敵数：" + NUM.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
		emText.text = "残り敵数：" + emScript.remEnemy.ToString();
    }
}
