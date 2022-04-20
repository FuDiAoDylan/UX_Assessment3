using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player_Tarin : MonoBehaviour
{
        private Rigidbody rb;
        public Animator ar;
        public Transform tf;
        public Vector3 movement;
        public Quaternion Rotation = Quaternion.identity;
        private int count;
        public TextMeshProUGUI countText;
        public GameObject winTextObject;
        public GameObject loseTextObject;
        public float moveSpeed = 10f;
        public float turnSpeed = 10f;
        public float jumpSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         ar = GetComponent<Animator>();
         tf = GetComponent<Transform>();

         count = 0;

         SetCountText ();

          winTextObject.SetActive(false);
          loseTextObject.SetActive(false);
     }

    // Update is called once per frame
    void Update()
    {
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
     
         if (Input.GetKey(KeyCode.M))
        {
           this.transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
        } 
         if (Input.GetKey(KeyCode.N))
        {
           this.transform.Translate(Vector3.down * jumpSpeed * Time.deltaTime);
        } 
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
      
        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool walkFlag = hasHorizontalInput || hasVerticalInput;
        ar.SetBool("walkFlag", walkFlag);
        bool jumpFlag = hasHorizontalInput || hasVerticalInput;
        ar.SetBool("jumpFlag", jumpFlag);
        tf.Translate(new Vector3(0, 0, 1) * Time.deltaTime *vertical);
        tf.Rotate(new Vector3(0, 1, 0) * horizontal * 5.0f);
        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        Rotation = Quaternion.LookRotation (desiredForward);
    }

      private void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.CompareTag("apple")) 
         {
            other.gameObject.SetActive(false);
            
            count = count + 1;

           SetCountText ();
         }

         if (other.gameObject.CompareTag("avocado")) 
          {
            other.gameObject.SetActive(false);
            
            
            count = count - 1;

           SetCountText ();
         }
    }

    void SetCountText()
     {
	countText.text = "Count: " + count.ToString();

	if (count >= 10) 
	  {
                    winTextObject.SetActive(true);
	   }
                 if(count<= -1)
                  {
                    loseTextObject.SetActive(true);
                   }

     }

   void OnAnimatorMove()
  {
      rb.MovePosition (rb.position +movement * ar.deltaPosition.magnitude);
      rb.MoveRotation (Rotation);
  }
}

