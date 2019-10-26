using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
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
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.Translate(new Vector3(0, -1.0f, 0));
            transform.rotation = currentRotate;
        }
        if (key == KeyCode.A)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.Translate(new Vector3(-1.0f, 0, 0));
            transform.rotation = currentRotate;
        }
        if (key == KeyCode.D)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.Translate(new Vector3(1.0f, 0, 0));
            transform.rotation = currentRotate;
        }

        timer = 0.0f;

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
}
