using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Soket : MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler
{

    public int number;
    public Sign sign;

    // Use this for initialization
    private void Awake()
    {
        
    }

    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrag(PointerEventData data)
    {
        if (transform.childCount > 0)
            transform.GetChild(0).parent = SoketPanel.instance.draggingItem;
        SoketPanel.instance.draggingItem.GetChild(0).position = data.position + new Vector2(-52, 50);
    }
    public void OnPointerEnter(PointerEventData data)
    {
        SoketPanel.instance.enteredSoket = this;
    }

    public void OnPointerExit(PointerEventData data)
    {
        SoketPanel.instance.enteredSoket = null;
    }

    public void OnEndDrag(PointerEventData data)
    {
        SoketPanel.instance.draggingItem.GetChild(0).parent = transform;
        transform.GetChild(0).localPosition = Vector3.zero;

        if (SoketPanel.instance.enteredSoket != null)
        {
            Sign tempSign = sign;
            sign = SoketPanel.instance.enteredSoket.sign;
            SoketPanel.instance.enteredSoket.sign = tempSign;
            SoketPanel.instance.SignImageChange(this);
            SoketPanel.instance.SignImageChange(SoketPanel.instance.enteredSoket);
        }
    }
}
