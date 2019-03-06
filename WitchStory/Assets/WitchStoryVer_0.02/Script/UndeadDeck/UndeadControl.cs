using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UndeadControl : MonoBehaviour {

    float timer = 0;
    public Undead status=null;

    public bool onSkill;

	// Use this for initialization
	void Start () {
        onSkill = false;
        
        if (status is SkillUndead)
        {
            onSkill = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        Vector3 magePos = gameObject.GetComponent<Transform>().position;
        Vector3 movePos = magePos + new Vector3(0, status.speed, 0);

        gameObject.transform.Translate(Vector3.Lerp(magePos, movePos, Time.deltaTime) - magePos);

        
    }

    public void setStatus(Undead undead)
    {
        status = undead;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            // 제작예정, 몬스터와 만났을때 데미지를 줌
            //collision.gameObject.GetComponent<MonsterControl>().gainDamage(status.atk);

            // 충돌판정 삭제
            // 부서지는 애니메이션출력
            // 실제 오브젝트 제거
        }
    }

    void OnMouseDown()
    {
        // 스킬언데드만 적용
        if (onSkill)
        {
            StartCoroutine("UseSkill");
            Destroy(gameObject);
        }
    }

    IEnumerator UseSkill()
    {
        // 안정성을 위한 캐스팅후 처리가 제대로 안되면 탈출
        SkillUndead undead = status as SkillUndead;
        // Debug.Log("캐스팅 시도");
        if (undead == null)
            yield break;

        // Debug.Log("코루틴 실행됨");
        // 스킬실행
        undead.useSkill();
        // 지속시간 대기
        yield return new WaitForSeconds(undead.getDuration());
        // Debug.Log("코루틴 정상작동함");
        // 스킬종료
        undead.usedSkill();
    }
}
