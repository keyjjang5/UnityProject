using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalControl : MonoBehaviour {

    // 충돌했는가(true), 충돌하지 않았는가(false)를 나타낸다.
    private bool is_collided = false;
    public float GOAL_MIN = 0.0f; // 최솟값
    public float GOAL_MAX = 5.0f; // 최댓값
    private AudioSource audio;
    public AudioClip goalSound;

    // Use this for initialization
    void Start () {
        // GOAL_MIN~GOAL_MAX 사이의 임의의 값을 가져온다.
        float rnd = Random.Range(GOAL_MIN, GOAL_MAX);
        // Goal의 X위치를 임의의 값으로
        this.transform.position = transform.position + new Vector3(rnd, rnd%4, 0.0f);

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.goalSound;
        this.audio.loop = false;
        gameObject.GetComponent<AudioSource>().volume = 0.3f                                                    ;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        this.audio.Play();
    }

    void OnCollisionStay(Collision other)
    {
        this.is_collided = true;
        
    }

    void OnGUI()
    {
        if (is_collided)
        { // 충돌했으면
          // 화면에 '성공'이라고 표시
            GUI.Label(new Rect(Screen.width / 2, 80, 100, 40), "성공");
        }
    }
}
