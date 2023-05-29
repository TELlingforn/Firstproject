using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//背包管理器
public class InventoryItem
{
    public int Itemid;
    public int count = 1;
}

public class InventoryManager : MangerBase
{
    public List<InventoryItem> Inventory = new List<InventoryItem>();

    public void Additem(int Itemid, int count = 1)
    {
        //存在在数量
        foreach (InventoryItem VARIABLE in Inventory)
        {
            if (VARIABLE.Itemid == Itemid)
            {
                VARIABLE.count += count;
                return;
            }
        }

        //不存在创建一个
        InventoryItem item = new InventoryItem() { Itemid = Itemid, count = count };
        Inventory.Add(item);
    }

    public InventoryItem GetItem(int ItemID)
    {
        foreach (InventoryItem VARIABLE in Inventory)
        {
            if (VARIABLE.Itemid == ItemID)
            {
                return VARIABLE;
            }
        }

        return null;
    }

    public void RemoveItem(int ItemID, int count = 1)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            InventoryItem item = Inventory[i];
            if (item.Itemid == ItemID && item.count > 0)
            {
                item.count -= count;
                if (item.count <= 0)
                {
                    Inventory.Remove(item);
                }
            }
        }
    }

    public void RemoveAllItem()
    {
        Inventory.Clear();
    }

    public override byte GetMessageType()
    {
        throw new System.NotImplementedException();
    }
}
