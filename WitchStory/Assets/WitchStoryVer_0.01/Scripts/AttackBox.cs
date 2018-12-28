using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour {

    public GameObject monster;
    static public bool isAttack;
    public int count = 0;

	// Use this for initialization
	void Start () {
        monster = GameObject.FindGameObjectWithTag("Monster");
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        isAttack = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isAttack && count == 0)
            StartCoroutine(attackBox());
    }

    public IEnumerator attackBox()  
    {
        count++;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;

        yield return new WaitForSeconds(0.3f);

        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        count--;
        isAttack = false;
    }

    public void setAttack(bool b)
    {
        isAttack = b;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float distance = Vector2.Distance(transform.position, collision.transform.position);
        if (collision.gameObject.tag == "Undead" && isAttack && distance >= 1.5) 
        {
            monster.GetComponent<slimeControl>().HP -= collision.gameObject.GetComponent<MageMove>().character.atk / 2;
            Destroy(collision.gameObject);
        }
    }

    public void onAttackBox()
    {
        setAttack(true);
    }
}
