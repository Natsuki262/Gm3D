using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFast : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeedfast;
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
        transform.position += transform.forward * bulletSpeedfast;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "box")
        {
            Destroy(gameObject);
            Debug.Log("Destor");
            prayerShoot.bulletFlg = false;

        }
    }
}
