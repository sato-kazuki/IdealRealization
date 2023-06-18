using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    
    private static BGMManager instance;

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
    public static BGMManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
    }
}
