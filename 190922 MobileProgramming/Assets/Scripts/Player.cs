using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject[] monsterArr;
    GameObject oldTarget;
    // Color baseColor = new Color(102, 128, 255, 255);
    public Material targetMonMat;
    public Material baseMonMat;


    // Use this for initialization
    void Start () {
        monsterArr = GameObject.FindGameObjectsWithTag("Monster");
        oldTarget = monsterArr[0];
        searchNearestMon();
	}
	
	// Update is called once per frame
	void Update () {
        // 키가 눌린게 없으면 일 안함
        if (Input.anyKeyDown == false)
            return;

        // 누른 키에 따라 이동
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            move(0, 0.2f);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            move(0, -0.2f);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            move(0.2f, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            move(-0.2f, 0);

        searchNearestMon();
	}

    // 가장 가까이에 있는 몬스터를 찾고 색을 바꾸는 함수
    void searchNearestMon()
    {
        GameObject shortestMon = monsterArr[0];
        float shortestDis = Vector3.Distance(shortestMon.transform.position,
                                             transform.position);

        // 가장 가까이에 있는 몬스터 찾기
        foreach (GameObject mon in monsterArr)
        {
            Vector3 monPos = mon.transform.position;
            Vector3 myPos = transform.position;
            float distance = Vector3.Distance(myPos, monPos);
            Debug.Log("Distance : " + distance);
            if (distance < shortestDis)
            {
                shortestDis = distance;
                shortestMon = mon;
            }
        }

        // 가장 가까이에 있는 몬스터 색 바꾸기
        oldTarget.GetComponent<MeshRenderer>().material = baseMonMat;
        shortestMon.GetComponent<MeshRenderer>().material = targetMonMat;
        //oldTarget.GetComponent<Material>().SetColor(oldTarget.name, baseColor);
        //shortestMon.GetComponent<Material>().SetColor(shortestMon.name, Color.red);

        // 오래된 대상 갱신하기
        oldTarget = shortestMon;
    }

    // 플레이어 이동용 함수
    void move(float x, float z)
    {
        transform.Translate(x, 0, z);
    }
}
