// Reference https://learn.unity.com/tutorial/displaying-score-and-text?uv=2019.4&projectId=5f158f1bedbc2a0020e51f0d#

using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using TMPro;

public class PickUp_William : MonoBehaviour
{

	public TextMeshProUGUI countText;
	public GameObject winImageObject;
	public GameObject failImageObject;

	public AudioSource pickUpAudio;
	public AudioSource winAudio;
	public AudioSource failAudio;
	public AudioSource backAudio;

	private int count;
	private bool isPlay;

	// At the start of the game..
	void Start()
	{
		// Set the count to zero 
		count = 0;
		isPlay = true;
		SetCountText();

		// Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winImageObject.SetActive(false);
		failImageObject.SetActive(false);
	}

	void FixedUpdate()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (!isPlay)
		{
			return;
		}
		// and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("food"))
		{
			other.gameObject.SetActive(false);
			pickUpAudio.Play();
			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText();
		}
		if (other.gameObject.CompareTag("enemy"))
		{
			failImageObject.SetActive(true);
			isPlay = false;
			backAudio.Stop();
			failAudio.Play();	
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 6)
		{
			// Set the text value of your 'winText'
			winImageObject.SetActive(true);
			isPlay = false;
			backAudio.Stop();
			winAudio.Play();
		}
	}
}