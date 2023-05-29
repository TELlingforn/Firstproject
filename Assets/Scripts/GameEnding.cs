using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine. SceneManagement;
using UnityEngine.UI;


public class GameEnding : MonoBehaviour
{
    //游戏胜利时，图片淡入淡出的时间
    public float fadeDuration = 1f;
    //游戏胜利时图片显示的时间
    public float displayDuration=1f;
    //游戏人物
    public GameObject Player;
    //游戏胜利时的画布背景
    public CanvasGroup ExitBackgroundImageCanvasGroup;
    public Image image;

    //游戏胜利时的bool值
    bool IsExit=false;
    //游戏失败时的bool值
    bool IsFail=false;
    //定义计时器，用于图片的渐变和完全显示
    private float timer=0f;
 
    //音频组件
    //public AudioSource winaudio;
    //public AudioSource failaudio;
 
    //bool值控制音效只播放一次
    bool IsPlay=false;

    private Sprite spriteCaught;

    private Sprite spriteWon;
    //碰撞发生
    private void Start()
    {
        spriteCaught = Resources.Load<Sprite>("Caught");
        spriteWon = Resources.Load<Sprite>("Won");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            //检测到玩家
            //游戏胜利
            IsExit = true;
        }
    }
    //游戏失败时的控制函数
    public void Caught()
    {
        IsFail = true;
    }
    // Update is called once per frame
    void Update()
    {
        //游戏胜利
        if (IsExit)
        {
            EndLevel(spriteWon, false);//winaudio
        }
        //游戏失败
        else if (IsFail)
        {
            EndLevel(spriteCaught, true);//failaudio
        }
    }
 
    //游戏胜利或失败时的方法
    void EndLevel(Sprite sprite,bool doRestart)//AudioSource playaudio
    {
        /*//游戏胜利或失败的音效播放
        if (!IsPlay)
        {
            playaudio.Play();
            IsPlay=true;
        }*/
        //玩家碰到触发器时，计时器开始计时
        timer+=Time.deltaTime;
        //指定结束UI图片中的图片
        image.sprite = sprite;
        //控制CanvasGroup的不透明度
        ExitBackgroundImageCanvasGroup.alpha = timer/fadeDuration;
 
        //游戏胜利/失败图片渐变了1秒，显示了1秒，游戏结束
        if(timer>fadeDuration+displayDuration) 
        {
            //游戏失败，重启游戏
            if (doRestart)
            {
                //重启场景
                SceneManager.LoadScene(0);
            }
            //游戏胜利，退出游戏
            else if (!doRestart) 
            { 
                //打包之后才能用的
                //Application.Quit(); 

                UnityEditor.EditorApplication.isPlaying = false;
            }
            
        }
    }
}