using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextDisplayer : MonoBehaviour
{
    private static TextDisplayer instance;

    private void Awake()
    {
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
    public static TextDisplayer GetInstance()
    {
        return instance;
    }

    [SerializeField]
    private Text chattext;

    public void TextDisplay(string txt)
    {
        chattext.text = txt;
    }
}