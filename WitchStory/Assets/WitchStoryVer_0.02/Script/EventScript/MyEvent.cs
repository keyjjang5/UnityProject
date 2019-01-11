using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// 유저가 원하는 이벤트들을 만들어 놓는 스크립트
public class MyEvent : MonoBehaviour {

    ManaSystem manaSystem;
    SummonUndeadSystem undeadSummon;

    private void Awake()
    {
        // 화면이 죽지 않게 하는 스크립트
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        // 화면 해상도를 고정하는 코드
        Screen.SetResolution(720, 1280, true);
    }

    // Use this for initialization
    void Start () {
        // 마나시스템의 제거로 사용하지 않음
        //manaSystem = GameObject.Find("SkillBoard").GetComponent<ManaSystem>();
        undeadSummon = gameObject.GetComponent<SummonUndeadSystem>();
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            lClickDownEvent();
        if (Input.GetMouseButtonUp(0))
            lClickUpEvent();
        if (Input.GetMouseButton(0))
            lClickEvent();

        if (Input.GetMouseButtonDown(1))
            rClickDownEvent();
        if (Input.GetMouseButtonUp(1))
            rClickUpEvent();
        if (Input.GetMouseButton(1))
            rClickEvent();
    }

    // 좌클릭 다운시 이벤트
    public void lClickDownEvent()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            // 마나시스템의 제거로 사용하지 않음
            //if (!manaSystem.onUpSkillBoard)
            //    manaSystem.increaseMana();
            undeadSummon.summonCharacter();
        }
    }
    // 좌클릭 업시 이벤트
    public void lClickUpEvent()
    {

    }
    // 좌클릭 유지시 이벤트
    public void lClickEvent()
    {

    }

    // 우클릭 다운시 이벤트
    public void rClickDownEvent()
    {


    }
    // 우클릭 업시 이벤트
    public void rClickUpEvent()
    {

    }
    // 우클릭 유지시 이벤트
    public void rClickEvent()
    {

    }
}
