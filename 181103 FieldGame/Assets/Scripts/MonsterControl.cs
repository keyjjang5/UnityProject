using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterControl : MonoBehaviour {

    public float hp = 25.0f;
    public float skillTimer1 = 5f;
    public float actionTimer1 = 0.5f;
    public float skillTImer2 = 8f;
    public float actionTimer2 = 0.5f;

    public GameObject ball;
    public GameObject wall;

    public float speed = 5f;

    private AudioSource fireBallSound;
    public AudioClip fireBallClip;

    GameObject replay;
    // Use this for initialization
    void Start() {
        this.fireBallSound = this.gameObject.AddComponent<AudioSource>();
        this.fireBallSound.clip = this.fireBallClip;
        this.fireBallSound.loop = false;

        replay = GameObject.Find("Replay");
    }

    // Update is called once per frame
    void Update() {
        skillTimer1 -= Time.deltaTime;
        skillTImer2 -= Time.deltaTime;
        //플레이어가 있는방향을 봄
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);

        GameObject.Find("MonsterHp").GetComponent<Slider>().value = hp / 25;

        if (skillTimer1 <= 0)
        {
            StartCoroutine(fireBall());
            skillTimer1 = 5f;
        }
        if (skillTImer2 <= 0)
        {
            StartCoroutine(fireWall());
            skillTImer2 = 8f;
        }

        if(hp <= 0)
        {
            GameObject.Find("Win").GetComponent<Win>().gameWin();
            GameObject.Find("MusicBox").GetComponent<MusicBox>().monsterDeath();
            replay.GetComponent<Replay>().on();
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.P))
            hp--;
    }

    public void attacked(float damage)
    {
        hp -= damage;
    }

    IEnumerator fireBall()
    {
        GameObject newBall = Instantiate(ball);
        newBall.transform.SetParent(GameObject.Find("FireBallSpawner").transform);

        fireBallSound.Play();

        this.GetComponent<Animation_Test>().DamageAni();
        while (actionTimer1>0)
        {
            actionTimer1 -= Time.deltaTime;

            skillTimer1 = 5f;

            yield return null;
        }

        actionTimer1 = 0.5f;
        this.GetComponent<Animation_Test>().IdleAni();
    }

    IEnumerator fireWall()
    {
        GameObject newWall = Instantiate(wall);

        newWall.transform.SetParent(GameObject.Find("FireWallSpawner").transform);
        

        this.GetComponent<Animation_Test>().AttackAni();
        while (actionTimer2 > 0)
        {
            actionTimer2 -= Time.deltaTime;

            skillTImer2 = 8f;

            yield return null;
        }

        actionTimer2 = 0.5f;
        this.GetComponent<Animation_Test>().IdleAni();
    }
}
