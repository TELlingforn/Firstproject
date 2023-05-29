using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //单例模式
    private static Test instance;

    public static Test Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        instance = this;//给对象初始化
    }


    void Update()
    {
        
    }
}
