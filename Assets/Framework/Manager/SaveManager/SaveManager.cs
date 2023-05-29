using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MySingletonBase<SaveManager>
{
    //加密
    private ES3Settings Settings = new ES3Settings(ES3.EncryptionType.AES, "test");
    //保存和加密都有settings
    //保存 可以保存Transform 所有的保存
    public void Save<T>(string key, T value)
    {
        ES3.Save<T>(key,value,Settings);
    }

    public T Load<T>(string key)
    {
        return ES3.Load<T>(key, Settings);
    }
    
    //读取到某个游戏物体上 组件读取
    public void LoadInto<T>(string key, T t) where T: UnityEngine.Object
    {
        ES3.LoadInto<T>(key,t,Settings);
    }
    public void SaveImage(Texture2D texture, string imageName)
    {
        ES3.SaveImage(texture,imageName);
    }

    public Texture2D LoadImage(Texture2D texture, string imageName)
    {
        return ES3.LoadImage(imageName);
    }

    public void Clear()
    {
        ES3.DeleteDirectory(Settings);
    }
}
