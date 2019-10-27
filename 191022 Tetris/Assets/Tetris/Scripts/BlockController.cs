﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private float timer;
    // y는 그대로가 자기위치 x는 -1 해준 것이 자기위치
    public Vector2[] pos = new Vector2[4];
    private GameObject gameManagerObj;
    private GameManager gameManager;

    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        for (int i = 0; i < 4; i++)
        {
            pos[i] = transform.GetChild(i).position;
        }
        gameManagerObj = GameObject.Find("GameBoard");
        gameManager = GameObject.Find("GameBoard").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;

        timer += Time.deltaTime;

        // 테트리스 블록이 아니면 종료
        if (transform.tag != "TetrisBlock")
            return;

        if (timer >= 0.2f && Input.anyKey)
        {
            if (Input.GetKey(KeyCode.S))
                move(KeyCode.S);
            if (Input.GetKey(KeyCode.A))
                move(KeyCode.A);
            if (Input.GetKey(KeyCode.D))
                move(KeyCode.D);
            if (Input.GetKey(KeyCode.W))
                spin(KeyCode.W);
            if (Input.GetKey(KeyCode.Space))
                fall();

            return;
        }

        if (timer >= 0.5f)
            move(KeyCode.S);
    }

    void move(KeyCode key)
    {
        Quaternion currentRotate = transform.rotation;

        if (key == KeyCode.S)
        {
            for (int i = 0; i < 4; i++)
                if (gameManager.isThere(-(int)pos[i].x, -(int)pos[i].y))
                {
                    stop();
                    return;
                }
            
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.Translate(new Vector3(0, -1.0f, 0));
            transform.rotation = currentRotate;
        }
        if (key == KeyCode.A)
        {
            for (int i = 0; i < 4; i++)
                if (gameManager.isThere(-(int)pos[i].x + 1, -(int)pos[i].y-1))
                    return;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.Translate(new Vector3(-1.0f, 0, 0));
            transform.rotation = currentRotate;
        }
        if (key == KeyCode.D)
        {
            for (int i = 0; i < 4; i++)
                if (gameManager.isThere(-(int)pos[i].x - 1, -(int)pos[i].y-1))
                    return;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.Translate(new Vector3(1.0f, 0, 0));
            transform.rotation = currentRotate;
        }

        timer = 0.0f;
        for (int i = 0; i < 4; i++)
        {
            pos[i] = transform.GetChild(i).position;
        }

        return;
    }

    void spin(KeyCode key)
    {
        if (key != KeyCode.W)
            return;

        transform.Rotate(new Vector3(0, 0, 90.0f));

        timer = 0.0f;

        return;
    }

    void stop()
    {
        // Update() 활동정지
        transform.tag = "Stop";
        isActive = false;

        // GameManager에 공간 점유 전달
        for (int i = 0; i < 4; i++)
            gameManager.fillBoard(-(int)pos[i].x, -(int)pos[i].y - 1);

        transform.SetParent(gameManagerObj.transform);
    }

    void fall()
    {
        Quaternion currentRotate = transform.rotation;
        while (true)
        {
            for (int i = 0; i < 4; i++)
                if (gameManager.isThere(-(int)pos[i].x, -(int)pos[i].y))
                {
                    stop();
                    return;
                }

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.Translate(new Vector3(0, -1.0f, 0));
            transform.rotation = currentRotate;

            for (int i = 0; i < 4; i++)
            {
                pos[i] = transform.GetChild(i).position;
            }
        }
    }

    public void setIsActive(bool b)
    {
        isActive = b;
    }
}
