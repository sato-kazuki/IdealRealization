using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSkip : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    TextM textManager;
    public void OnButtonClick()
    {
        textManager.UpdateTxt();
    }
}
