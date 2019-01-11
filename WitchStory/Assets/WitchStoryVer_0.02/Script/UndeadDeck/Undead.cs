using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[System.Serializable]
// Undead의 루트 클래스
public class Undead{

    // 모두가 가지고 있음
    // 이름
    public string name;
    // 번호
    public int num;
    // 공격력
    private float atk;
    // 넉백치
    private float nAtk;
    // 가중치
    public float weight;
    // 덱에 들어온 순서(번호) : 이런게 왜있음 > 이상해서 없앰
    // 이동속도
    public float speed;
    // 효과 설명
    public string effectToolTip;

    // 일부가 가지고 있음
    // 스킬이 있다면 스킬
    // 스킬 공격력
    // 스킬 지속시간
    // 

    public Undead(string name, int num, float atk, float nAtk, float weight, float speed, string effectToolTip)
    {
        this.name = name;
        this.num = num;
        this.atk = atk;
        this.nAtk = nAtk;
        this.weight = weight;
        this.speed = speed;
        this.effectToolTip = effectToolTip;
    }

    virtual public void useSkill()
    {

    }

    virtual public void setStatus(Undead other)
    {
        name = other.name;
        num = other.num;
        atk = other.atk;
        nAtk = other.nAtk;
        weight = other.weight;
        speed = other.speed;
        effectToolTip = other.effectToolTip;
    }
}

// 언데드덱의 기본 언데드
public class BaseUndead : Undead
{
    public BaseUndead(string name, int num, float atk, float nAtk, float weight, float speed, string effectToolTip)
        : base(name, num, atk, nAtk, weight, speed, effectToolTip)
    {

    }
}

public class AtkUndead : Undead
{
    public AtkUndead(string name, int num, float atk, float nAtk, float weight, float speed, string effectToolTip)
        : base(name, num, atk, nAtk, weight, speed, effectToolTip)
    {

    }
}

public class SkillUndead : Undead
{
    public SkillUndead(string name, int num, float atk, float nAtk, float weight, float speed, string effectToolTip)
        : base(name, num, atk, nAtk, weight, speed, effectToolTip)
    {

    }

    public void OnPointerClick(PointerEventData data)
    {
        
    }

    IEnumerator UseSkill()
    {
        yield return null;
    }
}

