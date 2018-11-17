using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBlock : MonoBehaviour {

    public bool isAction = false;
    public float timer = 0f;
    public float actionTime = 5f; // 행동에 걸리는 시간
    public GameObject arrow;
    public GameObject slider;

    // Use this for initialization
    void Start () {
        slider = GameObject.Find("ActionBar");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if(Input.GetMouseButtonDown(0) && !isAction)
        {
            isAction = true;
            slider.GetComponent<ActionBar>().on();
            StartCoroutine(actionTimer());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isAction = false;
        StopCoroutine(actionTimer());
        timer = 0f;
        slider.GetComponent<Slider>().value = timer;
        slider.GetComponent<ActionBar>().off();
    }

    IEnumerator actionTimer()
    {
        while(isAction)
        {
            timer += Time.deltaTime / actionTime;
            slider.GetComponent<Slider>().value = timer;
            if (timer >= 1.0f)
            {
                action();
                
                timer = 0;
                slider.GetComponent<Slider>().value = timer;
                break;
            }
            yield return null;
        }
        slider.GetComponent<ActionBar>().off();
    }

    void action()
    {
        GameObject newArrow = Instantiate(arrow);
        newArrow.transform.SetParent(transform);
    }
}
