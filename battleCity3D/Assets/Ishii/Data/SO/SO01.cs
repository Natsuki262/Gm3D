using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SO01 : MonoBehaviour {


    public GameObject effectPrefab;
    public AudioClip damageSound;
    public AudioClip destroySound;
    public int playerHP;
    private Slider playerHPSlider;

    // ★（追加）
    // 配列の定義（「複数のデータ」を入れることのできる「仕切り」付きの箱を作る）
    public GameObject[] playerIcons;

    // ★（追加）
    // プレーヤーが破壊された回数のデータを入れる箱
    public int destroyCount = 0;

    void Start()
    {
        playerHPSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();
        playerHPSlider.maxValue = playerHP;
        playerHPSlider.value = playerHP;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyMissile"))
        {

            playerHP -= 1;
            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);

            playerHPSlider.value = playerHP;

            Destroy(other.gameObject);

            if (playerHP == 0)
            {

                // ★（追加）
                // HPが０になったら破壊された回数を１つ増加させる。
                destroyCount += 1;

                // ★（追加）
                // 命令ブロック（メソッド）を呼び出す。
                UpdatePlayerIcons();

                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity) as GameObject;
                Destroy(effect, 1.0f);
                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
                this.gameObject.SetActive(false);
            }
        }
    }

    // ★（追加）
    // プレーヤーの残機数を表示する命令ブロック（メソッド）
    void UpdatePlayerIcons()
    {

        // for文（繰り返し文）・・・まずは基本形を覚えましょう！
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (destroyCount <= i)
                playerIcons[i].SetActive(true);
            else
                playerIcons[i].SetActive(false);
        }
    }
}
