using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	//Character movement variables
	public float jumpForce = 8f;
	Rigidbody2D playerRigidBody;
	Animator playerAnimator;
	public float runningSpeed = 1f;
	public float maxSpeed = 6f;
	public bool facingRight = true;


	private const string ALIVE_STATE = "isAlive";
	private const string GROUND_STATE = "isOnTheGround";

	//Capa que se va a ocupar de registrar que forma parte del suelo
	public LayerMask groundMask;

	void Awake()
	{
		playerRigidBody = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator>();

	}

	void Jump()
	{
		if (isTouchingGround())
		{
			playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	void MoveRight()
	{
		if (isTouchingGround())
		{
			playerRigidBody.AddForce(Vector2.right * runningSpeed, ForceMode2D.Force);
		}
	}

	void MoveLeft()
	{
		if (isTouchingGround())
		{
			playerRigidBody.AddForce(Vector2.left * runningSpeed, ForceMode2D.Force);
		}
	}
	//Method for recognizing if the player is touching the ground.
	bool isTouchingGround()
	{

		if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.5f, groundMask))
		{
	
			return true;
		}
		else
		{

			return false;
		}
	}
	// Start is called before the first frame update
	void Start()
	{
		playerAnimator.SetBool(ALIVE_STATE, true);
		playerAnimator.SetBool(GROUND_STATE, false);
	}

	// Update is called once per frame
	void Update()
	{
		//Input Detector for movements
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			Jump();
		}

		if (Input.GetKey(KeyCode.D))
		{
			MoveRight();
		}
		if (Input.GetKey(KeyCode.A))
		{
			MoveLeft();
		}
		//Play an idle animation while playerRigidBody not moving
		if (playerRigidBody.velocity.magnitude == 0)
		{
			playerAnimator.Play("land");
		}

		playerAnimator.SetBool(GROUND_STATE, isTouchingGround());

		Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, Color.cyan);
	}

	void FixedUpdate()
	{
		//SpeedCap
		if (playerRigidBody.velocity.magnitude > maxSpeed)
		{
			playerRigidBody.velocity = playerRigidBody.velocity.normalized * maxSpeed;
		}

		//Object Facing Direction Detector
		float h = Input.GetAxis("Horizontal");
		if (h > 0 && !facingRight)
		{
			Flip();
		}
		else if (h < 0 && facingRight)
		{
			Flip();
		}

	}
	// Animation flipper depending on Rigid Body's horizontal facing
	void Flip()
	{
		facingRight = !facingRight;
		Vector2 tranScale = transform.localScale;
		tranScale.x *= -1;
		transform.localScale = tranScale;
	}
}
