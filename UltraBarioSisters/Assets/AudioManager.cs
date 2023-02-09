using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    
    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        Play("MainTheme");
    }


    public void Play(string name){
        foreach(Sound s in sounds){
            if(s.Name == name){
                s.source.Play();
            }
        }
    }

    public void stopAll(){
        foreach(Sound s in sounds){
            s.source.Stop();
        }
    }

    public void ChangeVolume(string name, float volume){
        foreach(Sound s in sounds){
            if(s.Name == name){
                s.source.volume = volume;
            }
        }
    }

    public void Stop(string name){
        foreach(Sound s in sounds){
            if(s.Name == name){
                s.source.Stop();
            }
        }
    }
}

