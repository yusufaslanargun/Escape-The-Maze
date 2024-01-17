using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class MoveController : MonoBehaviour
{
    /* Player Properties */
    [Header("Player Properties")]
    [SerializeField] float speed = 4f;
    [SerializeField] int healthPoints = 100;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] string username;
    [SerializeField] Text deathMessage;

    /* General Values For Game */
    [Header("General Values")]
    [SerializeField] float gravity = -20f;
    [SerializeField] float mouseSensitivity = 100f;   

    /* Layer for ground */
    [Header("Layer")]
    [SerializeField] LayerMask groundLayer;

    /* variables and objects for utility */
    float rotationX;
    float rotationY;
    bool isGrounded;
    Vector3 velocity;
    Transform groundCheck;
    PlayerInputsManager input;
    CharacterController controller;
    void Start()
    {
        input = GetComponent<PlayerInputsManager>();
        controller = GetComponent<CharacterController>();
        groundCheck = GameObject.Find("CheckGround").transform;
    }

    void Update()
    {
        Vector3 moveInputs = Mathf.Clamp(input.move.x, -1, 1) * transform.right + Mathf.Clamp(input.move.y, -1, 1) * transform.forward;
        Vector3 moveVelocity = speed * Time.deltaTime * moveInputs;

        controller.Move(moveVelocity);

        JumpAndGravity();
        MouseLook();
    }

    void JumpAndGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, .2f, groundLayer);
        if (isGrounded)
        {
            if (input.jump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
                input.jump = false;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            if (input.jump)
            {
                input.jump = false;
            }
        }
        controller.Move(velocity * Time.deltaTime);
    }
    void MouseLook()
    {
        if (Touchscreen.current.primaryTouch.isInProgress)
        {
            if (Touchscreen.current.touches[0].position.ReadValue().x < 400)
                return;

            Vector2 touchDelta = Touchscreen.current.primaryTouch.delta.value;
            rotationX -= touchDelta.y * mouseSensitivity * Time.deltaTime;
            rotationY += touchDelta.x * mouseSensitivity * Time.deltaTime;


            rotationX = Mathf.Clamp(rotationX, -90, 90);

            transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }


    public void TakeDamage(int damageTaken, string damageDealerTag)
    {
        healthPoints -= damageTaken;
        if (healthPoints <= 0)
        {
            Death(damageDealerTag);
        }
    }

    public void Death(string killerTag)
    {
        speed = 0;
        if (killerTag == "Laser")
        {
            deathMessage.text = "" + username + " struggled through laser.";
        }
        else if (killerTag == "Skeleton")
        {
            deathMessage.text = "" + username + " lost the duel with Skeleton.";
        }
        FindObjectOfType<GameManager>().GameOver();
    }
}
