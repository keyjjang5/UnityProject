using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class NodeControl : MonoBehaviour//, IPointerClickHandler
{
    Transform parent;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        parent = transform.parent;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void OnPointerClick(PointerEventData data)
    //{

    //}

    private void OnMouseDown()
    {
        Debug.Log("클릭됨");
        player.GetComponent<PlayerNodeSearch>().checkNode(transform);
    }
}
