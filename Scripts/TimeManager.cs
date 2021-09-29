using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    //Player data
    public GameObject player;
    public bool isReversing = false;
    public ArrayList playerPositions;
    public ArrayList climbingInfo;
    public ArrayList direction;
    public ArrayList playerHealth;

    //Environmental data
    public GameObject rock1,rock2,rock3;
    public ArrayList rock1pos;
    public ArrayList rock2pos;
    public ArrayList rock3pos;

    //Timer
    public float timeStart = 20;
    public Text textBox;



     void Start()
    {
        textBox.text = timeStart.ToString();

        playerPositions = new ArrayList();
        climbingInfo = new ArrayList();
        direction = new ArrayList();
        rock1pos = new ArrayList();
        rock2pos = new ArrayList();
        rock3pos = new ArrayList();
        playerHealth = new ArrayList();

    }

     void FixedUpdate()
    {
        if (!isReversing)
        {
            if (player.GetComponent<PlayerMovement>().currentHealth > 0) //if player is dead stop recording time
            { 

                //Player
                playerPositions.Add(player.transform.position);
                climbingInfo.Add(player.GetComponent<PlayerMovement>().isClimbing);
                direction.Add(player.GetComponent<PlayerMovement>().inputHorizontal);
                playerHealth.Add(player.GetComponent<PlayerMovement>().currentHealth);

                //Rocks
                rock1pos.Add(rock1.transform.position);
                rock2pos.Add(rock2.transform.position);
                rock3pos.Add(rock3.transform.position);
            }
        }
        else
        {
            
            
                //Player
                player.transform.position = (Vector3)playerPositions[playerPositions.Count - 1];
                playerPositions.RemoveAt(playerPositions.Count - 1);

                player.GetComponent<PlayerMovement>().isClimbing = (bool)climbingInfo[climbingInfo.Count - 1];
                climbingInfo.RemoveAt(climbingInfo.Count - 1);

                player.GetComponent<PlayerMovement>().inputHorizontal = (float)direction[direction.Count - 1];
                direction.RemoveAt(direction.Count - 1);

                player.GetComponent<PlayerMovement>().currentHealth = (int)playerHealth[playerHealth.Count - 1];
                playerHealth.RemoveAt(playerHealth.Count - 1);

                //Rocks
                rock1.transform.position = (Vector3)rock1pos[rock1pos.Count - 1];
                rock1pos.RemoveAt(rock1pos.Count - 1);

                rock2.transform.position = (Vector3)rock2pos[rock2pos.Count - 1];
                rock2pos.RemoveAt(rock2pos.Count - 1);

                rock3.transform.position = (Vector3)rock3pos[rock3pos.Count - 1];
                rock3pos.RemoveAt(rock3pos.Count - 1);
            
        }
    }

     void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (timeStart >= 0)
            {
                isReversing = true;

                timeStart -= Time.deltaTime;
            }
            else
            {
                isReversing = false;
            }
            
        }
        else
        {
            isReversing = false;
            if (timeStart <= 20)
            {
                if (player.GetComponent<PlayerMovement>().currentHealth > 0)
                {
                    timeStart += Time.deltaTime;
                }
            }
        }

        textBox.text = Mathf.Round(timeStart).ToString();
        
    }
}
