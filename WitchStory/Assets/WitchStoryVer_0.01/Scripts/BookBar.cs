using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBar : MonoBehaviour {

    Vector3 ptS;
    Vector3 ptE;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        
    }

    void OnMouseDown()
    {
        Debug.Log("클릭은됨");
        ptS = Input.mousePosition;
    }
    void OnMouseDrag()
    {
        Debug.Log("움직일때마다 호출");
        ptE = Input.mousePosition;
        Vector3 gap = ptE - ptS;
        transform.Translate(gap);
        ptS = Input.mousePosition;
    }

    void OnMouseUp()
    {
        Debug.Log("마우스업");
        ptE = Input.mousePosition;
        Vector3 gap = ptE - ptS;
        transform.Translate(gap);
    }
}
