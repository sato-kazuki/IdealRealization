using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
    }
}
