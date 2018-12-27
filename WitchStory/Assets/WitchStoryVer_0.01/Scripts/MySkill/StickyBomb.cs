using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBomb : MonoBehaviour {

    float range = 10;
    float attackPower = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        Vector2 myBomb = transform.position;
        GameObject enemy = GameObject.FindGameObjectWithTag("Monster");
        Vector2 enemyPos = enemy.transform.position;

        if (Mathf.Pow(range, 2) >= Mathf.Pow((myBomb.x - enemyPos.x), 2) + Mathf.Pow((myBomb.y - enemyPos.y), 2))
        {
            enemy.GetComponent<slimeControl>().HP -= attackPower;
        }
    }
}
