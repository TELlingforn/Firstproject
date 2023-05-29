using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message //消息的属性
{
    //类型 UI
    public byte Type;
    //命令对应的值
    public int Command;
    //要传送的值
    public object Content;
    
    public Message(){}

    public Message(byte type, int command, object content)
    {
         Type=type;
         Command=command;
         Content=content;
    }

}

//消息类型
public class MessageType
{
    //类型
    public static byte Type_Audio = 1;
    public static byte Type_UI = 2;
    public static byte Type_Player = 3;
    //声音命令 命令参数
    public static int Audio_PlaySound = 100;
    public static int Audio_TopSound = 101;
    public static int Audio_PlayMusic = 102;
    
    public static int UI_Show = 200;
    public static int UI_AddScore = 201;
    public static int UI_ShowShop = 202;
}