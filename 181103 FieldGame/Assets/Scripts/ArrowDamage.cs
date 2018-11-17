using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour {

    public float damage = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("asdfa");
            Destroy(gameObject);
            collision.gameObject.GetComponent<MonsterControl>().attacked(damage);
        }
    }
}
