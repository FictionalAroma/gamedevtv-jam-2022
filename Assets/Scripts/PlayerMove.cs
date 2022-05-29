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
    private SpriteRenderer sprite;
    private float timeBeforeCatSit = 0f;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    void Start() //Calling the components
    {
        catAnimator = GetComponentInChildren<Animator>();
        playerRB = GetComponent<Rigidbody>();

        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update () 
    {
        CatMove();
	}

    void CatMove()
    {
        lastPosition = transform.position;
        bool movementKeyPressed = false;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movementKeyPressed = true;
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementKeyPressed = true;

            transform.position += Vector3.left* playerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
        {
            movementKeyPressed = true;

            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
        {
            movementKeyPressed = true;

            transform.position += Vector3.back* playerSpeed * Time.deltaTime;
		}

        var movementVector = lastPosition - transform.position;
        speed = movementVector.magnitude;
        if (speed > float.Epsilon || movementKeyPressed)
        {
            timeBeforeCatSit = 0.05f;
        }
        else
        {
            timeBeforeCatSit -= Time.deltaTime;
        }

        catAnimator.SetBool(IsWalking, timeBeforeCatSit > 0f);

        if (speed > float.Epsilon)
        {
            FlipCat(movementVector);
        }

    }

    //void FixedUpdate() 
    //{
    //    speed = (transform.position - lastPosition).magnitude;
    //    lastPosition = transform.position;

    //    catAnimator.SetBool("IsWalking", speed > float.Epsilon);
    //}

    void FlipCat(Vector3 movementVector)
    {
        
            sprite.gameObject.transform.localScale = new Vector3(Mathf.Sign(movementVector.x), 1f);
            //Debug.Log("Sprite Flipped");
    }
}
