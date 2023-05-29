using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
public class XmlTest : MonoBehaviour
{
    /*TODO:
     节点:<name>value</name>
     属性:<name id="1">value</name>
     */
    // Start is called before the first frame update
    void Start()
    {
        //ParseXML();
        //ParseXML2();
        creatxml();
    }

    void ParseXML()
    {
        //通过节点的顺序查找
        XmlDocument doc = new XmlDocument();
        doc.Load(Application.dataPath+"/XML/text.xml");
        XmlElement rootEle=doc.LastChild as XmlElement;
        //heros节点
        XmlElement herosEle = rootEle.FirstChild as XmlElement;//child是子节点
        foreach (XmlElement VARIABLE in herosEle.ChildNodes)
        {
            string id = VARIABLE.GetAttribute("id");
            string name = VARIABLE.ChildNodes[0].InnerText;
            string age = VARIABLE.ChildNodes[1].InnerText;
        }
    }

    void ParseXML2()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Application.dataPath+"/XML/text.xml");
        //XPath
        //"/root/heros/hero"是获取到了所有的值()name和age
        //"/root/heros/hero/name"是拿到name
        //位置从1开始
        //XmlNodeList list = doc.SelectNodes("/root/heros/hero[2]");//拿到第二个
        //XmlNodeList list = doc.SelectNodes("/root/heros/hero[last()-1]");//获取倒数第二个
        //XmlNodeList list = doc.SelectNodes("/root/heros/hero[@id]");//拿到有id的
        XmlNodeList list = doc.SelectNodes("/root/heros/hero[@id=2]");
        foreach (XmlElement ele in list) 
        {
            Debug.Log(ele.InnerText);
        }
    }

    void creatxml()
    {
        //按顺序创建
        XmlDocument doc = new XmlDocument();
        //声明
        XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", "");
        doc.AppendChild(dec);
        XmlElement rootele = doc.CreateElement("root");
        doc.AppendChild(rootele);
        XmlElement herosEle = doc.CreateElement("heros");
        rootele.AppendChild(herosEle);
        string[] names = new string[] { "错误的", "Awda", "啊我的娃" };
        string[] ages = new string[] { "321", "135", "54" };
        //循环创建hero节点
        for (int i = 0; i < 3; i++)
        {
            XmlElement heroele = doc.CreateElement("hero");
            herosEle.AppendChild(heroele);
            XmlElement nameele = doc.CreateElement("name");
            nameele.InnerText = names[i];
            heroele.AppendChild(nameele);
            XmlElement ageele = doc.CreateElement("age");
            ageele.InnerText = ages[i];
            heroele.AppendChild(ageele);
            //添加属性
            XmlAttribute att = doc.CreateAttribute("id");
            att.Value = i + " ";
            heroele.Attributes.Append(att);
        }
        //保存
        doc.Save(Application.dataPath+"/XML/text2.xml");
    }
}
