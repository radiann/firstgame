﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    private RectTransform inventoryRect;

    private float inventoryWidth, inventoryHight;

    public int slots;

    public int rows;

    public float slotPaddingLeft, slotPaddingTop;

    public float slotSize;

    public GameObject slotPrefab;

    private List<GameObject> allSlots;
    private int emptySlot;
	// Use this for initialization
	void Start () {
        CreateLayout();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void CreateLayout()
    {
        GameObject newSlot;
        allSlots = new List<GameObject>();
        emptySlot = slots;
        inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;

        inventoryHight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

        inventoryRect = GetComponent<RectTransform>();

        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHight);

        int columns = slots / rows;

        for (int y = 0; y< rows; y++)
        {
            for (int x = 0; x <columns; x++)
            {
                if (slotPrefab)
                {
                    newSlot = Instantiate(slotPrefab);
                    RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                    newSlot.name = "Slot";

                    newSlot.transform.SetParent(transform.parent, false);

                    slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft * (x + 1) + (slotSize * x), slotPaddingTop * (y + 1) - (slotSize * y));

                    slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                    slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                    allSlots.Add(newSlot);
                }
                   
            }
        }
    }
    public bool AddItem(Item item)
    {
        if (item.maxSize == 1)
        {
            PlaceEmpty(item);
            return true;
        }
        else
        {/*
            foreach (GameObject slot in allSlots)
            {
                Slot tmp = slot.GetComponent<Slot>();
                if (!tmp.IsEmpty)
                {
                    if (tmp.CurrentItem.type == item.type && tmp.IsAvailable)
                    {
                        tmp.AddItem(item);
                        emptySlot--;
                        return true;
                    }
                }
            }
            if(emptySlot > 0)
            {
                PlaceEmpty(item);
            }*/
        }
        return false;
    }
    private bool PlaceEmpty(Item item)
    {
        if (emptySlot > 0)
        {
            foreach(GameObject slot in allSlots)
            {
                Slot tmp = slot.GetComponent<Slot>();

                if (tmp.IsEmpty)
                {
                    tmp.AddItem(item);
                    emptySlot--;
                    return true;
                }
            }
        }
        return false;
    }
}
