using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEngine.UI;

public class InventoryXML : MonoBehaviour {
    public ItemContainerXML itemContainer
    {
        get;
        private set;
    }

    public List<Transform> items
    {
        get;
        private set;
    }

    public GameObject instance
    {
        get;
        private set;
    }

    string dir = Path.Combine(Application.dataPath, "Resources/XML/items.xml");

    //초기화
    public void Initialize()
    {
        if (GameObject.Find("Inventory") == null)
        {
            GameObject _inventory = Resources.Load<GameObject>("Prefab/Inventory");
            GameObject canvas = GameObject.Find("Canvas");

            instance = Instantiate(_inventory, canvas.transform);

            instance.name = "Inventory";
        }

        //파일이 존재하는지 체크합니다.
        //만약 파일이 없다면 새로운 XML을 만듭니다.
        //파일이 있다면 XML을 로드합니다.

        FileInfo info = new FileInfo(dir);

        //파일 존재X
        //새로운 아이템 컨테이너를 만들고 XML로 만든다.
        if (!info.Exists)
        {
            itemContainer = new ItemContainerXML();

            itemContainer.Save(dir);
        }
        //아이템 로드
        else
        {
            Load();
        }
    }

    //아이템 추가 하는 함수
    public void AddItem(ItemXML item)
    {
        itemContainer.items.Add(item);
        Save();
        Load();
    }

    public void Save()
    {
        itemContainer.Save(dir);
    }

    public void Load()
    {
        itemContainer = ItemContainerXML.Load(dir);

        if (instance.transform.childCount <= 0)
        {
            return;
        }

        items = new List<Transform>(instance.GetComponentsInChildren<Transform>());

        if (items != null)
        {
            foreach (ItemXML item in itemContainer.items)
            {
                items[item.gridCount * 2].name = "Change";
                items[item.gridCount * 2].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Texture/" + item.textureName);
            }
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
