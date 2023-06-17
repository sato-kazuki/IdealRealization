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

    // Update is called once per frame
    void Update()
    {
        
    }
// １．audioSorce.clip に AudioClipをセット
// ２．audioSorce.time に 再生時間(秒）をセット
// ３．audioSource.Play() で再生
    // audioSource.clip = audioClip;
	// audioSource.time = 5f;
	// audioSource.Play();
    //
}
