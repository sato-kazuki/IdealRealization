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

    private const string BGMPATH = "BGM_";
    private const string BIMGPATH = "BIMG_";


    private const string filepath = "Assets/TextData/NovelText.txt";

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
            string pattern = @"\[(.+)\]";//[������]���擾���ēn��
            Match match = Regex.Match(txt, pattern);

            //MatchCollection matches = Regex.Matches(txt, pattern);
            //if(matches.Count > 0)
            //{
            //foreach(Match result in match) {
            //  string spword = result.Value;
            //}
            //if BGM_.+ updatemusic()
            //if bimg_.+ updateimage()
            //}


            if (match.Success)
            {

                string spword = match.Groups[1].Value;


                //string testword = match.Groups[1].Value;
                //Debug.Log(testword);
                
                
                txt = txt.Replace("[" + spword + "]", "");
                imageManager.UpdateImage(spword); // ImageManager�N���X�̃��\�b�h�ɕ������n��

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
