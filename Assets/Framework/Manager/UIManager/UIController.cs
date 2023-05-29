using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MangerBase
{
    //这个脚本上挂在画板上的
    //自己的子控件
    public Dictionary<string, UIControl> UIControls = new Dictionary<string, UIControl>();
    // Start is called before the first frame update
    void Awake()
    {
        //把挂上这个脚本的画板注册到uimanger的字典中
        Managers.m_UI.UIControllers.Add(transform.name,this);
        //给自己的控件上添加uicontrol 方便自己管理
        foreach (Transform VARIABLE in transform)
        {
            if (VARIABLE.gameObject.GetComponent<UIControl>() == null)
            {
                VARIABLE.gameObject.AddComponent<UIControl>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override byte GetMessageType()
    {
        throw new System.NotImplementedException();
    }
}
