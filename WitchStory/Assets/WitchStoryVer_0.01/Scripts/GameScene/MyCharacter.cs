using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class MageClass : MonoBehaviour {

//	// Use this for initialization
//	void Start () {

//	}

//	// Update is called once per frame
//	void Update () {

//	}
//}
[System.Serializable]
public class MyCharacter
{
    public float hp;
    public float atk;
    public float ap;
    public float speed;

    public MyCharacter()
    {
        hp = 1;
        atk = 1;
        ap = 1;
        speed = 1;
    }
    public MyCharacter(float hp, float atk, float ap, float speed)
    {
        this.hp = hp;
        this.atk = atk;
        this.ap = ap;
        this.speed = speed;
    }
};