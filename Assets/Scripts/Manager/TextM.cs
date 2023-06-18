using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Experimental.RestService;
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
    TextDisplayer textDisplayer;

    const string filepath = "NovelText";

    // Start is called before the first frame update
    void Start()
    {
        TextFileReader.LoadFile(filepath);
        imageManager = ImageM.GetInstance();
        textDisplayer = TextDisplayer.GetInstance();
    }

    public void UpdateTxt()
    {
        string txt = TextFileReader.OutputText();
        //[����]�̌`���Ńe�L�X�g������ꂽ�ꍇ�A�����r�������
        //������ImageManager�N���X��UpdateImage()���\�b�h�ɓn��
        if (txt != null)
        {
            //�w�i�摜�ύX����
            string pattern = @"\[(\d+)\]";
            Match match = Regex.Match(txt, pattern);
            if (match.Success)
            {
                int number = int.Parse(match.Groups[1].Value);
                // ImageManager�N���X�̃��\�b�h�ɐ�����n��
                imageManager.UpdateImage(number);
                txt = txt.Replace("[" + number.ToString() + "]", "");
            }

            //�e�L�X�g�X�V����
            textDisplayer.TextDisplay(txt);
        }
        else
        {
            Debug.LogError("Failed to get text");
        }

    }

}
