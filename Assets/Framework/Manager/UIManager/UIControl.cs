using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    //为组件添加一个统一的管理
    //把组件全部封进UIControl上,直接调UIControl
    public UIController Controller;
    void Awake()
    {
        //向上检查
        if (transform.parent != null)
        {
            Controller = transform.GetComponentInParent<UIController>();
            if (Controller != null)
            {
                Controller.UIControls.Add(transform.name,this);
            }
        }
    }
    
    //更改文本
    public void ChangeText(string text)
    {
        if (GetComponent<TMP_Text>() != null)
        {
            GetComponent<TMP_Text>().text = text;
        }
    }

    public void ChangeImage(Sprite sprite)
    {
        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().sprite = sprite;
        }
    }

    //这是添加按键响应
    public void AddButtonClickEvent(UnityAction action)
    {
        Button control = GetComponent<Button>();
        if (control != null)
        {
            control.onClick.AddListener(action);
        }
    }

    public void AddSliderEvent(UnityAction<float> action)
    {
        Slider control = GetComponent<Slider>();
        if (control != null)
        {
            control.onValueChanged.AddListener(action);
        }
    }
    
    public void AddInputFieldEvent(UnityAction<string> action)
    {
        InputField control = GetComponent<InputField>();
        if (control != null)
        {
            control.onValueChanged.AddListener(action);
        }
    }
}
