using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadAR : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void Back()
    {
        SceneManager.LoadScene("menu");
    }

    public void load_02()
    {
        SceneManager.LoadScene("椎骨");
    }

    public void load_03()
    {
        SceneManager.LoadScene("胸廓");
    }

    public void load_04()
    {
        SceneManager.LoadScene("颅骨");
    }

    public void load_07()
    {
        SceneManager.LoadScene("锁骨");
    }

    public void load_08()
    {
        SceneManager.LoadScene("肩胛骨");
    }

    public void load_10()
    {
        SceneManager.LoadScene("尺骨和桡骨");
    }

    public void load_11()
    {
        SceneManager.LoadScene("肱骨");
    }

    public void load_12()
    {
        SceneManager.LoadScene("掌骨");
    }

    public void load_14()
    {
        SceneManager.LoadScene("髋骨");
    }

    public void load_16()
    {
        SceneManager.LoadScene("股骨");
    }

    public void load_17()
    {
        SceneManager.LoadScene("腓骨和胫骨");
    }

    public void load_18()
    {
        SceneManager.LoadScene("脚掌骨");
    }

    public void load_19()
    {
        SceneManager.LoadScene("髌骨");
    }
}