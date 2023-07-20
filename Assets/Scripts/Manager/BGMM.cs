using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;
using static Unity.Burst.Intrinsics.X86;

public class BGMM : MonoBehaviour
{
    
    private static BGMM instance;

    private void Awake(){
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static BGMM GetInstance()
    {
        return instance;
    }

    private const string FILE_PATH = "Assets/Audios/";
    private const string EXTENSION = ".mp3";

    AudioSource audiosource;


    void Start()
    {
        audiosource = this.gameObject.GetComponent<AudioSource>();
        //Audioclip�̕ύX�e�X�g
        //��start�ł�async�͓������Ȃ��H
    }


    public async void MusicChange(string musicname)
    {
        string filename = FILE_PATH + musicname + EXTENSION;
        AudioClip afterMusic = await Addressables.LoadAssetAsync<AudioClip>(filename).Task;
        Debug.Log(filename);
        if (afterMusic == default)
        {
            // default�ł���΁A���[�h�Ɏ��s���Ă���
            Debug.LogError("���[�h�Ɏ��s���܂���");
        }
        audiosource.clip = afterMusic;
        audiosource.Play();
        Addressables.Release(afterMusic);
    }
}
