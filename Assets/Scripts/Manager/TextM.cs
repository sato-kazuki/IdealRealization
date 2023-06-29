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
    BGMM bgmmanager;
    TextDisplayer displayer;

    private const string BGMPATH = "BGM_";
    private const string BIMGPATH = "BIMG_";
    private string txt =  "";

    private const string filepath = "Assets/TextData/NovelText.txt";

    // Start is called before the first frame update
    void Start()
    {
        _ = TextFileReader.LoadFile(filepath, UpdateTxt);
        imageManager = ImageM.GetInstance();
        bgmmanager = BGMM.GetInstance();
        displayer = this.GetComponent<TextDisplayer>();
    }

    public void UpdateTxt()
    {
        txt = TextFileReader.OutputText();

        if (txt != null)
        {
            txt = TextDistribution(txt);
            //テキスト更新処理
            displayer.TextUpdate(txt);
        }
        else
        {
            Debug.LogError("Failed to get text");
        }
    }

    /// <summary>
    /// [文字列]の形式でテキストが送られた場合、それを排した上で
    ///数字を各クラスのUpdate系メソッドに渡す
    /// </summary>
    /// <param name="txt">テキスト</param>
    /// <returns></returns>
    public string TextDistribution(string txt)
    {
        //背景画像変更処理
        string pattern = @"\[(.+?)\]";//[文字列]を取得して渡す

        MatchCollection matches = Regex.Matches(txt, pattern);
        if (matches.Count > 0)
        {
            foreach (Match result in matches)
            {
                string spword = result.Groups[1].Value;
                //spwordにPATHが含まれるかmatchで調べてSuccessなら各メソッドに投げる
                if (Regex.Match(spword, @BIMGPATH).Success)
                {
                    imageManager.UpdateImage(spword);
                }else if (Regex.Match(spword, @BGMPATH).Success)
                {
                    bgmmanager.MusicChange(spword);
                }
                txt = txt.Replace("[" + spword + "]", "");
            }
        }
        return txt;
    }
}

