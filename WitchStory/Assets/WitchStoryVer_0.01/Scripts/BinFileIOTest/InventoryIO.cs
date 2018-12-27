using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryIO : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    InventoryDataIO data;

    public void Initialize()
    {
        data.weight = 0f;
        data.items = new List<ItemDataIO>();
    }

    public void AddItemDataIO()
    {

    }

    public void Save()
    {
        DataManager.BinarySerialize<InventoryDataIO>(data, /*Define.InventoryDataName*/"SaveDataTestIO");
    }

    public void Load()
    {
        data = DataManager.BinaryDeserialize<InventoryDataIO>(/*Define.InventoryDataName*/"SaveDataTestIO");

        foreach (ItemDataIO itemData in data.items)
        {
            GameObject gameObject = new GameObject();
            gameObject.name = itemData.name;
            gameObject.transform.SetParent(transform);
            gameObject.transform.localPosition = itemData.position;

            Image itemImage = gameObject.AddComponent<Image>();
            itemImage.sprite = Resources.Load<Sprite>(itemData.spritePath);

            ItemIO item = gameObject.AddComponent<ItemIO>();
            item.data = itemData;
        }
    }
}
