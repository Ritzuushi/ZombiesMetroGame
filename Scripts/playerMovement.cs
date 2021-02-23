using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField]float moveSpeed = 5f;
    [SerializeField]float rotationSpeed = 5f;
    public float rotation;
    public Rigidbody2D rb;
    public Joystick joyLeft;
    public Joystick joyRight;
    public Animator animatorOne;
    public Animator animatorTwo;
    public Animator animatorThree;
    public GameObject charOne;
    public GameObject charTwo;
    public GameObject charThree;
    public GameObject joyLeftObj;
    public GameObject joyRightObj;
    
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Joypos") == 1)
        {
            movement.x = joyLeft.Horizontal;
            movement.y = joyLeft.Vertical;
            joyLeftObj.SetActive(true);
            joyRightObj.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Joypos") == 2)
        {
            movement.x = joyRight.Horizontal;
            movement.y = joyRight.Vertical;
            joyLeftObj.SetActive(false);
            joyRightObj.SetActive(true);
        }

        bool isMoving;

        if (movement.x + movement.y != 0)
        {
            isMoving = true;
        } else 
        {
            isMoving = false;
        }

        int character = PlayerPrefs.GetInt("Character");
        
        if (character == 1)
        {
            charOne.SetActive(true);
            charTwo.SetActive(false);
            charThree.SetActive(false);
            animatorOne.SetBool("isMoving", isMoving);
        }
        else if (character == 2)
        {
            charOne.SetActive(false);
            charTwo.SetActive(true);
            charThree.SetActive(false);
            moveSpeed = 6.5f;
            animatorTwo.SetBool("isMoving", isMoving);
        }
        else if (character == 3)
        {
            charOne.SetActive(false);
            charTwo.SetActive(false);
            charThree.SetActive(true);
            animatorThree.SetBool("isMoving", isMoving);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        if (movement.x != 0 || movement.y != 0)
        {
            Vector3 lookDirection = new Vector3(movement.x, movement.y, 3f);
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.back);
            
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(lookRotation, transform.rotation, step);
        }
        else 
        {
            FindObjectOfType<SoundManager>().Play("Run");
        }
    }
}
