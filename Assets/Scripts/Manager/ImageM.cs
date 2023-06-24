using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
//using UnityEngine.AddressableAssets;

public class ImageM : MonoBehaviour
{

    private static ImageM instance;

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
    public static ImageM GetInstance()
    {
        return instance;
    }

    private const string FILE_PATH = "Assets/Textures/";
    private const string EXTENSION = ".png";

    [SerializeField]
    Image background;



    /// <summary>
    /// 受け取ったファイル名をもとにbackground_[文字列].pngファイルをTextures/フォルダから取得、imageを差し替え
    /// </summary>
    /// <param name="number">ファイル名の数値</param>
    public async void UpdateImage(string imagename)
    {
        string fileName = FILE_PATH + imagename + EXTENSION;
        Debug.Log(fileName);
        
        Texture2D texture = await Addressables.LoadAssetAsync<Texture2D>(fileName).Task;
        if (texture != null)
        {
            background.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else
        {
            Debug.LogError("Failed to load texture: " + fileName);
        }
    }
    
}
