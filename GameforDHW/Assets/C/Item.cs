using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { STONE, FULL,RING };
public class Item : MonoBehaviour {
    public ItemType type;
    public Sprite spriteNeutral;
    public Sprite spriteHighlighted;
    public int maxSize;

public void Use()
    {
        switch (type)
        {
            case ItemType.STONE:
                Debug.Log("I just used MANMA");
                break;
            case ItemType.FULL:
                Debug.Log("I just used H");
                break;
            case ItemType.RING:
                Debug.Log("RIng");
                break;
        }
    }
}
