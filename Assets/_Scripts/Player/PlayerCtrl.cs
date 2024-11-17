using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Rigidbody rb;
    public float pressVertical;
    public float pressHorizontal;
    public float speedPlayer = 5f;
    public float speedPlayerRotate = 5f;
    public Vector3 moveDirection;
    public GameObject playerCamera;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    private void Update()
    {
        PlayerMoveInput();
        PlayerAttack();
        PlayerDefend();
    }
    public void PlayerMoveInput()
    {
        this.pressVertical = Input.GetAxis("Vertical");
        this.pressHorizontal = Input.GetAxis("Horizontal");
    }
    public void PlayerMove()
    {
        Vector3 movement1 = playerCamera.transform.forward * pressVertical;
        Vector3 movement2 = playerCamera.transform.right * pressHorizontal;
        moveDirection = movement1 + movement2;
        moveDirection.y = 0;
        rb.MovePosition(rb.position + this.speedPlayer * moveDirection * Time.deltaTime);
        if (moveDirection != Vector3.zero)
        { 
            AnimationPlayer.instance.SetIsRunTrue();
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection); 
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speedPlayerRotate); 
        }
        else
        {
            AnimationPlayer.instance.SetIsRunFalse();
        }
    }
    public void PlayerAttack()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            AnimationPlayer.instance.SetPressZ();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            AnimationPlayer.instance.SetSkill1();
        }
    }
    public void PlayerDefend()
    {
        if (Input.GetKey(KeyCode.V))
        {
            AnimationPlayer.instance.SetDefend();
        }
        else
        {
            AnimationPlayer.instance.SetNotDefend(); 
        }    
    }
}
