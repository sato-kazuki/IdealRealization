using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Newgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    public void OnButtonClick()
    {
        Debug.Log("NewgameClick");
        //audio�e�X�g�p
        BGMM bgmManager = BGMM.GetInstance();
        bgmManager.MusicChange("2");

        SceneManager.LoadScene("MainScene");
    }
}
