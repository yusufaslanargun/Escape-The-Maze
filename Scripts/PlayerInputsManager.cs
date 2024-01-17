using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsManager : MonoBehaviour
{
    public Vector2 move;
    public Vector2 look;
    public bool switchMode;
    public bool sprint;
    public bool jump;

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    private void OnLook(InputValue value)
    {      
        look = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }

}
