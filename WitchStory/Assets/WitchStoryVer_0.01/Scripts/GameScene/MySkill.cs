using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class MySkill : MonoBehaviour {

//	// Use this for initialization
//	void Start () {

//	}

//	// Update is called once per frame
//	void Update () {

//	}
//}

[System.Serializable]
public class MySkill
{
    SkillType skillType;
    EffectType effectType;

    int manaConsume;
    int skillNumber;

    float coolTime;

    public Sprite skillImage;


    public MySkill(int _manaConsume, int _skillNumber, float _coolTime, Sprite _skillImage)
    {
        manaConsume = _manaConsume;
        skillNumber = _skillNumber;
        coolTime = _coolTime;
        skillImage = _skillImage;
    }

    public void SetSkillType(SkillType _skillType)
    {
        skillType = _skillType;
    }
    public void SetEffectType(EffectType _effectType)
    {
        effectType = _effectType;
    }
    
    public float GetCoolTime()
    {
        return coolTime;
    }
    public Sprite GetSpriteImage()
    {
        return skillImage;
    }
    virtual public void UseSkill(int skillNumber)
    {
        
    }
    virtual public void UsedSkill(int skillNumber)
    {

    }
}



public class MyAttackSkill : MySkill
{
    float attackPower;
    public MyAttackSkill(int _manaConsume, int _skillNumber, float _coolTime, Sprite _skillImage, SkillType _skillType,
        float _attackPower)
        : base(_manaConsume, _skillNumber, _coolTime, _skillImage)
    {
        SetEffectType(EffectType.attack);
        SetSkillType(_skillType);
    }
}
public class MyStickyBombSkill : MyAttackSkill
{
    public MyStickyBombSkill(int _manaConsume, int _skillNumber, float _coolTime, Sprite _skillImage, SkillType _skillType,
        float _attackPower)
        : base(_manaConsume, _skillNumber, _coolTime, _skillImage, _skillType, _attackPower)
    {
        SetEffectType(EffectType.attack);
        SetSkillType(_skillType);
    }

    override public void UseSkill(int skillNumber)//스킬사용, 추가적인 특성을 오브젝트에 부여하는 방식
    {
        Debug.Log("스티키붐 사용됨");
        GameObject target = GameObject.FindGameObjectWithTag("Undead");
        GameObject myPrefap = Resources.Load("Property") as GameObject;
       
        GameObject newProperty = MonoBehaviour.Instantiate(myPrefap);
        newProperty.name = "StikyBombProperty";
        newProperty.transform.parent = target.transform;
        newProperty.transform.position = new Vector2(target.transform.position.x + 0.1f, target.transform.position.y + 0.1f);
        //newProperty.AddComponent<AddProperty>();
        newProperty.AddComponent<StickyBomb>();
    } 
    override public void UsedSkill(int skillNumber)
    {

    }
}


public class MyDefenseSkill : MySkill
{ 
    public MyDefenseSkill(int _manaConsume, int _skillNumber, float _coolTime, Sprite _skillImage, SkillType _skillType)
        : base(_manaConsume, _skillNumber, _coolTime, _skillImage)
    {
        SetEffectType(EffectType.defense);
        SetSkillType(_skillType);
    }
}



public class MyBuffSkill : MySkill
{
    public MyBuffSkill(int _manaConsume, int _skillNumber, float _coolTime, Sprite _skillImage, SkillType _skillType)
        : base(_manaConsume, _skillNumber, _coolTime, _skillImage)
    {
        SetEffectType(EffectType.buff);
        SetSkillType(_skillType);
    }
}
public class MySlow : MyBuffSkill
{
    float slowSpeed = 0.5f;
    public MySlow(int _manaConsume, int _skillNumber, float _coolTime, Sprite _skillImage, SkillType _skillType)
        : base(_manaConsume, _skillNumber, _coolTime, _skillImage, _skillType)
    {

    }

    override public void UseSkill(int _skillNumber)
    {
        GameObject monster = GameObject.FindGameObjectWithTag("Monster");
        monster.GetComponent<slimeControl>().SpeedCoefficient(slowSpeed);
        //CoolTime(GetCoolTime());
    }

    override public void UsedSkill(int _skillNumber)
    {
        GameObject monster = GameObject.FindGameObjectWithTag("Monster");
        monster.GetComponent<slimeControl>().SpeedCoefficient(2);

    }
    public void CoolTime(float _coolTime)
    {
        _coolTime = _coolTime - Time.deltaTime;
    }

}



public class MyPassiveSkill : MySkill
{
    public MyPassiveSkill(int _manaConsume, int _skillNumber, float _coolTime, Sprite _skillImage, SkillType _skillType)
        : base(_manaConsume, _skillNumber, _coolTime, _skillImage)
    {
        SetEffectType(EffectType.passive);
        SetSkillType(_skillType);
    }
}