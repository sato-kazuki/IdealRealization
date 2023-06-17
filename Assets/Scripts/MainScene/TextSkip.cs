using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSkip : MonoBehaviour
{
    [SerializeField]
    Button skipbutton;
    ButtonManager buttonManager;
    // Start is called before the first frame update
    void Start()
    {
        buttonManager = ButtonManager.GetInstance();
        //画面クリック判定ボタンの取得
        skipbutton.onClick.AddListener(clickCheck);
    }

    void clickCheck()
    {
        
        buttonManager.SkipClick();
    }
}
