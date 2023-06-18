using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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



    [SerializeField]
    Image background;


    private const string FILE_PREFIX = "background_";


    /// <summary>
    /// 受け取った数値をもとにbackground_[数字].pngファイルをTextures/フォルダから取得、imageを差し替え
    /// </summary>
    /// <param name="number">ファイル名の数値</param>
    public void UpdateImage(int number)
    {
        string fileName = "Textures/" + FILE_PREFIX + number.ToString();
        Debug.Log(fileName);
        
        Texture2D texture = Resources.Load<Texture2D>(fileName); 
        Debug.Log(texture); //null
        if (texture != null)
        {
            
            background.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                //await Addressables.LoadAssetAsync<Sprite>(fileName).Task;
        }
        else
        {
            Debug.LogError("Failed to load texture: " + fileName);
        }
    }
    
}
