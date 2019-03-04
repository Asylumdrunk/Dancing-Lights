using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
	private Rigidbody2D myRigidbody;
	private Animator myAnimator;
	private AudioSource myAudio;

	[SerializeField]
	// Serializing means that I will be able to see it in the inspector in Unity.
	private float movementSpeed;

	private bool facingRight;

	[SerializeField]
	Transform[] groundPoints;

	[SerializeField]
	float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	bool isGrounded;

	private bool jump;

	[SerializeField]
	private float jumpForce;

	// Use this for initialization
	void Start()
	{
		facingRight = true;
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		myAudio = GetComponent<AudioSource> ();
		GlobalVariables.playerStartLocation = gameObject.transform.position;
	}

	void Update()
	{
		if (GlobalVariables.gameState == true) {
			HandleInput ();
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (GlobalVariables.gameState == true) {
			float horizontal = Input.GetAxis ("Horizontal");
			isGrounded = IsGrounded ();
			HandleMovement (horizontal);
			Flip (horizontal);
			HandleLayers ();
			ResetValues ();
		}
	}

	private void HandleMovement(float horizontal)
	{
		if (myRigidbody.velocity.y < 0)
		{
			myAnimator.SetBool("land", true);
		}
		myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y); //x = -1, y = 0
		myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
		//Jumping code, checks when space is pressed then adds a force upwards
		//animation may need to be added in if it exists
		//checks when the player hits space and if the player is touching the ground
		if (isGrounded && jump)
		{
			isGrounded = false;
			myRigidbody.AddForce(new Vector2(0, jumpForce));
			myAnimator.SetTrigger("jump");
		}
	}

	private void HandleInput()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
		}
	}

	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	private void ResetValues()
	{
		jump = false;
	}

	private bool IsGrounded()
	{
		//The if statement says that if the velocity is less than 0, the player will fall off the ground 
		//and if it's equal to 0, the player will stand on the ground.
		if (myRigidbody.velocity.y <= 0)
		{
			foreach (Transform point in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.Length; i++)
				{
					if (colliders[i].gameObject != gameObject)
					{
						myAnimator.ResetTrigger("jump");
						myAnimator.SetBool("land", false);
						return true; //colliding
					}
				}
			}
		}
		return false;
	}

	private void HandleLayers()
	{
		if (!isGrounded)
		{
			myAnimator.SetLayerWeight(1, 1);
		}

		else
		{
			myAnimator.SetLayerWeight(1, 0);
		}
	}
	void playFootstep() {
		if (isGrounded) {
			myAudio.Play ();
		}
	}
}