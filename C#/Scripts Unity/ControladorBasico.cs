using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Character movement variables
    public float jumpForce = 6f;
    Rigidbody2D playerRigidBody;

    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Jump() 
    {
        playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }
}
