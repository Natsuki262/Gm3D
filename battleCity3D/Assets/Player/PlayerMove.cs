using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour

{
    Rigidbody rb;
    Vector3 playerPosition;
    [SerializeField]
    private float playerTurnSpeed;
    [SerializeField]
    private float playerSpeed;
    private float playerMoveAround;
    private float playerTurn;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        playerPosition = rb.position;

        
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerMoveAround = Input.GetAxis("Vertical");
        playerTurn = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        P_Move();
        Turn();
    }
    void P_Move()
    {
        Vector3 movement = transform.forward * playerMoveAround * playerSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

    }
    private void Turn()
    {
        float turn = playerTurn * playerTurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="E_Bullet")
        {
            Debug.Log("<color=red>EnemybulletHIT</color>");
        }
    }

}
