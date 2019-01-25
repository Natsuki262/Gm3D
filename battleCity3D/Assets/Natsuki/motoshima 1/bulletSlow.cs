using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSlow : MonoBehaviour
{
    const float MAX_X = 86.5f;   //最大座標値(x軸)
    const float MIN_X = 0.05f;  //最小座標値(x軸)
    const float MAX_Z = 54.0f;   //最大座標値(z軸)
    const float MIN_Z = -6.0f;  //最小座標値(z軸)

    [SerializeField]
    private float bulletSpeedSlow;
    GameObject shootingPosition;
    ShootPlace prayerShoot;
    // Use this for initialization
    void Start()
    {
        shootingPosition = GameObject.Find(" Shooting position");
        Debug.Log("find");
        prayerShoot = shootingPosition.GetComponent<ShootPlace>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeedSlow;

        if(transform.position.x < MIN_X ||
            transform.position.x > MAX_X ||
            transform.position.z < MIN_Z ||
            transform.position.z > MAX_Z)
        {
            BulletDestroy();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "box" ||
            collision.gameObject.tag == "Enemy")
        {
            BulletDestroy();            
        }
    }

    void BulletDestroy()
    {
        Destroy(gameObject);
        Debug.Log("Destor");
        prayerShoot.bulletFlg = false;
    }
}
