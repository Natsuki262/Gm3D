using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTurn: MonoBehaviour {

    // カメラオブジェクトを格納する変数
    [SerializeField]
    private GameObject mainCamera;
    // カメラの回転速度を格納する変数
    [SerializeField]
    private Vector2 rotationSpeed;
    // マウス移動方向とカメラ回転方向を反転する判定フラグ
    private bool reverse;
    // マウス座標を格納する変数
    private Vector2 lastMousePosition;
    // カメラの角度を格納する変数（初期値に0,0を代入）
    private Vector2 newAngle = new Vector2(-90, 0);

    void Start()
    {
        newAngle = mainCamera.transform.localEulerAngles;
        lastMousePosition = Input.mousePosition;
    }
    // ゲーム実行中の繰り返し処理
    void Update()
    {
        CameraMove();
        if (newAngle.x > -90f)
        {
            newAngle.x = -90f;
        }
        if (newAngle.x < -100f)
        {
            newAngle.x = -100f;
        }
    }
    void CameraMove()
    {

        // Y軸の回転：マウスドラッグ方向に視点回転
        // マウスの水平移動値に変数"rotationSpeed"を掛ける
        //（クリック時の座標とマウス座標の現在値の差分値）
        newAngle.y -= (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y;
        // X軸の回転：マウスドラッグ方向に視点回転
        // マウスの垂直移動値に変数"rotationSpeed"を掛ける
        //（クリック時の座標とマウス座標の現在値の差分値）
        newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x;
        // "newAngle"の角度をカメラ角度に格納
        mainCamera.transform.localEulerAngles = newAngle;
        // マウス座標を変数"lastMousePosition"に格納
        lastMousePosition = Input.mousePosition;

    }
}
