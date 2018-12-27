using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySkillDatabase : MonoBehaviour {

    public List<MySkill> skillList;

    // Use this for initialization
    private void Awake()
    {
        skillList.Add(new MySlow(1, 0, 10, Resources.Load<Sprite>("SkillImage/slow"), SkillType.tap));
        skillList.Add(new MyStickyBombSkill(1, 1, 10, Resources.Load<Sprite>("SkillImage/bomb"), SkillType.tap, 10));
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddMySkill(MySkill mySkill)
    {
        skillList.Add(mySkill);
    }
}
