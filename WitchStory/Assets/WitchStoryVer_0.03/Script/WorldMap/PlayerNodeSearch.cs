using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNodeSearch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 노드가 플레이어가 이동할 수 있는 곳에 있는지 확인하는 함수
    // 부모자식관계에 의존하기 때문에 맵을 만들떄 상속된 대로만 사용가능
    public void checkNode(Transform node)
    {
        int count = transform.parent.childCount - 1;
        for(int i =0;i<count;i++)
        {
            if(transform.parent.GetChild(i) == node)
            {
                moveNode(node);
            }
        }

        if (transform.parent.parent == node)
            moveNode(node);
    }

    public void moveNode(Transform node)
    {
        transform.SetParent(node);
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
