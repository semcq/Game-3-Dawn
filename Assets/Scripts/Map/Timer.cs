using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    // Use this for initialization
    public float timeLeft;

    public Text text;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (GhostSpawn.addTime)
        {
            timeLeft += 10.0f;
            text.text = "Time Left: " + Mathf.Round(timeLeft);
            GhostSpawn.addTime = false;
        }

        timeLeft -= Time.deltaTime;
        //Debug.Log(timeLeft);

        text.text = "Time Left: " + Mathf.Round(timeLeft);

        if (timeLeft < 0)
        {
            SceneManager.LoadScene("Victory Screen");
        }
	}
}
