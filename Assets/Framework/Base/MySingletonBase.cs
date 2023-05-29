using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//泛型单例基类
public class MySingletonBase<T> : MonoBehaviour where T:MonoBehaviour
{

    //unity自动创造对象
    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }
    protected virtual void Awake()//子类重写
    {
        instance = this as T;
    }

    
    protected virtual void OnDestroy()
    {
        instance = null;
    }
}
