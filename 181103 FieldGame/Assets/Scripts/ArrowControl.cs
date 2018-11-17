using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour {

    public GameObject monster;
    public Vector3 pos;
    public float damage = 5.0f;
    public Vector3 monsterPos;

    // Use this for initialization
    void Start () {
        monster = GameObject.FindGameObjectWithTag("Monster");
        transform.position = transform.parent.position;
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        monsterPos = monster.transform.position;

        //Vector3 heading = monsterPos - pos;
        //float distance = heading.magnitude;
        //Vector3 direction = heading / distance;

        transform.Translate(Vector3.Lerp(pos, monsterPos, Time.deltaTime / 5) - pos);
        //// 뭔지 모르겠음 이밑에 두줄
        //// 방향을 꺾으려고 노력한것
        //Quaternion to = Quaternion.LookRotation(direction);
        //Quaternion frameRot = Quaternion.RotateTowards(transform.rotation, to, Time.deltaTime);

        //transform.rotation = frameRot;

        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.name;
        Debug.Log(name);
        if (other.gameObject.Equals(monster))
        {
            Debug.Log("asdfa");
            Destroy(gameObject);
            other.gameObject.GetComponent<MonsterControl>().attacked(damage);
        }
    }


}
