using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMonsterSystem : MonoBehaviour {

    public Transform monster;

    // Use this for initialization
    private void Awake()
    {
        Transform newMonster = Instantiate(monster);
        newMonster.name = "monster";
        newMonster.tag = "Monster";
        newMonster.parent = transform;
        newMonster.transform.position = new Vector3(0, 4, (float)LayerType.battleField);
    }

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
