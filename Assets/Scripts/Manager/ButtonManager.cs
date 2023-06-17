using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ButtonManager : MonoBehaviour
{



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
    public static ButtonManager GetInstance()
    {
        return instance;
    }


    private static ButtonManager instance;
    

    [SerializeField]
    ImageManager imageManager;
    TextManager textManager;




    // Start is called before the first frame update
    void Start()
    {
        textManager = TextManager.GetInstance();
        imageManager = ImageManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SkipClick(){
        textManager.UpdateTxt();
    }
}
