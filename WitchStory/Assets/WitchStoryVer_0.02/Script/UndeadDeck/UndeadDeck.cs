using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadDeck : MonoBehaviour {

    // 언데드 실제 덱
    public List<Undead> deck;
    // 언데드 견본 덱 : 덱에서 중복되지 않는 것들이 있음
    public HashSet<Undead> hashSetDeck;
    // 총합 가중치
    public float totalWeight;
    

	// Use this for initialization
	void Start () {
        // 게임을 시작할 때 초기화
        totalWeight = 0;
		foreach(Undead undead in deck)
        {
            totalWeight += undead.weight;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addUndead(int num)
    {
        // 새로운 Undead가 추가 될때 마다 갱신
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
