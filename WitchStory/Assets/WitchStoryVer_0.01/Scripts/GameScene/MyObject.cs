using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class MyObject : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
		
//	}
	
//	// Update is called once per frame
//	void Update () {
		
//	}
//}

[System.Serializable]

public class MyObject
{
    public float hp;
    public float atk;
    public float ap;
    public float speed;
    ObjectType objectType;
    Sprite image;

    public MyObject(ObjectType _objectType, Sprite _image, float _hp = 0, float _atk = 0, float _ap = 0, float _speed = 0)
    {
        hp = _hp;
        atk = _atk;
        ap = _ap;
        speed = _speed;
        objectType = _objectType;
        image = _image;
    }
}
