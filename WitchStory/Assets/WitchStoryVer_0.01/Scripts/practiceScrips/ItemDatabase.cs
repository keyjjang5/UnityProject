using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public static ItemDatabase instance;
    public List<Item> items = new List<Item>();

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        instance = this;
        Add("axe", 1, 500, "Good AXe", ItemType.Equipment);
        Add("apple", 1, 50, "Delicious Apple", ItemType.Consumption);
    }

    void Add(string itemName, int itemValue, int itemPrice, string itemDesc, ItemType itemType)
    {
        items.Add(new Item(itemName, itemValue, itemPrice, itemDesc, itemType,
            Resources.Load<Sprite>("ItemImages/" + itemName)));

    }
}
