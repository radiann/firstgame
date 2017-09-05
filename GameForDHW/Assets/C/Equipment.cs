using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment",menuName ="Inventory/Equipment")]
public class Equipment : ItemC {
    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        // Equip the Item 
    }
}
public enum EquipmentSlot {left,Right,Monster}
