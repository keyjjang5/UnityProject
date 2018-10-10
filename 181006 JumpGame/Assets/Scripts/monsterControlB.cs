using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterControlB : MonoBehaviour {

    public Vector3 start;
    public Vector3 end;
    public bool isUp = true;

    // Use this for initialization
    void Start () {
        start = transform.position;
        end = transform.position + new Vector3(0, 5, 0);
        StartCoroutine(Move());
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 now = gameObject.transform.position;
        if (now.y >= end.y - 0.5f && isUp)
            isUp = false;
        if (now.y <= start.y + 0.5f && !isUp)
            isUp = true;
    }

    IEnumerator Move()
    {
        while (true)
        {
            Vector3 up = Vector3.Lerp(start, end, Time.deltaTime) - start;
            Vector3 down = Vector3.Lerp(end, start, Time.deltaTime) - end;
            if (isUp)
                gameObject.transform.Translate(up);
            else
                gameObject.transform.Translate(down);

            yield return null;
        }
    }
}
