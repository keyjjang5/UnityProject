using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public float damage = 1.0f;
    public Vector3 pos;
    public Vector3 playerPos;
    // Use this for initialization
    void Start () {
        transform.position = transform.parent.position;
        pos = transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = Vector3.Lerp(pos, playerPos, Time.deltaTime / 5) - pos;
        transform.Translate(move);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControl>().attacked(damage);
        }

        Destroy(gameObject);
    }
}
