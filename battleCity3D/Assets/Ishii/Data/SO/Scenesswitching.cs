using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ボタンを使用するためUIとSceneManagerを使用ためSceneManagementを追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenesswitching : MonoBehaviour {
    // ボタンをクリックするとBattleSceneに移動します
    public void ButtonClicked1()
    {
        SceneManager.LoadScene("PauseScene");
    
    }
    public void ButtonClicked2()
    {
        SceneManager.LoadScene("TitleScene");

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}