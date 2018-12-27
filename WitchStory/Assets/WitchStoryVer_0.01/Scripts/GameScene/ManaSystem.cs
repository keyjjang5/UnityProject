using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaSystem : MonoBehaviour {

    GameObject manaBar;
    float mana = 0;

    //위아래로 움직이는 변수들
    bool onSkillBoardUp = false;
    bool onSkillBoardDown = false;
    Vector2 startPos;
    Vector2 endPos;
    GameObject skillBoard;
    bool onUpManaSystem = false;
    bool onDownManaSystem = false;
    public float manaTime;
    public bool onUpSkillBoard = false;
    //위아래로 움직이는 변수들

    //타임스케일 대신 속도를 바꾸기위한 변수
    GameObject[] mage;
    GameObject magePrefep;
    GameObject summonMage;
    float beforeSpeed = 0;

    //유닛 생성이안되도록 하는 변수
    
    // Use this for initialization
    void Start () {
        manaBar = GameObject.Find("ManaTest");
        skillBoard = GameObject.Find("SkillBoard");
        summonMage = GameObject.Find("summonMage");
        magePrefep = Resources.Load("mage_1") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        
        //올리기 내리기
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            if (mana >= 100)
                return;
            mana += 1;
            manaBar.GetComponent<Slider>().value = mana / 100;
            if(!onUpSkillBoard)
                if (startPos.y < 40)
                {
                    onSkillBoardUp = true;
                    //Debug.Log("클릭된것을 인지1" + startPos.x + "   " + startPos.y);
                }
            if(onUpSkillBoard)
                if (startPos.y > 180 && startPos.y < 260)
                {
                    onSkillBoardDown = true;
                    //Debug.Log("클릭된것을 인지2" + startPos.x + "   " + startPos.y);
                }

            //Debug.Log("클릭된것을 인지3" + startPos.x + "   " + startPos.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            if(onSkillBoardUp)
            {
                if(endPos.y - startPos.y > 40)
                {
                    onUpManaSystem = true;
                    mage = GameObject.FindGameObjectsWithTag("Mage");
                    magePrefep.GetComponent<MageMove>().character.speed = 0.5f;
                    beforeSpeed = mage[0].GetComponent<MageMove>().character.speed;
                    for (int i = 0; i < mage.Length; i++)
                    {
                        mage[i].GetComponent<MageMove>().character.speed = 0.5f;
                    }
                }
            }

            if(onSkillBoardDown)
            {
                if (startPos.y - endPos.y > 40)
                {
                    onDownManaSystem = true;
                    mage = GameObject.FindGameObjectsWithTag("Mage");
                    magePrefep.GetComponent<MageMove>().character.speed = beforeSpeed;
                    for (int i = 0; i < mage.Length; i++)
                    {
                        mage[i].GetComponent<MageMove>().character.speed = beforeSpeed;
                    }
                }
            }

            //Debug.Log("마우스 떄는 것을 인지");
        }

        if(onUpManaSystem)
        {
            //Debug.Log("들어옴");
            walk(Time.deltaTime);
        }

        if(onDownManaSystem)
        {
            //Debug.Log("나감");
            backwalk(Time.deltaTime);
        }
        //올리기 내리기
    }

    private void OnDestroy()
    {
        mage = GameObject.FindGameObjectsWithTag("Mage");
        magePrefep.GetComponent<MageMove>().character.speed = 1.5f;
        for (int i = 0; i < mage.Length; i++)
        {
            mage[i].GetComponent<MageMove>().character.speed = 1.5f;
        }
    }

    void walk(float timer)
    {
        Vector3 beforePos = skillBoard.GetComponent<Transform>().position;
        Vector3 afterPos = beforePos + new Vector3(0, 200, 0);
        skillBoard.transform.Translate(Vector3.Lerp(beforePos, afterPos, timer) - beforePos);

        manaTime += timer;


        //Time.timeScale = 1 - manaTime * 2;
        //if (Time.timeScale > 0.33)
        //    Time.timeScale = 0.33f;
        //if (Time.timeScale < 0.15)
        //    Time.timeScale = 0.15f;
        
        if (manaTime >= 1)
        {
            manaTime = 0;
            onUpManaSystem = false;
            onSkillBoardUp = false;
            onUpSkillBoard = true;
            System.Array.Clear(mage, 0, mage.Length);
            ChangeValue("SummonSkeletonSystem");
        }
    }
    void backwalk(float timer)
    {
        Vector3 beforePos = skillBoard.GetComponent<Transform>().position;
        Vector3 afterPos = beforePos + new Vector3(0, -200, 0);
        skillBoard.transform.Translate(Vector3.Lerp(beforePos, afterPos, timer) - beforePos);

        manaTime += timer;

        
        Time.timeScale = 1;
        //mage.GetComponent<MageMove>().test.speed = 1.5f;
        if (manaTime >= 1)
        {
            manaTime = 0;
            onDownManaSystem = false;
            onSkillBoardDown = false;
            onUpSkillBoard = false;
            System.Array.Clear(mage, 0, mage.Length);
            ChangeValue("SummonSkeletonSystem");
        }
    }

    void ChangeValue(string name)
    {
        GameObject value = GameObject.Find(name);
        
        value.GetComponent<SummonSkeletonSystem>().ChangeBoolValue(ref value.GetComponent<SummonSkeletonSystem>().IsOnSummonSystem);
    }
}

