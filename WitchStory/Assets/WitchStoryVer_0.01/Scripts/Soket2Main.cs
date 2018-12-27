using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soket2Main : MonoBehaviour {

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnMouseDown()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("gamescene");
    }
}
