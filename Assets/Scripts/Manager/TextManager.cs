using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TextManager : MonoBehaviour
{

    private static TextManager instance;

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
    public static TextManager GetInstance()
    {
        return instance;
    }

    [SerializeField]
    ImageManager imageManager;
    TextFileReader textFileReader;
    TextDisplayer textDisplayer;

    // Start is called before the first frame update
    void Start()
    {
        imageManager = ImageManager.GetInstance();
    }

    public void UpdateTxt()
    {
        string txt = textFileReader.OutputText();
        //[数字]の形式でテキストが送られた場合、それを排した上で
        //数字をImageManagerクラスのUpdateImage()メソッドに渡す
        if (txt != null)
        {
            //背景画像変更処理
            string pattern = @"\[(\d+)\]";
            Match match = Regex.Match(txt, pattern);
            if (match.Success)
            {
                int number = int.Parse(match.Groups[1].Value);
                // ImageManagerクラスのメソッドに数字を渡す
                imageManager.UpdateImage(number);
                txt = txt.Replace("[" + number.ToString() + "]", "");
            }

            //テキスト更新処理
            textDisplayer.TextDisplay(txt);
        }
        else
        {
            Debug.LogError("Failed to get text");
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
