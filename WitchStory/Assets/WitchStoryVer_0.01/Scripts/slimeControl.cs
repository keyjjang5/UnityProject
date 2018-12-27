using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slimeControl : MonoBehaviour
{
    //스텟
    public float maxHp = 1000;
    public float HP = 1000;
    public float AP = 0;
    public float atk = 10;
    public float def = 1.0f;   // 물리방어(스켈레톤 몸박)
    float mdef = 1.0f;  // 마법방어
    float adef = 1.0f;  // 넉백방어

    public GameObject slime;
    public GameObject mage;
    GameObject HpTest;
    GameObject ApTest;
    float knockbackTime = 0;
    float walkTime = 0;
    float walksettingTime = 0;
    bool slimeCheck = false;
    float save;

    public int phase = 0;       // 몬스터의 페이즈 0~2까지 있음
    public float attackMotion;   // 공격 사이 간격 1-phase*0.1
    public float attackDelay;
    public bool isAttack = false;
    public GameObject attackBox;


    //public MySkill* rush;       // 1.5초 동안 타격받지 않으면 돌진 스킬 사용



    //스킬에 사용하기위한 이동속도 변수화
    public float speed = 0.5f;
    // Use this for initialization
    void Start()
    {
        slime = GameObject.FindGameObjectWithTag("Monster");
        mage = Resources.Load("mage_1") as GameObject;
        HpTest = GameObject.Find("HPtest");
        ApTest = GameObject.Find("APtest");

        attackMotion = 1.0f;
        StartCoroutine(changePhase());
    }

    // Update is called once per frame
    void Update()
    {
        //float moveSpeed = 0.5f;

        float timer = Time.deltaTime;
        //slimeTime += timer;

        walkTime += timer;

        //예전버전
        //if(save >= slimeTime)
        //{
        //    return;
        //}
        //else if (slimeCheck)
        //{
        //    slimeTime = 0;
        //    save = 0;
        //    slimeCheck = false;
        //}

        //if (slimeTime >= 1 / 60 && !slimeCheck)
        //{
        //    Vector3 movePos = new Vector3(0, -1, 0) * moveSpeed * slimeTime;
        //    slime.transform.Translate(movePos);

        //    slimeTime = 0;
        //}

        //HpTest.GetComponent<Slider>().value = HP / 1000;
        //ApTest.GetComponent<Slider>().value = AP / 200;

        //페이즈 변화
        if (phase == 0 && HP <= maxHp * 2 / 3)
            phase = 1;
        if (phase == 1 && HP <= maxHp / 3)
            phase = 2;

        //페이즈별 행동


        //공격
        if (isAttack)
            attackMotion -= timer;

        if (isAttack && attackMotion <= 0)
            attack();

        //죽으면
        if (HP <= 0)
        {
            Destroy(gameObject);
            Destroy(HpTest);
            Destroy(ApTest);
        }

        // 넉백치가 다차면 뒷걸음
        if (AP > 200)
        {
            backStep(timer);
        }

        // 일정시간마다 걷기
        if (walkTime >= 3.0f)
        {
            walk(timer);

        }



        // 키입력으로 공격(임시)
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            isAttack = true;
            AttackBox.isAttack = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mage")
        {
            slime.GetComponent<slimeControl>().HP -= mage.GetComponent<MageMove>().character.atk;
            //knockBack();
            AP += mage.GetComponent<MageMove>().character.ap;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mage" && !isAttack)
        {
            slime.GetComponent<slimeControl>().HP -= mage.GetComponent<MageMove>().character.atk * def;
            //knockBack();
            AP += mage.GetComponent<MageMove>().character.ap;
        }
    }

    //void knockBack()
    //{
    //    Vector3 movePos = new Vector3(0, 1, 0) * mage.GetComponent<mageMove>().knockBack;
    //    slime.transform.Translate(movePos);
    //    Debug.Log("넉백되고있음");
    //    save = knockbackTime + 1;

    //    slimeCheck = true;
    //}

    void backStep(float timer)
    {
        Vector3 slimePos = slime.GetComponent<Transform>().position;
        Vector3 movePos = slimePos + new Vector3(0, speed, 0);
        slime.transform.Translate(Vector3.Lerp(slimePos, movePos, timer) - slimePos);
        knockbackTime += timer;
        if (knockbackTime >= 1)
        {
            AP = 0;
            knockbackTime = 0;
        }
    }

    void walk(float timer)
    {
        Vector3 slimePos = slime.GetComponent<Transform>().position;
        Vector3 movePos = slimePos + new Vector3(0, -speed, 0);
        slime.transform.Translate(Vector3.Lerp(slimePos, movePos, timer) - slimePos);

        walksettingTime += timer;
        if (walksettingTime >= 1)
        {
            walksettingTime = 0;
            walkTime = 0;
        }

    }

    void attack()
    {
        //애니메이션실행

        attackMotion = 1.0f;
        isAttack = false;
    }

    //스킬을 위한 함수?
    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }
    public void SpeedCoefficient(float _speed)
    {
        speed = speed * _speed;
    }

    IEnumerator changePhase()
    {
        while (phase != 2)
        {
            if (phase == 1)
            {
                def = 0.75f;
                mdef = 1.25f;
            }
            yield return new WaitForSeconds(1.0f);
        }

        if (phase == 2)
        {
            def = 0.5f;
            mdef = 1.5f;

        }
    }
}
