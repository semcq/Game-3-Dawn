using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Video reference: https://www.youtube.com/watch?v=MvRqEDcJoJQ&index=7&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf
    //movement variables
    public float maxSpeed;
    private bool m_FacingRight;
    Rigidbody2D myRB;

    private bool increaseFear;

    public Text text;

    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.5f);

    public Slider fearSlider;
    public Image damageImage;
    public float batteryIncrease;
    public static bool damaged = false;

    public AudioClip damageSound;
    public AudioClip batteryPickupSound;


    // Using a global fear variable that increases when an enemy collides with the player
    // To avoid the fact that the flashlight can cause player collisions, the fear increase is done in the enemy script
    public static float currFear;

    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        m_FacingRight = true;
        currFear = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fearSlider.value = currFear;

        if (damaged)
        {
            damageImage.color = flashColor;
            AudioSource.PlayClipAtPoint(damageSound, transform.position, 1f);

        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;

        // Don't allow energy to exceed 50.0f
        if (Flashlight.energy > 100.0f)
        {
            Flashlight.energy = 100.0f;
            text.text = Mathf.Round(Flashlight.energy) + "%";
        }

        if (Flashlight.energy < 0)
        {
            Flashlight.energy = 0;
            text.text = Mathf.Round(Flashlight.energy) + "%";
        }

        if (currFear >= 50)
        {

            SceneManager.LoadScene("Fail Screen");
        }

        if (currFear < 0)
        {
            currFear = 0;
        }

        float move = Input.GetAxis("Horizontal");

        if (move < 0)
        {
            m_FacingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (move > 0)
        {
            m_FacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }


        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Battery")
        {
            Flashlight.energy += batteryIncrease;
            //Debug.Log(Flashlight.energy);
            AudioSource.PlayClipAtPoint(batteryPickupSound, transform.position, 1.0f);
            Destroy(other.gameObject);
        }
    }
}
