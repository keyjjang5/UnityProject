using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadDeck : MonoBehaviour {

    // 언데드 실제 덱
    public List<Undead> deck = new List<Undead>();
    // 언데드 견본 덱 : 덱에서 중복되지 않는 것들이 있음 : 사용할 이유가 없어서 제거
    // 총합 가중치
    public float totalWeight;
    public GameObject undeadDatabase;

	// Use this for initialization
	void Start () {
        addUndead(2);
        

        // 게임을 시작할 때 초기화
        totalWeight = 0;
		foreach(Undead undead in deck)
        {
            totalWeight += undead.weight;
        }
        undeadDatabase = GameObject.Find("Database");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addUndead(int num = 0)
    {
        // Database에 있는 정보를 꺼내와서 deck 에 저장
        deck.Add(undeadDatabase.GetComponent<UndeadDatabase>().getUndead(num));
        // 새로운 Undead가 추가 될때 마다 갱신
        totalWeight = 0;
        foreach (Undead undead in deck)
        {
            totalWeight += undead.weight;
        }
    }

    public void deleteUndead(int num = 0)
    {
        deck.RemoveAt(num);
        // UndeadDeck이 변화 할 때 마다 갱신
        totalWeight = 0;
        foreach (Undead undead in deck)
        {
            totalWeight += undead.weight;
        }
    }

    // 소환될 언데드를 선택하는 함수
    public Undead selectUndead()
    {
        Undead summonUndead = null;
        float random = 0;
        random = Random.Range(0, totalWeight);
        float weight = 0;
        foreach(Undead undead in deck)
        {
            if (random >= weight && random <= weight + undead.weight)
            {
                summonUndead = undead;
                break;
            }
            else
                weight += undead.weight;
        }

        if (summonUndead == null)
            return null;
        else
            return summonUndead;
    }
}
