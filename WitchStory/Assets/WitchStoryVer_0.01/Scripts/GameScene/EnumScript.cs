using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class EnumScript : MonoBehaviour {

//	// Use this for initialization
//	void Start () {

//	}

//	// Update is called once per frame
//	void Update () {

//	}
//}

public enum ObjectType
{
    stuff,
    creature
}

public enum SkillType
{
    tap,
    slide,
    quick
}

public enum EffectType
{
    attack,
    defense,
    buff,
    passive
}

public enum MonsterType
{
    big,
    small,
    boss
}

public enum LayerType
{
    battleField,
    itemObject,
    tile,
    backGround
}