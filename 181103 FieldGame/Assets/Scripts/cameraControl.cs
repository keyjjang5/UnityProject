using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

    public GameObject player;
    public GameObject subCamera;
    public bool isCamera = false;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null && !isCamera)
        {
            Instantiate(subCamera);
            isCamera = true;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
