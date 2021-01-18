using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public void LoadScene(string _name)
    {
        //try
        //{
            SceneManager.LoadScene(_name);
        //} catch()
        //{

        //}
    }

    public void LoadScene(int _index)
    {
        //try
        //{
        SceneManager.LoadScene(_index);
        //} catch()
        //{

        //}
    }
}
