using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// Undead의 루트 클래스
public class Undead{

    // 모두가 가지고 있음
    // 번호
    public int num;
    // 공격력
    private float atk;
    // 넉백치
    private float nAtk;
    // 가중치
    public float weight;
    // 덱에 들어온 순서(번호)
    private int enteredNum;
    // 이동속도
    public float speed;

    // 일부가 가지고 있음
    // 스킬이 있다면 스킬
    // 스킬 공격력
    // 스킬 지속시간
    // 

    public Undead(int num, float atk, float nAtk, float weight, int enteredNum, float speed)
    {
        this.num = num;
        this.atk = atk;
        this.nAtk = nAtk;
        this.weight = weight;
        this.enteredNum = enteredNum;
        this.speed = speed;
    }

    virtual public void useSkill()
    {

    }

    virtual public void setStatus(Undead other)
    {
        num = other.num;
        atk = other.atk;
        nAtk = other.nAtk;
        weight = other.weight;
        enteredNum = other.enteredNum;
        speed = other.speed;
    }
}

// 언데드덱의 기본 언데드
public class BaseUndead : Undead
{
    public BaseUndead(int num, float atk, float nAtk, float weight, int enteredNum, float speed) : base(num, atk, nAtk, weight, enteredNum, speed)
    {

    }
}
