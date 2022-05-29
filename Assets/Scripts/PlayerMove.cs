using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    CharacterController characterController;
    private Animator catAnimator;
    private SpriteRenderer sprite;
    private float timeBeforeCatSit = 0f;

    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpStrength = 5f;
    public float gravity = -5f;

    float speed = 5f;
    bool sprinting = false;
    Vector2 velocity = Vector2.zero;
    Vector2 currentVelocity = Vector2.zero;
    float yVel = 0f;
    float yVelCur = 0f;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        catAnimator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void OnMove(InputValue input)
    {
        velocity = input.Get<Vector2>() * new Vector2(1f, 0.5f); // Stop it looking like the player moves extra fast dur to 45* angle
    }

    void OnSprint(InputValue input)
    {
        sprinting = input.Get<float>() >= 1f;
    }

    void OnJump(InputValue input)
    {
        if (characterController.isGrounded)
            yVel = jumpStrength;
    }

    void Update()
    {
        if (characterController.isGrounded)
            currentVelocity = velocity;

        if (currentVelocity.magnitude > float.Epsilon)
            timeBeforeCatSit = 0.05f;
        else
            timeBeforeCatSit -= Time.deltaTime;

        var yVector = Quaternion.Euler(0, 45f, 0) * new Vector3(0, yVel, 0);
        yVel = Mathf.SmoothDamp(yVel, gravity, ref yVelCur, 0.5f);

        if (sprinting)
            speed = sprintSpeed;
        else
            speed = walkSpeed;

        characterController.Move((new Vector3(currentVelocity.x, 0, currentVelocity.y) + yVector) * speed * Time.deltaTime);

        catAnimator.SetBool("IsWalking", timeBeforeCatSit > 0f);
        if (currentVelocity.magnitude > float.Epsilon)
            FlipCat(currentVelocity);
    }

    void FlipCat(Vector3 movementVector)
    {
        sprite.gameObject.transform.localScale = new Vector3(-Mathf.Sign(movementVector.x), 1f);
    }
}
