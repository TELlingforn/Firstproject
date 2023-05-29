using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCenter : MySingletonBase<MessageCenter>
{
    public  List<MangerBase> Mangers = new List<MangerBase>();

    public void Register(MangerBase manger)
    {
        if (!Mangers.Contains(manger))
        {
            Mangers.Add(manger);
        }
    }

    //让每一个管理器都接收消息
    public void SendCustomMessage(Message message)
    {
        foreach (var VARIABLE in Mangers)
        {
            VARIABLE.ReceiveMessage(message);
        }
    }
}
