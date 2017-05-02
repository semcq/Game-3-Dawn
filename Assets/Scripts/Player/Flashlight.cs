using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {

    // Use this for initialization
    bool lightOn;
    public static float energy;
    public float drainSpeed;

    public Renderer rend;

    public Text text;

    public AudioClip toggleLight;
    public AudioClip burnSound;

    private Animator anim;
    private Rigidbody2D rb;

    //public static bool reveal;


    void Start () {
        lightOn = false;
        energy = 100.0f;

        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);

        // Don't allow light to turn on if lower battery is drained
        if (energy <= 0)
        {
            rend.enabled = false;
        }

        // Turn on light on press change sprite
        if (Input.GetKeyDown(KeyCode.Space) && energy > 0)
        {
            lightOn = true;
            rend.enabled = true;
            AudioSource.PlayClipAtPoint(toggleLight, transform.position, 1.0f);

        }

        // Turn off light and change sprite
        if (Input.GetKeyUp(KeyCode.Space))
        {
            lightOn = false;
            rend.enabled = false;
            AudioSource.PlayClipAtPoint(toggleLight, transform.position, 1);
        }

        // Drain light over time as long as light is on
        if (lightOn)
        {
            energy -= drainSpeed * Time.deltaTime;

            text.text = Mathf.Round(energy) + "%";
            //Debug.Log(energy);
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (lightOn && other.gameObject.tag == "Enemy")
        {
            anim = other.GetComponent<Animator>();
            anim.SetBool("isDestroyed", true);
            StartCoroutine(Wait(0.20f, other));
        }
    }

    private IEnumerator Wait(float seconds, Collider2D someCollider)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(someCollider.gameObject);
        AudioSource.PlayClipAtPoint(burnSound, transform.position, 1.0f);
    }
}
