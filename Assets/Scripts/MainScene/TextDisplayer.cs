using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class TextDisplayer : MonoBehaviour
{
    [SerializeField]
    private Text chattext;

    public void TextUpdate(string txt)
    {
        chattext.text = txt;
    }
}
