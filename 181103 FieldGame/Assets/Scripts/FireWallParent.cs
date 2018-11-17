using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallChild : MonoBehaviour {

    public float damage = 0.1f;
    public float attackDelay = 0.2f;
    public float speed = 5f;

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        
    }

    private void OnTriggerStay(Collider other)
    {
        attackDelay -= Time.deltaTime;
        if (other.gameObject.tag == "Player" && attackDelay <= 0)
        {
            other.gameObject.GetComponent<PlayerControl>().attacked(damage);
            attackDelay = 0.2f;
        }
    }
}
