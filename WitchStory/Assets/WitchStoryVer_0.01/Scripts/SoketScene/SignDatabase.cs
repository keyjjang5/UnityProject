using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignDatabase : MonoBehaviour {

    public static SignDatabase instance;
    public List<Sign> signs = new List<Sign>();

    // Use this for initialization
    void Awake()
    {
        instance = this;
        Add("axe", 1, "test", SignType.mage, 3, 20, 20, 0);
        Add("apple", 1, "testapple", SignType.warrior, 3, 0, 20, 0);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Add(string name, int value, string comment, SignType type, float influence, float power, float damage, float range)
    {
        signs.Add(new Sign(name, value, comment, type, influence,power,damage,range,
            Resources.Load<Sprite>("ItemImages/" + name)));

    }
}
