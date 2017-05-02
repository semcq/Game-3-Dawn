using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour {
    public Button NightTwo;
    public Button NightThree;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        if (Timer1.level2Unlock == false)
        {
            NightTwo.interactable = false;
        }

        else
        {
            NightTwo.interactable = true;
        }

        if (Timer2.level3Unlock == false)
        {
            NightThree.interactable = false;
        }

        else
        {
            NightThree.interactable = true;
        }
	}
}
