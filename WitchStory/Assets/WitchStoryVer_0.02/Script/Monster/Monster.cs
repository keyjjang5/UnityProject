using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
// 몬스터의 루트 클래스
public class Monster
{
    // 체력(현재, 최대)
    float hp;
    float maxHp;
    // 넉백치(현재, 최대)
    float np;
    float maxNp;
    // 이동거리(현재, 기본값)
    float nMoveDistance; // Now Move Distance
    float moveDistance;
    // 이동쿨타임(현재, 기본값)
    float nMoveDelay;
    float moveDelay;
    // 공격속도(현재, 기본값)
    float nAttackSpeed;
    float attackSpeed;
    // 방어력(일반, 넉백)
    float defence;
    float nDefence;
    // 이름
    string name;
    // 설명(특징 등)
    string toolTip;
    //


    // 기본 기능
    // 전진
    // 후진
    // 공격
    
    // 추가 기능
    // 각종 기술들
}
