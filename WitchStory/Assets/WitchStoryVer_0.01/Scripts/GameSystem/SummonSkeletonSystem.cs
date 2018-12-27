using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonSkeletonSystem : MonoBehaviour {

    
    public GameObject mage1Pre;
    float speed = 0;
    //아래는 캐릭터 생성억제용
    public bool IsOnSummonSystem = true;
	// Use this for initialization
	void Start () {
        mage1Pre = Resources.Load("mage_1") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsOnSummonSystem)//서몬시스템이 켜져있을 떄 들어옴
        {
            if (Input.GetMouseButtonDown(0))
            {
                //float randomX = Random.Range(-100, 100);
                //Vector3 testVec = new Vector3(randomX/100, -4, 0);
                //mage1Pre.GetComponent<Transform>().position = testVec;
                //GameObject mage1 = Instantiate(mage1Pre) as GameObject;

                SummonCharacter();
            }
        }
	}

    void SummonCharacter()
    {
        Vector3 sponVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (sponVec.x > -1.0 && sponVec.x < 1.0)
        {
            mage1Pre.GetComponent<Transform>().position = new Vector3(sponVec.x, -4, (float)LayerType.battleField);
            GameObject mage1 = Instantiate(mage1Pre) as GameObject;
            mage1.transform.SetParent(transform);
        }
        else if (sponVec.x < -1.0)
        {
            mage1Pre.GetComponent<Transform>().position = new Vector3(-1, -4, (float)LayerType.battleField);
            GameObject mage1 = Instantiate(mage1Pre) as GameObject;
            mage1.transform.SetParent(transform);
        }
        else if (sponVec.x > 1.0)
        {
            mage1Pre.GetComponent<Transform>().position = new Vector3(1, -4, (float)LayerType.battleField);
            GameObject mage1 = Instantiate(mage1Pre) as GameObject;
            mage1.transform.SetParent(transform);
        }
    }

    public void ChangeBoolValue(ref bool value)
    {
        if (value)
            value = false;
        else if (!value)
            value = true;
    }

    public bool GetIsOnSummonSystem()
    {
        return IsOnSummonSystem;
    }
}
