using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float Speed;
    private Vector2 Move;
    private Vector2 change;
    public bool Attacking = false;
    public bool movement = false;
    public void onMove(InputAction.CallbackContext context)
    {
        change = Move;
        Move = context.ReadValue<Vector2>();
    }
    public void Attack(InputAction.CallbackContext context)
    {
        Attacking = context.ReadValue<bool>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        MovePlayer();
        if (Attacking == true)
        {
            //for audio
        }
        if (change != Move)
        {
            movement = true;
        }
        if (movement == true) 
        { 
            // for audio
        }

    }

    public void MovePlayer()
    {
        
        Vector3 Movement = new Vector3(Move.x, 0f, Move.y);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Movement), 1f);
        transform.Translate(Movement * Speed *  Time.deltaTime, Space.World);
    }
    
}
