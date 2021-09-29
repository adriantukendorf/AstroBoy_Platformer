using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{

    public GameObject Spawn,Spawn2,Spawn3;
    public GameObject Rock,Rock2,Rock3;

    //This script teleports rocks back to the start position after interaction with the specified collider.
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Rock")
        {
            Rock.transform.position = new Vector2(Spawn.transform.position.x, Spawn.transform.position.y);
        }
        if (other.gameObject.tag == "Rock2")
        {
            Rock2.transform.position = new Vector2(Spawn2.transform.position.x, Spawn2.transform.position.y);
        }
        if (other.gameObject.tag == "Rock3")
        {
            Rock3.transform.position = new Vector2(Spawn3.transform.position.x, Spawn3.transform.position.y);
        }

    }
   
}
