using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBase
{
    public TMP_Text Text;
    // Start is called before the first frame update
    void Start()
    {
        UIManger.Instance.Register(this);
    }

    // Update is called once per frame

    public override void ReceiveMessage(Message message)
    {
        base.ReceiveMessage(message);
        //判断消息
        if (message.Command == MessageType.UI_AddScore)
        {
            int score = (int)message.Content;//拆箱

            Text.text = "分数:" + score;
        }
    }
}
