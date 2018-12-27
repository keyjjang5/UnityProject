using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoketPanel : MonoBehaviour {

    public static SoketPanel instance;
    public Transform soket;
    public List<Soket> soketScripts = new List<Soket>();

    public Transform draggingItem;

    public Soket enteredSoket;

    public int row;
    public int column;

    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }

    void Start () {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Transform newSoket = Instantiate(soket);
                newSoket.name = "Soket_" + (i + 1) + "_" + (j + 1);
                newSoket.parent = transform;
                //if (newSoket.GetComponent<Soket>().sign.value == 0)
                //{
                //    newSoket.GetChild(0).gameObject.SetActive(false);
                //}
                RectTransform soketRect = newSoket.GetComponent<RectTransform>();
                soketRect.anchorMin = new Vector2(0.3f * j + 0.05f, 1 - (0.3f * (i + 1) - 0.05f));
                soketRect.anchorMax = new Vector2(0.3f * (j + 1) - 0.05f, 1 - (0.3f * i + 0.05f));
                soketRect.offsetMin = Vector2.zero;
                soketRect.offsetMax = Vector2.zero;

                soketScripts.Add(newSoket.GetComponent<Soket>());
                newSoket.GetComponent<Soket>().number = i * 2 + j;
            }
        }
        //소켓슬롯을 자동으로 생성하는 코드, 필요없다 판단하여 주석처리

        AddItem(0);
        AddItem(1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddItem(int number)
    {
        for (int i = 0; i < soketScripts.Count; i++)
        {
            if (soketScripts[i].sign.value == 0)
            {
                soketScripts[i].sign = SignDatabase.instance.signs[number];
                SignImageChange(soketScripts[i]);
                break;
            }
        }
    }

    public void SignImageChange(Soket _soket)
    {
        if (_soket.sign.value == 0)
            _soket.transform.GetChild(0).gameObject.SetActive(false);
        else
        {
            _soket.transform.GetChild(0).gameObject.SetActive(true);
            _soket.transform.GetChild(0).GetComponent<Image>().sprite = _soket.sign.image;
        }
    }
}
