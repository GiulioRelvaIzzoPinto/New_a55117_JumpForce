using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private Rigidbody playerRb;
     public float jumpForce;
     public float gravityModifier;
     public bool isOnGround = true;
     public bool gameOver = false;
     private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.AddForce (Vector3.up * 1000);
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)& isOnGround)
        {
            playerRb.AddForce (Vector3.up * /*10*/ jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //isOnGround = true;
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag ("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
