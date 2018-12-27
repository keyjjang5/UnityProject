using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler {

    public int number;
    public Item item;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrag(PointerEventData data)
    {
        if (transform.childCount > 0)
            transform.GetChild(0).parent = Inventory.instance.draggingItem;
        Inventory.instance.draggingItem.GetChild(0).position = data.position + new Vector2(-37, 37);
    }
    public void OnPointerEnter(PointerEventData data)
    {
        Inventory.instance.enteredSlot = this;
    }

    public void OnPointerExit(PointerEventData data)
    {
        Inventory.instance.enteredSlot = null;
    }

    public void OnEndDrag(PointerEventData data)
    {
        Inventory.instance.draggingItem.GetChild(0).parent = transform;
        transform.GetChild(0).localPosition = Vector3.zero;

        if (Inventory.instance.enteredSlot != null)
        {
            Item tempItem = item;
            item = Inventory.instance.enteredSlot.item;
            Inventory.instance.enteredSlot.item = tempItem;
            Inventory.instance.ItemImageChange(this);
            Inventory.instance.ItemImageChange(Inventory.instance.enteredSlot);
        }
    }
}
