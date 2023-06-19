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

    private const string filepath = "NovelText";

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
        //[����]�̌`���Ńe�L�X�g������ꂽ�ꍇ�A�����r�������
        //������ImageManager�N���X��UpdateImage()���\�b�h�ɓn��
        if (txt != null)
        {
            //�w�i�摜�ύX����
            string pattern = @"\[(.+)\]";//[BG+����]���擾���ā@����������n�������@�v����
            Match match = Regex.Match(txt, pattern);
            if (match.Success)
            {
                string imagename = match.Groups[1].Value;
                // ImageManager�N���X�̃��\�b�h�ɕ������n��
                imageManager.UpdateImage(imagename);
                txt = txt.Replace("[" + imagename + "]", "");
            }

            //�e�L�X�g�X�V����
            displayer.TextUpdate(txt);

        }
        else
        {
            Debug.LogError("Failed to get text");
        }

    }

}
