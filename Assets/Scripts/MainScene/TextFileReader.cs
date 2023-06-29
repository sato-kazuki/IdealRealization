using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;
using Unity.VisualScripting.FullSerializer;
using System;
using System.Threading.Tasks;

public static class TextFileReader
{

    private static string[] lines;
    private static int lastLineIndex = -1;


    /// <summary>
    /// テキストファイル初期読み込み
    /// </summary>
    /// <param name="filePath">読み込みテキストファイル名</param>
    public static async Task LoadFile(string filePath,Action action)
    {
        TextAsset textAsset = await Addressables.LoadAssetAsync<TextAsset>(filePath).Task;

        if (textAsset != null)
        {
            lines = textAsset.text.Split("[次ページ]");
        }
        else
        {
            // Resourcesフォルダ内にファイルが存在しない場合は、StreamReaderで読み込む
            StreamReader reader = await Addressables.LoadAssetAsync<StreamReader>(filePath).Task;
            string fileContent = reader.ReadToEnd();
            reader.Close();
            lines = fileContent.Split("[次ページ]");
            Debug.Log(lines);
        }
        action();
    }

    /// <summary>
    /// 次のテキストを渡す
    /// </summary>
    public static string OutputText()
    {
        lastLineIndex = Mathf.Min(lastLineIndex + 1, lines.Length - 1);
        string line = lines[lastLineIndex].TrimStart('\r', '\n', ' ').TrimEnd('\r', '\n', ' ');
        //Debug.Log(line);
        return line;
    }
}