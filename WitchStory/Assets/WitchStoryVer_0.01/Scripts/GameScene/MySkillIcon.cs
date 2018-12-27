using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySkillIcon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Image>().sprite = gameObject.GetComponentInParent<MySkillSlot>().skill.skillImage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
