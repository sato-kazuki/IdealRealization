using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;

public static class TextFileReader
{

    private static string[] lines;
    private static int lastLineIndex = -1;


    /// <summary>
    /// テキストファイル初期読み込み
    /// </summary>
    /// <param name="filePath">読み込みテキストファイル名</param>
    public static /*async*/ void LoadFile(string filePath)
    {
        //TextAsset textAsset = Resources.Load<TextAsset>(filePath);
        TextAsset textAsset =Addressables.LoadAssetAsync<TextAsset>(filePath).Result;
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
    public static string OutputText()
    {
        lastLineIndex = Mathf.Min(lastLineIndex + 1, lines.Length - 1);
        string line = lines[lastLineIndex].TrimStart('\r', '\n', ' ').TrimEnd('\r', '\n', ' ');
        Debug.Log(line);
        return line;
    }
}