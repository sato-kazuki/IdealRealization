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
        SceneManager.LoadScene("MainScene");
    }
}
