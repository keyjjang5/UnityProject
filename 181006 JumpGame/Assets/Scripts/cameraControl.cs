using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

    public GameObject player;
    public float cameraZ = -30f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -1)
            return;
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, cameraZ);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 2f);
    }

    private void FixedUpdate()
    {
        
    }
}
