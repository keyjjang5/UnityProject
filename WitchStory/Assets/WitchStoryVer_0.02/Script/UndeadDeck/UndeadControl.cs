using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadControl : MonoBehaviour {

    float timer = 0;
    Undead status;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        Vector3 magePos = gameObject.GetComponent<Transform>().position;
        Vector3 movePos = magePos + new Vector3(0, status.speed, 0);

        gameObject.transform.Translate(Vector3.Lerp(magePos, movePos, Time.deltaTime) - magePos);
    }

    public void setStatus(Undead undead)
    {
        status = undead;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            // 제작예정, 몬스터와 만났을때 데미지를 줌
            //collision.gameObject.GetComponent<MonsterControl>().gainDamage(status.atk);
        }
    }
}
