using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1f; // Player Movespeed Multiplier
    
    Rigidbody playerRB; //Bit of the player that's moved
    private Animator catAnimator; //Telling the animator to do it's job
    public GameObject character;
    Vector3 lastPosition = Vector3.zero; // for tracking Cat Speed
    float speed = 0f;


    void Start() //Calling the components
    {
        catAnimator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
    }

    void Update () 
    {
        CatMove();
        FlipCat();
	}

    void CatMove()
    {
		
        if (Input.GetKey(KeyCode.RightArrow))
        {
			transform.position += Vector3.right * playerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
        {
			transform.position += Vector3.left* playerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
        {
			transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
        {
			transform.position += Vector3.back* playerSpeed * Time.deltaTime;
		}


    }

    void FixedUpdate() 
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
                
        if(speed > 0)
        {
            catAnimator.SetBool("IsWalking", true);
        }
        else
        {
            catAnimator.SetBool("IsWalking", false);
        }
    }

    void FlipCat()
    {
       // bool catHasHorizontalSpeed = Mathf.Abs(playerRB.velocity.x) > Mathf.Epsilon;
       // if (catHasHorizontalSpeed)
       // {
        transform.localScale = new Vector3 (Mathf.Sign(playerRB.velocity.x), 1f);
       // Debug.Log ("Sprite Flipped");
       // }
    }
}
