using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour {

    public float damage = 0.1f;
    public float attackDelay = 0.2f;
    public float time = 5f;
    public Transform player;

	// Use this for initialization
	void Start () {
        StartCoroutine(timer());
        player = GameObject.FindGameObjectWithTag("Player").transform;

        transform.LookAt(player);
        transform.eulerAngles += new Vector3(0, 180, 0);
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

    IEnumerator timer()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
