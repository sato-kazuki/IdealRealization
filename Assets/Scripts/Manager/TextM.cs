using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class TextM : MonoBehaviour
{

    private static TextM instance;

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
    public static TextM GetInstance()
    {
        return instance;
    }

    [SerializeField]
    ImageM imageManager;
    TextDisplayer displayer;

    const string filepath = "NovelText";

    // Start is called before the first frame update
    void Start()
    {
        TextFileReader.LoadFile(filepath);
        imageManager = ImageM.GetInstance();
        displayer = this.GetComponent<TextDisplayer>();
        UpdateTxt();
    }

    public void UpdateTxt()
    {
        string txt = TextFileReader.OutputText();
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
            displayer.TextUpdate(txt);

        }
        else
        {
            Debug.LogError("Failed to get text");
        }

    }

}
