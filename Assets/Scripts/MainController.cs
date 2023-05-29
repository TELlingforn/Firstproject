using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : UIController
{
    // Start is called before the first frame update
    void Start()
    {
        Managers.m_UI.GetUIControl(transform.name,"menuButton").AddButtonClickEvent(ShowMenue);
    }

    public void ShowMenue()
    {
        Managers.m_UI.SetActive("MenuController",true);//
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
