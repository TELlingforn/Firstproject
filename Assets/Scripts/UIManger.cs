using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MangerBase
{
    // Start is called before the first frame update
    void Start()
    {
        //注册到消息中心
        MessageCenter.Instance.Register(this);//单例模式的调用
    }

    public override byte GetMessageType()
    {
        return MessageType.Type_UI;//要调用UI
    }
}
