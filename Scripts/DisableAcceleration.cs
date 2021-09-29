using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAcceleration : MonoBehaviour
{
    public float speed;
    private Rigidbody2D obj; 
     
     void Start()
    {
        obj = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        obj.velocity = new Vector2( 0, speed);
    }
 
}
