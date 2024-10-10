using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
public class Player : MonoBehaviour
{
    public float Speed;
    private Vector2 Move;
    private Vector2 change;
    public bool Attacking = false;
    public bool movement = true;
    public Animator Walk;
    public void onMove(InputAction.CallbackContext context)
    {
        change = Move;
        Move = context.ReadValue<Vector2>();
    }
    
    void Start()
    {
        Walk = GetComponent<Animator>();
    }

    
    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown("d"))
        {
            Walk.SetBool("Right",true);
            Walk.SetBool("Left", false);
            Walk.SetBool("Front", false);
            Walk.SetBool("Back", false);
        }
        if (Input.GetKeyDown("a"))
        {
            Walk.SetBool("Right", false);
            Walk.SetBool("Left", true);
            Walk.SetBool("Front", false);
            Walk.SetBool("Back", false);
        }
        if (Input.GetKeyDown("w"))
        {
            Walk.SetBool("Right", false);
            Walk.SetBool("Left", false);
            Walk.SetBool("Front", false);
            Walk.SetBool("Back", true);
        }
        if (Input.GetKeyDown("s"))
        {
            Walk.SetBool("Right", false);
            Walk.SetBool("Left", false);
            Walk.SetBool("Front", true);
            Walk.SetBool("Back", false);
        }


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("works");
            Attacking = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("works");
            Attacking = false;
        }
        if (change != Move)
        {
            movement = false;
        }
        else
        {
            movement = true;
        }
    }

    public void MovePlayer()
    {
        
        Vector3 Movement = new Vector3(Move.x, 0f, Move.y);
        transform.rotation = Quaternion.Slerp(transform.rotation,transform.rotation, 0f);
        transform.Translate(Movement * Speed *  Time.deltaTime, Space.World);
    }
    

}
