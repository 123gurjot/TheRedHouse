using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float Speed;
    private Vector2 Move;

    public void onMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
       MovePlayer();
    }

    public void MovePlayer()
    {
        Vector3 Movement = new Vector3(Move.x, 0f, Move.y);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Movement), 1f);
        transform.Translate(Movement * Speed *  Time.deltaTime, Space.World);
    }
}
