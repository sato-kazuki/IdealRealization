using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextFileReader : MonoBehaviour
{

    private string[] lines;
    private int lastLineIndex = -1;

    [SerializeField]
    TextManager textManager;


    public void Start(){
        textManager = TextManager.GetInstance();
        LoadFile("NovelText");
    }


    /// <summary>
    /// テキストファイル初期読み込み
    /// </summary>
    /// <param name="filePath">読み込みテキストファイル名</param>
    public void LoadFile(string filePath)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(filePath);
        if (textAsset != null)
        {
            lines = textAsset.text.Split('*');
        }
        else
        {
            // Resourcesフォルダ内にファイルが存在しない場合は、StreamReaderで読み込む
            StreamReader reader = new StreamReader(filePath);
            string fileContent = reader.ReadToEnd();
            reader.Close();
            lines = fileContent.Split('*');
        }
    }

    /// <summary>
    /// 次のテキストを渡す
    /// </summary>
    public string OutputText()
    {
        lastLineIndex = Mathf.Min(lastLineIndex + 1, lines.Length - 1);
        string line = lines[lastLineIndex].TrimEnd('\r', '\n', ' ');
        Debug.Log(line);
        return line;
    }
}