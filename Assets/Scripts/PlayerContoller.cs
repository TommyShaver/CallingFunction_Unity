using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRB;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        KeepInBounds();
    }


    //Move Player Funtion
    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        playerRB.AddForce(Vector3.forward * speed * moveVertical);
        playerRB.AddForce(Vector3.right * speed * moveHorizontal);
    }

    //Keep player in camera bounds
    void KeepInBounds()
    {
        float zBoundsBottom = -1.5f;
        float zBoundsTop = 15;

        if (transform.position.z > zBoundsTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundsTop);
        }

        if (transform.position.z < zBoundsBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundsBottom);
        }
    }
}
