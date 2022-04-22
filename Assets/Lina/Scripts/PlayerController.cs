using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Include the namespace required to use Unity UI and Input System

using TMPro;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed = 0;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public float moveSpeed = 20f;
	public float turnSpeed = 10f;
	public Vector3 movement;
	public Quaternion Rotation = Quaternion.identity;

	private Rigidbody rb;
	private int count;

	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();
		
		// Set the count to zero 
		count = 0;

		SetCountText();

		// Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winTextObject.SetActive(false);
	}

	void Update()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		if (Input.GetKey(KeyCode.W))

		{

			this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

		}

		if (Input.GetKey(KeyCode.S))

		{

			this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

		}

		if (Input.GetKey(KeyCode.A))

		{

			this.transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);

		}

		if (Input.GetKey(KeyCode.D))

		{

			this.transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);

		}
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		movement.Set(horizontal, movement.y, vertical);
		movement.Normalize();
		Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
		Rotation = Quaternion.LookRotation(desiredForward);
	}

	void OnTriggerEnter(Collider other)
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("Fries"))
		{
			other.gameObject.SetActive(false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText();
		}
	}

	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 8)
		{
			// Set the text value of your 'winText'
			winTextObject.SetActive(true);
		}
	}
	
}

