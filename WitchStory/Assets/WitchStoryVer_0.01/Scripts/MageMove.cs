using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageMove : MonoBehaviour
{
    Vector2 up;
    //public float Hp = 1;
    //public float atk = 10;
    //public float Ap = 5;
    //public float speed = 4;
    public MyCharacter character = new MyCharacter(1, 10, 5, 1.5f);
    public GameObject enemy;
    float timer = 0;
    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Monster");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //up = new Vector2(Random.Range(-50, 50), Random.Range(5, 20));

        Vector3 magePos = gameObject.GetComponent<Transform>().position;
        Vector3 movePos = magePos + new Vector3(0, character.speed, 0);

        gameObject.transform.Translate(Vector3.Lerp(magePos, movePos, Time.deltaTime) - magePos);
        //if (timer > speed)
        //{
        //    //GetComponent<Rigidbody2D>().AddForce(up);
        //    //Vector3 pos = new Vector3(0, 0.01f, 0);
        //    //gameObject.transform.Translate(pos);
        //    timer = 0;
        //}
        //if (this.GetComponent<Transform>().position.y < -10 || this.GetComponent<Transform>().position.y > 10)
        //{
        //    Destroy(gameObject);
        //}

        if (character.hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(enemy))
        {
            character.hp -= enemy.GetComponent<slimeControl>().atk;
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        float timer = Time.deltaTime;

        if (collision.gameObject.Equals(enemy) && timer >= 0.15)
        {
            character.hp -= enemy.GetComponent<slimeControl>().atk;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(enemy))
        {
            character.hp -= enemy.GetComponent<slimeControl>().atk;
        }
    }
}
