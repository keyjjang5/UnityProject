using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonUndeadSystem : MonoBehaviour {


    public GameObject character;
    //아래는 캐릭터 생성억제용
    public bool IsOnSummonSystem = true;

    private GameObject undeadDeck;

    // Use this for initialization
    void Start() {
        character = Resources.Load("Undead") as GameObject;
        undeadDeck = GameObject.FindGameObjectWithTag("UndeadDeck");
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void summonCharacter()
    {
        if (IsOnSummonSystem)//서몬시스템이 켜져있을 떄 들어옴
        {
            if (Input.GetMouseButtonDown(0))
            {
                UndeadDeck deck = undeadDeck.GetComponent<UndeadDeck>();
                character.GetComponent<UndeadControl>().setStatus(deck.selectUndead());
                spawnCharacter();
            }
        }
    }

    void spawnCharacter()
    {
        Vector3 sponVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (sponVec.x > -1.0 && sponVec.x < 1.0)
        {
            character.GetComponent<Transform>().position = new Vector3(sponVec.x, -4, (float)LayerType.battleField);
            GameObject mage1 = Instantiate(character) as GameObject;
            mage1.transform.SetParent(transform);
        }
        else if (sponVec.x < -1.0)
        {
            character.GetComponent<Transform>().position = new Vector3(-1, -4, (float)LayerType.battleField);
            GameObject mage1 = Instantiate(character) as GameObject;
            mage1.transform.SetParent(transform);
        }
        else if (sponVec.x > 1.0)
        {
            character.GetComponent<Transform>().position = new Vector3(1, -4, (float)LayerType.battleField);
            GameObject mage1 = Instantiate(character) as GameObject;
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
