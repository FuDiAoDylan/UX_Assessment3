// Reference https://learn.unity.com/tutorial/displaying-score-and-text?uv=2019.4&projectId=5f158f1bedbc2a0020e51f0d#

using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using TMPro;

public class Count_Dylan: MonoBehaviour {
	
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public AudioSource pickUpAudio;
	public AudioSource winAudio; 

	private int count;

	// At the start of the game..
	void Start ()
	{
		// Set the count to zero 
		count = 0;
		SetCountText ();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
	}

	void FixedUpdate ()
	{

	}

	void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("diamond"))
		{
			other.gameObject.SetActive (false);
			pickUpAudio.Play();

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("star"))
		{
 			// Set the text value of your 'winText'
            winTextObject.SetActive(true);
			winAudio.Play();
		}		
	}

    void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
	}
}