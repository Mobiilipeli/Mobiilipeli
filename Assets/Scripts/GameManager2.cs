using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    private static GameManager2 instance;

    public static GameManager2 MyInstance
    {
        get
        {
            if (instance == null)
                instance = new GameManager2();

            return instance;
        }
    }

    public void Finish()
    {
        SceneManager.LoadScene("TilemapTestScene");
        
    }
}
