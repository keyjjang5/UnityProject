using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().enabled = false;
        transform.GetChild(0).gameObject.GetComponent<Text>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void replay()
    {
        SceneManager.LoadScene(0);
    }

    public void on()
    {
        gameObject.GetComponent<Button>().enabled = true;
        transform.GetChild(0).gameObject.GetComponent<Text>().enabled = true;
    }
}
