using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    private const string FILE_PATH = "./Audios/BGM_";
    AudioSource audiosource;

    //path‚ÌŽæ‚è•û’²‚×’†‚È‚Ì‚ÅŽb’è
    [SerializeField]
    AudioClip bgm1;
    [SerializeField]
    AudioClip bgm2;

    void Start()
    {
        audiosource = this.gameObject.GetComponent<AudioSource>();
    }

    public void MusicChange(string musicname)
    {
        string filename = FILE_PATH + musicname;
        audiosource.clip = bgm2;
        audiosource.Play();
    }
}
