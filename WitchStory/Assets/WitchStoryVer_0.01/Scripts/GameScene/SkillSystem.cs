using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour {

    List<MySkillSlot> skillSlotList = new List<MySkillSlot>();
    public Transform skillSlotTransform;
    MySkillSlot skillSlot;

    GameObject skillBoard;

    int slotNumber = 0;
    // Use this for initialization
    private void Awake()
    {
        
    }

    void Start () {
        //저장해놨던 장착한 스킬 4개를 읽어와서 슬롯에 맞춰서 저장
        //skillSlot.skill = new MySlow(1, 1, 10, Resources.Load<Sprite>("SkillImages/slow"), SkillType.tap);
        //Debug.Log("스킬시스템 시작됨");

        skillBoard = GameObject.Find("SkillBoard");

        for (int i = 0; i < 4; i++) //스킬슬롯 4개 생성
        {
            //Debug.Log("포문 돌아감" + i);
            Transform newSkillSlot = Instantiate(skillSlotTransform);
            newSkillSlot.name = "SkillSlot" + (i + 1);
            newSkillSlot.parent = skillBoard.transform;
            //if (newSkillSlot.GetComponent<Slot>().item.itemValue == 0)
            //{
            //    newSkillSlot.GetChild(0).gameObject.SetActive(false);
            //}
            RectTransform slotRect = newSkillSlot.GetComponent<RectTransform>();
            slotRect.anchorMin = new Vector2(0.2f * (i + 1), 0.5f);
            slotRect.anchorMax = new Vector2(0.2f * (i + 1), 0.5f);

            slotRect.offsetMin = Vector2.zero;
            slotRect.offsetMax = Vector2.zero;
            slotRect.GetComponent<RectTransform>().sizeDelta = new Vector2(100f, 100f);

            //newSkillSlot의 MySkillSlot을 skillSlotList에 추가하는거임, 이거떔에 스킬이미지가 안들어가서 망함 주의
            skillSlotList.Add(newSkillSlot.GetComponent<MySkillSlot>());
        }
        //각 슬롯에 스킬을 채워 넣음
        AddSkill(0);
        AddSkill(1);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //    StartCoroutine("UseSkill");
	}

    void AddSkill(int number)
    {
        //skillSlotList[number-1].skill = new MySlow(1, 1, 10, Resources.Load<Sprite>("SkillImages/slow"), SkillType.tap);

        //ItemDatabase.instance.items[number];
        //ItemImageChange(slotScripts[i]);

        //스킬 슬롯이 가지고 있는 스킬객체에
        //스킬 데이터 베이스의 스킬리스트에서 원하는 번호의 스킬을 넣음
        skillSlotList[slotNumber].skill = gameObject.GetComponent<MySkillDatabase>().skillList[number];
        slotNumber++;
    }
}
