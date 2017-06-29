﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour {
    private Stack<Item> items;

    public Text stackTxt;
    public Sprite slotEmpty;
    public Sprite slotHighlight;

    public bool IsEmpty
    {
        get { return items.Count == 0; }
    }
    public bool IsAvailable
    {
        get { return CurrentItem.maxSize > items.Count; }
    }
    public Item CurrentItem
    {
        get { return items.Peek(); }
    }
	// Use this for initialization
	void Start () {
        items = new Stack<Item>();
        RectTransform slotRect = GetComponent<RectTransform>();
        RectTransform txtRect = stackTxt.GetComponent<RectTransform>();

        int txtscleFactor = (int)(slotRect.sizeDelta.x * 0.60);
        stackTxt.resizeTextMaxSize = txtscleFactor;
        stackTxt.resizeTextMinSize = txtscleFactor;
        txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRect.sizeDelta.x);
        txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRect.sizeDelta.y);

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void AddItem(Item item)
    {
        items.Push(item);

        if(items.Count > 1)
        {
            stackTxt.text = items.Count.ToString();
        }

        ChangeSprite(item.spriteNeutral, item.spriteHighlighted);
    }
    private void ChangeSprite(Sprite neutral, Sprite highlight)
    {
        GetComponent<Image>().sprite = neutral;

        SpriteState st = new SpriteState();

        st.highlightedSprite = highlight;

        st.pressedSprite = neutral;

        GetComponent<Button>().spriteState = st;
    }
}
