using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatPlayerSeek : MonoBehaviour
{

    // Use this for initialization
    Transform Player;
    float moveSpeed = 0.5f;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
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
            Destroy(gameObject);
            PlayerController.currFear += 10;
            PlayerController.damaged = true;
        }


    }

}
