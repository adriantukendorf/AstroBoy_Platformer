using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject AstroBoy;
    // Start is called before the first frame update
    void Start()
    {
        AstroBoy = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            AstroBoy.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            AstroBoy.GetComponent<PlayerMovement>().isGrounded = false;

        }
    }
}
