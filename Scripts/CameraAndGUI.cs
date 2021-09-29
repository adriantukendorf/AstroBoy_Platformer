using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAndGUI : MonoBehaviour
{
    public Sprite[] HeartSprites;

    public Image HeartUI;

    private Transform playerTransform;

    private PlayerMovement player;
    private Vector2 velocity;

    public float smoothY;
    public float smoothX;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }

  

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothY);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }


    private void Update()
    {
        HeartUI.sprite = HeartSprites[player.currentHealth];
    }
}
