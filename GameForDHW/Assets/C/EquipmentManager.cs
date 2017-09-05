using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {
    #region Sigleton

    public static EquipmentManager instance;

    public void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEuipmentChanged;

    Inventory inventory;
    public void Start()
    {
        inventory = Inventory.instance;

       int numSlots= System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }
    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }
        if (onEuipmentChanged != null)
        {
            onEuipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }
    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEuipmentChanged != null)
            {
                onEuipmentChanged.Invoke(null, oldItem);
            }
        }

    }
    public void UnequipAll()
    {
        for(int i = 0; i<currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }
}
