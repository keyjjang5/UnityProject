using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSpawner : MonoBehaviour {

    public GameObject monster;
    public float spawnTime;
    public Vector3 start;
    public Vector3 end;

	// Use this for initialization
	void Start () {
        start = transform.position;
        end = transform.position + new Vector3(-10, 0, 0);
        StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Spawn()
    {
        while (true)
        {
            monster.GetComponent<monsterControlC>().start = start;
            monster.GetComponent<monsterControlC>().end = end;
            Instantiate(monster);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
