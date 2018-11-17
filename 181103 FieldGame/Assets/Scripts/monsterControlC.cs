using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterControlC : MonoBehaviour {

    public Vector3 start;
    public Vector3 end;

    // Use this for initialization
    void Start () {
        gameObject.transform.position = start;
        StartCoroutine(Move());
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.x <= end.x)
            Destroy(gameObject);
    }

    IEnumerator Move()
    {
        while (true)
        {
            Vector3 left = Vector3.Lerp(start, end, Time.deltaTime) - start;
            gameObject.GetComponent<Rigidbody>().velocity = left * 20;

            yield return null;
        }
    }
}
