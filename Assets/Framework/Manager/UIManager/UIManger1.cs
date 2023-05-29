using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger1 : MangerBase
{
    public Dictionary<string, UIController> UIControllers = new Dictionary<string, UIController>();

    //让指定的controller不活动
    public void SetActive(string controllerName, bool active)//
    {
        transform.Find(controllerName).gameObject.SetActive(active);
    }
    
    //获取其controller中的子控件,类型是uicontroll
    public UIControl GetUIControl(string controllerName, string controlName)
    {
        UIController controller;
        UIControl control;
        if (UIControllers.TryGetValue(controllerName,out controller))
        {
            
            if (controller.UIControls.TryGetValue(controlName,out control))
            {
                return control;
            }
        }

        return null;
    }

    private void Start()
    {
        MessageCenter.Instance.Register(this);
    }

    public override byte GetMessageType()
    {
        return MessageType.Type_UI;
    }
}
