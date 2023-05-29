using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LitJson;
//装备管理器
public class Item
{
    public int id;
    public string name;
    public string des;
    public float price;
    public string icon;
    public float attack;
    public float hp;

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is Item otherItem)
        {
            return id == otherItem.id;
        }
        return false;
    }
}
public class ItemManager:MangerBase
{
    //=>是C#的lambda表达式
    /*
     (x, y) =>
    {
        int sum = x + y;
        return sum;
    }
    x => x * x简单的直接返回
    */
    private HashSet<Item> items;
    public ItemManager()
    {
        //拿到json
        TextAsset json = Resources.Load<TextAsset>("Item");
        //解析json,转换为ITem数组类型
        if (!string.IsNullOrEmpty(json.text))
        {
            items = LitJson.JsonMapper.ToObject<HashSet<Item>>(json.text);
        }
    }

    public Item GetItem(int id)
    {
        Item item = items.FirstOrDefault(i => i.id == id);
        /*
         * 在这个表达式中，i 是一个参数，表示集合中的每个元素。
         * i.id 是对元素的 id 属性的访问，用于与给定的 id 进行比较。
         == 是相等运算符，用于检查左侧操作数和右侧操作数是否相等。
         */
        return item;
    }

    public override byte GetMessageType()
    {
        throw new System.NotImplementedException();
    }
}
