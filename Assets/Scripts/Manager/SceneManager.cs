using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
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
    public static SceneManager GetInstance()
    {
        return instance;
    }
    private static SceneManager instance;

    public void NewGame()
    {
        Debug.Log("NewGame");
    }
    public void LoadGame()
    {
        Debug.Log("LoadGame");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
