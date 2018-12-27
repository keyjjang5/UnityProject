using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionButton : MonoBehaviour {

    GameObject option;
    GameObject goSoket;
    GameObject backGround;

    bool nowActive;
	// Use this for initialization
	void Start () {
        option = GameObject.Find("setting");
        goSoket = GameObject.Find("soket");
        backGround = GameObject.Find("backgroundBlack");

        option.SetActive(false);
        goSoket.SetActive(false);
        nowActive = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0))
        {
            
        }
	}

    public void optionSelect()
    {
        if (!nowActive)
        {
            optionOpen();
        }
        else
        {
            optionClose();
        }
    }

    void optionOpen()
    {
        option.SetActive(true);
        goSoket.SetActive(true);
        backGround.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        nowActive = true;
    }

    void optionClose()
    {
        option.SetActive(false);
        goSoket.SetActive(false);
        backGround.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        nowActive = false;
    }
    
    private bool isPause = true;
    private void OnMouseDown()
    {
        Debug.Log(" mouseDown" + this.name);

        if (isPause)
        {
            optionOpen();
            Time.timeScale = 0;
            isPause = false;
        }
        else
        {
            optionClose();
            Time.timeScale = 1;
            isPause = true;
        }
    }
}
