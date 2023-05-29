using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MangerBase
{
    //环境
    private AudioSource envPlayer;

    //音效
    private AudioSource sePlayer;

    //音乐
    private AudioSource Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.AddComponent<AudioSource>();
        Player.loop=true;
        sePlayer = gameObject.AddComponent<AudioSource>();
        envPlayer = gameObject.AddComponent<AudioSource>();
        //切换场景禁止销毁
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public void playmusic(string name, float volume = 1)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        
        playmusic(clip,volume);
    }
    public void playmusic(AudioClip clip, float volume = 1)
    {
        Player.volume = volume;
        if (Player.isPlaying)
        {
            Player.Stop();
        }
        Player.clip = clip;
        Player.Play();

    }

    public void stopmusic()
    {
        Player.Stop();
    }

    public void ChangeMusicVolume(float volume)
    {
        Player.volume = volume;
    }

    public void PlayEnvMusic(string name, float volume = 1)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        PlayEnvMusic(clip,volume);
        
    }

    public void PlayEnvMusic(AudioClip clip, float volume = 1)
    {
        if (envPlayer.isPlaying)
        {
            envPlayer.Stop();
        }
        envPlayer.clip = clip;
        envPlayer.volume = volume;
        envPlayer.Play();
    }
    
    public void stopenvmusic()
    {
        Player.Stop();
    }

    public void playseSound(string name, float volume = 1)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        playseSound(clip,volume);
    }

    public void playseSound(AudioClip clip, float volume = 1)
    {
        sePlayer.PlayOneShot(clip,volume);
    }
    
    //在某个物体上播放
    public void playseSoundOnObject(string name, GameObject go, float volume = 1)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        playseSoundOnObject(clip,go,volume);
        
    }

    public void playseSoundOnObject(AudioClip clip, GameObject go, float volume = 1)
    {
        AudioSource Player = go.GetComponent<AudioSource>();
        if (Player == null)
        {
            Player = go.AddComponent<AudioSource>();
        }

        Player.volume = volume;
        Player.PlayOneShot(clip);
    }

    public override byte GetMessageType()
    {
        throw new System.NotImplementedException();
    }
}
