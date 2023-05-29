using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class MangerBase : MySingletonBase<MangerBase>
{
    public List<MonoBase> Monos = new List<MonoBase>();//脚本基类
    //给功能模块一个注册方法
    public void Register(MonoBase mono)
    {
        if (!Monos.Contains(mono))
        {
            Monos.Add(mono);
        }
    }
    
    //接收消息
    public virtual void ReceiveMessage(Message message)
    {
        if (message.Type != GetMessageType())
        {
            return;
        }

        //向管理的脚本传递消息
        foreach (var VARIABLE in Monos)
        {
            VARIABLE.ReceiveMessage(message);
        }
    }
    //抽象方法表示子类一定要实现的功能 一定要拿到消息的类型
    //设置接受的消息类型
    public abstract byte GetMessageType();
}
