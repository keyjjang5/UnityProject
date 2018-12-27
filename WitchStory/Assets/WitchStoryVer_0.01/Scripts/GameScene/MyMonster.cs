using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonster : MonoBehaviour
{
    public MyObject obj;
    MonsterType type;
    float moveTime;
    
    // Use this for initialization
    void Start()
    {
        obj = new MyObject(ObjectType.creature, Resources.Load<Sprite>("ItemImages/" + 1), 1000, 10, 500, 1.5f);

        StartCoroutine(WalkSystem());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    StartCoroutine(Walk(1, 1));
        //    moveTime = 0;
        //}
            
    }

    IEnumerator Walk(float _moveTime = 1, float _moveSpeed = 1)
    {
        Vector3 monsterPos = transform.position;
        Vector3 movePos = monsterPos + new Vector3(0, obj.speed, 0);
        transform.Translate(Vector3.Lerp(monsterPos, movePos, Time.deltaTime * 100 / (_moveSpeed * 100)) - monsterPos);
        moveTime += Time.deltaTime;
        yield return null;

        if (moveTime <= _moveTime)
            StartCoroutine(Walk(_moveTime, _moveSpeed));
    }

    IEnumerator WalkSystem(float _delayTime = 2, float _moveTime = 1, float _moveSpeed = 1)
    {
        while(true)
        {
            yield return new WaitForSeconds(_delayTime);
            StartCoroutine(Walk(_moveTime, _moveSpeed));
            moveTime = 0;
        }
    }
}

public class MyBigMonster : MyMonster
{

}

//[System.Serializable]
//public class MyMonster
//{
//    float hp;
//    float ap;
//    float atk;
//    float speed;
//    MonsterType type;
//    Sprite image;

//    MyMonster(float _hp, float _ap, float _atk, float _speed, MonsterType _type)
//    {
//        hp = _hp;
//        ap = _ap;
//        atk = _atk;
//        speed = _speed;
//        type = _type;
//    }

//    void Walk()
//    {
            
//    }

//    IEnumerator Walllk()
//    {
//        Vector3 slimePos = slime.GetComponent<Transform>().position;
//        Vector3 movePos = slimePos + new Vector3(0, speed, 0);
//        slime.transform.Translate(Vector3.Lerp(slimePos, movePos, timer) - slimePos);
//        knockbackTime += timer;
        
//    }
//}
