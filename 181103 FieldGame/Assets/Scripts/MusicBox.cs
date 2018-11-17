using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour {

    private AudioSource monsterDeathSound;
    public AudioClip monsterDead;

    // Use this for initialization
    void Start () {
        this.monsterDeathSound = this.gameObject.AddComponent<AudioSource>();
        this.monsterDeathSound.clip = this.monsterDead;
        this.monsterDeathSound.loop = false;
        this.monsterDeathSound.volume = 0.7f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void monsterDeath()
    {
        monsterDeathSound.Play();
    }
}
