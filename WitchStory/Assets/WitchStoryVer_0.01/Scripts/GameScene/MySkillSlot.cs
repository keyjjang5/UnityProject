using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MySkillSlot : MonoBehaviour, IPointerClickHandler
{
    public MySkill skill;

    // Use this for initialization
    private void OnEnable()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData data)
    {
        StartCoroutine("UseSkill");
    }

    IEnumerator UseSkill()
    {
        Debug.Log("코루틴 실행됨");
        skill.UseSkill(1);
        yield return new WaitForSeconds(skill.GetCoolTime());
        Debug.Log("코루틴 정상작동함");
        skill.UsedSkill(1);
    }
}
