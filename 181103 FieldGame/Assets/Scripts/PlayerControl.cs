using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour {

    public float hp = 5.0f;
    GameObject hpBar;
    GameObject gameOver;

    public int count = 0;
    GameObject achive;

    GameObject replay;

    private AudioSource audio;
    public AudioClip jumpSound;
    // Use this for initialization
    void Start () {
        hpBar = GameObject.Find("PlayerHp");
        gameOver = GameObject.Find("GameOver");
        achive = GameObject.Find("Items");
        replay = GameObject.Find("Replay");

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;

        count = PlayerPrefs.GetInt("count");
        achive.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + count;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.GetComponent<Slider>().value = hp / 5;

        if (hp <= 0)
        {
            gameOver.GetComponent<Text>().enabled = true;
            replay.GetComponent<Replay>().on();
            GameObject.Find("MainCamera").transform.SetParent(null);

            PlayerPrefs.DeleteKey("count");

            Destroy(gameObject);
        }

        if(Input.GetKey(KeyCode.W))
        {
            if (audio.isPlaying == false)
                this.audio.Play();
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (audio.isPlaying == false)
                this.audio.Play();
        }

        if (transform.position.y <= -10)
        {
            hp = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
            hp -= 5f;
    }

    public void attacked(float damage)
    {
        hp -= damage;
    }

    public void itemCount()
    {
        count++;
        achive.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + count;
    }
}

