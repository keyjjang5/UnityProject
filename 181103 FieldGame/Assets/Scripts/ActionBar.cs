using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        off();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void on()
    {
        Color col = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color;
        col = new Color(col.r, col.g, col.b, 255);
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = col;

    }

    public void off()
    {
        Color col = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color;
        col = new Color(col.r, col.g, col.b, 0);
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = col;
    }
}
