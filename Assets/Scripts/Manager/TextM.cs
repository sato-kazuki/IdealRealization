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
            //�e�L�X�g�X�V����
            displayer.TextUpdate(txt);
        }
        else
        {
            Debug.LogError("Failed to get text");
        }
    }

    /// <summary>
    /// [������]�̌`���Ńe�L�X�g������ꂽ�ꍇ�A�����r�������
    ///�������e�N���X��Update�n���\�b�h�ɓn��
    /// </summary>
    /// <param name="txt">�e�L�X�g</param>
    /// <returns></returns>
    public string TextDistribution(string txt)
    {
        //�w�i�摜�ύX����
        string pattern = @"\[(.+?)\]";//[������]���擾���ēn��

        MatchCollection matches = Regex.Matches(txt, pattern);
        if (matches.Count > 0)
        {
            foreach (Match result in matches)
            {
                string spword = result.Groups[1].Value;
                //spword��PATH���܂܂�邩match�Œ��ׂ�Success�Ȃ�e���\�b�h�ɓ�����
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

