using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehavior {
    float horizontal, vertical;
    Rigidbody m_Rigidbody;
    public float JumpPower;
    public float MoveSpeed, RunSpeed;
    
    private float currentJumpPower = 0;
    private float currentMoveSpeed = 0;

    void Start() {
        m_Rigidbody = GetComponent<Rigidbody>();
        currentMoveSpeed = MoveSpeed;
        m_Cam = Camera.main.transform
        m_Animator = GetComponent<Animator>();
    }
    void Update() 
    {
        CheckGroundStatus();
        horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        vertical = CrossPlatformInputManager.GetAxis("Vertical");
        
        if(Input.GetKeyDown(KeyCode.Space) && m_IsGrounded)
        {
            m_Rigidbody.AddForce(0,JumpPower,0)
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && m_IsGrounded)
        {
            currentMoveSpeed = RunSpeed
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentMoveSpeed = MoveSpeed 
        }
    }
    float m_TurnAmount;
    float m_ForwardAmount;
    [SerializeField] float m_StationaryTurnSpeed = 180;
    [SerializeField] float m_MovingTurnSpeed = 360;

    public Transform m_Cam
    private Vector3 m_CamForward;
    private Vector3 m_Move;
    private bool m_Jump;
    void FixedUpdate() {
        // adding code on thursday
    }
    //  continuing here tmr
}
