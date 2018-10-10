using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{

    private float power;
    public float POWERPLUS = 300.0f;
    private AudioSource audio;
    public AudioClip jumpSound;
    public bool isStick = false;
    public bool isStand;
    public bool isRight;

    // Use this for initialization
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 지면보다 아래(-5.0f)로 떨어지면
        if (this.transform.position.y < -10.0f)
        {
            reStart();
        }
        
        if (!isStand)
            return;

        if (Input.GetMouseButton(0))
        { // 왼쪽 버튼이 눌려있는 동안
            power += POWERPLUS * Time.deltaTime; // 힘을 비축
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isStand && !isStick)
                // 왼쪽 버튼을 놓으면
                // 비축한 힘을 x와 y에 반영해서 오른쪽 위로 점프!
                this.GetComponent<Rigidbody>().AddForce(new Vector3(power, power, 0));
            else if (isStick && isRight)
            {
                isStick = false;
                isRight = false;
                this.GetComponent<Rigidbody>().AddForce(new Vector3(-power, power, 0));
            }
            else if (isStick && !isRight)
            {
                isStick = false;

                this.GetComponent<Rigidbody>().AddForce(new Vector3(power, power, 0));
            }

            power = 0.0f; // 힘을 0으로
            this.audio.Play();

        }

        // 벽에 붙어있다면
        if (isStick)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ
                | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        else
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

       

        if (Input.GetKey(KeyCode.A))
            gameObject.transform.Translate(0, 0, -0.1f);
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.Translate(0, 0, 0.1f);

        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "LeftWall" || collision.gameObject.tag == "RightWall")
        {
            if (Input.GetMouseButtonDown(1))
            {
                isStick = true;
                if (collision.gameObject.tag == "LeftWall")
                    isRight = true;
                return;
            }
            if (Input.GetMouseButtonUp(1))
            {
                isStick = false;
                if (collision.gameObject.tag == "LeftWall")
                    isRight = false;
                
                return;
            }
        }

        isStand = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LeftWall" || collision.gameObject.tag == "RightWall")
        {
            return;
        }
        if (collision.gameObject.tag == "Monster")
            reStart();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "LeftWall" || collision.gameObject.tag == "RightWall")
        {
            return;
        }
        isStand = false;
    }

    public void reStart()
    {
        SceneManager.LoadScene("Main"); // 씬을 다시 로드
    }
}