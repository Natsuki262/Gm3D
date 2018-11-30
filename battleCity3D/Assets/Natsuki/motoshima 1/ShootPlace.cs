using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlace : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tama;
    int a;
    public bool bulletFlg = false;//弾丸が発射中かどうか
                                  // Use this for initialization
    void Start()
    {
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if(Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1))
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletFlg == false)
            {
                Instantiate(tama[0], this.transform.position, transform.rotation);
                bulletFlg = true;
            }
        }

        if (Input.GetMouseButtonDown(1))

        {
            if (bulletFlg == false)
            {

                Instantiate(tama[1], this.transform.position, transform.rotation);
                bulletFlg = true;
            }
        }
        
    }
}
