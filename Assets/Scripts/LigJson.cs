using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  LitJson;

//json格式就是字典和数组嵌套
//json最终效果还是字典
public class Hero
{
    public string name;
    public int age;
}

public class Heros
{
    public Hero[] Heroes;
}
public class LigJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //func1();
        //fun2();
        fun3();
    }
    
    void func1()
    {
        //第一种方法
        Hero hero1 = new Hero();
        hero1.name = "中文";
        hero1.age = 12;
        Hero hero2 = new Hero();
        hero2.name = "掌握";
        hero2.age = 13;
        Heros heros = new Heros();
        heros.Heroes = new[] { hero1, hero2 };
        //TOjson就是变成json格式
        string jsonstr = JsonMapper.ToJson(heros);
        //中文会转为unicode编码
        Debug.Log(jsonstr);
        //解析
        Heros hs = JsonMapper.ToObject<Heros>(jsonstr);
        Debug.Log(hs.Heroes[0].name);
    }

    void fun2()
    {
        //JsonData代表了json中的各种类型
        JsonData js1 = new JsonData();
        js1.SetJsonType(JsonType.Object);//声明为一个字典
        js1["name"] = "我日";
        js1["age"] = 15;
        JsonData js2 = new JsonData();
        js1.SetJsonType(JsonType.Object);
        js2["name"] = "我擦";
        js2["age"] = 16549856416987;
        JsonData jss = new JsonData();
        jss.SetJsonType(JsonType.Array);
        jss.Add(js1);
        jss.Add(js2);
        //添加json最外层的消息
        JsonData Heros = new JsonData();
        Heros.SetJsonType(JsonType.Object);
        Heros["heros"] = jss;
        //Debug.Log(Heros.ToJson());
        //获取本地json
        /*
         * StreamReader streamReader = new StreamReader(Application.streamingAssetsPath + "/" + jsonName + ".json");
            string str = streamReader.ReadToEnd();
            JsonData m_jMoneyData = JsonMapper.ToObject(str);
            return m_jMoneyData;
         */
    }

    /*TODO:
     解析json 拿出json的数据
     */
    void fun3()
    {
        string jsonstr = "{'heros':[{'name':'我人','age':15},{'name':'我不是人','age':16}]}";
        //不用写<>了 jsonDate相当于var和auto
        JsonData herosJD = JsonMapper.ToObject(jsonstr);//解析拿到东西
        //拿到数组
        JsonData heros = herosJD["heros"];
        //如果是从json格式中解析出来的就要用tostring
        Debug.Log(heros[0]["name"].ToString());
        //第一层字典 第二层数组 第三层字典
        
    }
}
