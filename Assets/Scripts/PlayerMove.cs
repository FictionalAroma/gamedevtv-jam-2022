using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1f; // Player Movespeed Multiplier
    
    Rigidbody playerRB; //Bit of the player that's moved
    private Animator catAnimator; //Telling the animator to do it's job
    public GameObject character;


    void Start() //Calling the components
    {
        catAnimator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
    }

    void Update () {
		
		if (Input.GetKey(KeyCode.RightArrow))
        {
			transform.position += Vector3.right * playerSpeed * Time.deltaTime;
            catAnimator.SetBool("IsWalking", true);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
        {
			transform.position += Vector3.left* playerSpeed * Time.deltaTime;
            catAnimator.SetBool("IsWalking", true);
		}
		if (Input.GetKey(KeyCode.UpArrow))
        {
			transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
            catAnimator.SetBool("IsWalking", true);
		}
		if (Input.GetKey(KeyCode.DownArrow))
        {
			transform.position += Vector3.back* playerSpeed * Time.deltaTime;
            catAnimator.SetBool("IsWalking", true);
		}
        else
        catAnimator.SetBool("IsWalking", false);
        {

        }
	}
}
