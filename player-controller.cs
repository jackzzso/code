using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public string RunState, WalkState, IdleState, JumpState, DieState, ThrowState;
	bool isWalking, isRunning, isIdle, isDie, forward, left, right, back;
	Animator mAnim;

	public AudioSource AudioSource;
	public AudioClip jumping;
	public AudioClip throwing;

	void Start () {
		mAnim = GetComponent<Animator>();
		isIdle = true;
		AudioSource = GetComponent<AudioSource>();
	}

	void Update () {
		// if down
		if(Input.GetKeyDown(KeyCode.W))
		{
			if(!isRunning)
			{
				isWalking = true;
				isIdle = false;
				forward = true;
				mAnim.SetBool(WalkState, true);
				mAnim.SetBool(IdleState, false);
			}
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			if(!isRunning)
			{
				isWalking = true;
				isIdle = false;
				left = true;
				mAnim.SetBool(WalkState, true);
				mAnim.SetBool(IdleState, false);
			}
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			if(!isRunning)
			{
				isWalking = true;
				isIdle = false;
				back = true;
				mAnim.SetBool(WalkState, true);
				mAnim.SetBool(IdleState, false);
			}
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			if(!isRunning)
			{
				isWalking = true;
				isIdle = false;
				right = true;
				mAnim.SetBool(WalkState, true);
				mAnim.SetBool(IdleState, false);
			}
		}
		// etc movement
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			if(isWalking)
			{
				isRunning = true;
				mAnim.SetBool(WalkState, false);
				mAnim.SetBool(RunState, true);
			}
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			Throw();
		}


		// if up
		if(Input.GetKeyUp(KeyCode.W))
		{
			if(!left && !back && !right)
			{
				isWalking = false;
				isIdle = true;
				isRunning = false;
				mAnim.SetBool(WalkState, false);
				mAnim.SetBool(IdleState, true);
			}
		}
		if(Input.GetKeyUp(KeyCode.A))
		{
			if(!forward && !back && !right)
			{
				isWalking = false;
				isIdle = true;
				isRunning = false;
				mAnim.SetBool(WalkState, false);
				mAnim.SetBool(IdleState, true);
			}
		}
		if(Input.GetKeyUp(KeyCode.S))
		{
			if(!left && !forward && !right)
			{
				isWalking = false;
				isIdle = true;
				isRunning = false;
				mAnim.SetBool(WalkState, false);
				mAnim.SetBool(IdleState, true);
			}
		}
		if(Input.GetKeyUp(KeyCode.D))
		{
			if(!left && !back && !forward)
			{
				isWalking = false;
				isIdle = true;
				isRunning = false;
				mAnim.SetBool(WalkState, false);
				mAnim.SetBool(IdleState, true);
			}
		}
		// etc movement
		if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			if(isRunning && isWalking)
			{
				isRunning = false;
				mAnim.SetBool(WalkState, true);
				mAnim.SetBool(RunState, false);
			}
		}
	}

	public void Jump()
	{
		AudioSource.PlayOneShot(jumping);
		mAnim.SetBool(RunState, false);
		mAnim.SetBool(WalkState, false);
		mAnim.SetBool(IdleState, false);
		mAnim.SetBool(JumpState, true);
		StartCoroutine(ConsumeJump());
	}
	public void Throw()
	{
		AudioSource.PlayOneShot(throwing);
		mAnim.SetBool(RunState, false);
		mAnim.SetBool(WalkState, false);
		mAnim.SetBool(IdleState, false);
		mAnim.SetBool(ThrowState, true);
		StartCoroutine(ConsumeThrow());
	}

	IEnumerator ConsumeJump()
	{
		yield return new WaitForSeconds(0.66f);
		mAnim.SetBool(JumpState, false);
		if(isRunning)
			mAnim.SetBool(RunState, true);
		else if(isWalking)
			mAnim.SetBool(WalkState, true);
		else if(isIdle)
			mAnim.SetBool(IdleState, true);
	}
	IEnumerator ConsumeThrow()
	{
		yield return new WaitForSeconds(0.66f);
		mAnim.SetBool(ThrowState, false);
		if(isRunning)
			mAnim.SetBool(RunState, true);
		else if(isWalking)
			mAnim.SetBool(WalkState, true);
		else if(isIdle)
			mAnim.SetBool(IdleState, true);
	}
}
