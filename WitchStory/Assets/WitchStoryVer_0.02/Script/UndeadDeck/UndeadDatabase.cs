using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadDatabase : MonoBehaviour {

    // 리스트의 인덱스는 0부터 시작
    // Undead들의 데이터 베이스
    public List<Undead> list;

    private void Awake()
    {
        addUndead(new BaseUndead("Base Undead", 0, 5, 5, 5, 5, "Tool Tip"));
        addUndead(new AtkUndead("Atk Undead", 1, 15, 5, 5, 2, "Tool Tip22"));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void addUndead(string name, int num, float atk, float nAtk, float weight, float speed, string effectToolTip)
    {
        list.Add(new Undead(name, num, atk, nAtk, weight, speed, effectToolTip));
    }

    private void addUndead(Undead newUndead)
    {
        list.Add(newUndead);
    }

    public Undead getUndead(int num)
    {
        return list[num];
    }
}
