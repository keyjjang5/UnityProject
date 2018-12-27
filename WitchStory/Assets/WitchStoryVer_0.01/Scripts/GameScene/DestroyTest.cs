using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
            MageDestroy();
	}

    void MageDestroy()
    {
        GameObject mage = GameObject.FindGameObjectWithTag("Mage");
        Destroy(mage);

        return;
    }
}
