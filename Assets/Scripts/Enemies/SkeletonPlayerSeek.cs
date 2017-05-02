using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonPlayerSeek : MonoBehaviour
{

    // Use this for initialization
    Transform Player;
    float moveSpeed = 0.25f;

    public Renderer rend;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * moveSpeed, (transform.position.y - Player.transform.position.y) * moveSpeed);

        GetComponent<Rigidbody2D>().velocity = -velocity;
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            PlayerController.currFear += 10;
            Destroy(gameObject);
            PlayerController.damaged = true;
        }

    }

}
