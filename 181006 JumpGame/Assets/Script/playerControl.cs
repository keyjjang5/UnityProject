using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour {

    private float power;
    public float POWERPLUS = 300.0f;
    private AudioSource audio;
    public AudioClip jumpSound;
    private bool isStick = false;

    // Use this for initialization
    void Start () {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        { // 왼쪽 버튼이 눌려있는 동안
            power += POWERPLUS * Time.deltaTime; // 힘을 비축
        }
        if (Input.GetMouseButtonUp(0))
        { // 왼쪽 버튼을 놓으면
          // 비축한 힘을 x와 y에 반영해서 오른쪽 위로 점프!
            this.GetComponent<Rigidbody>().AddForce(new Vector3(power, power, 0));
            power = 0.0f; // 힘을 0으로
            this.audio.Play();

        }
        // 지면보다 아래(-5.0f)로 떨어지면
        if (this.transform.position.y < -5.0f)
        {
            SceneManager.LoadScene("Main"); // 씬을 다시 로드
        }
        // 벽에 붙어있다면
        if(isStick)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ
                | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        else
        {
            this.GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionZ
                | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetMouseButtonDown(1))
            isStick = true;
        if (Input.GetMouseButtonUp(1))
            isStick = false;
    }
}
