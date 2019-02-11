using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class find : MonoBehaviour {
    public InputField ipf_content;
    public Text msg;

    private string content;
    private string []name = { "中轴骨骼", "躯干骨骼", "椎骨", "胸廓", "颅骨", "四肢骨骼", "上肢骨骼", "锁骨", "肩胛骨", "上肢自由骨", "尺骨和桡骨", "肱骨", "手掌骨",
                                "下肢骨骼", "下肢带骨", "下肢自由骨", "股骨", "胫骨和腓骨", "脚掌骨"};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void self_enter()
    {
        content = ipf_content.text;
        for (int i = 0; i<name.Length; i++)
        {
            if (content.Equals(name[i]))
            {
                PlayerPrefs.SetInt("number", i);
                SceneManager.LoadScene("introduce");
                return;
            }
        }
        msg.text = "没有此骨骼";
        StartCoroutine(fade());
    }

    public void click_0()
    {
        PlayerPrefs.SetInt("number", 0);
        SceneManager.LoadScene("introduce");
    }

    public void click_1()
    {
        PlayerPrefs.SetInt("number", 1);
        SceneManager.LoadScene("introduce");
    }

    public void click_2()
    {
        PlayerPrefs.SetInt("number", 2);
        SceneManager.LoadScene("introduce");
    }

    public void click_3()
    {
        PlayerPrefs.SetInt("number", 3);
        SceneManager.LoadScene("introduce");
    }

    public void click_4()
    {
        PlayerPrefs.SetInt("number", 4);
        SceneManager.LoadScene("introduce");
    }

    public void click_5()
    {
        PlayerPrefs.SetInt("number", 5);
        SceneManager.LoadScene("introduce");
    }

    public void click_6()
    {
        PlayerPrefs.SetInt("number", 6);
        SceneManager.LoadScene("introduce");
    }

    public void click_7()
    {
        PlayerPrefs.SetInt("number", 7);
        SceneManager.LoadScene("introduce");
    }

    public void click_8()
    {
        PlayerPrefs.SetInt("number", 8);
        SceneManager.LoadScene("introduce");
    }

    public void click_9()
    {
        PlayerPrefs.SetInt("number", 9);
        SceneManager.LoadScene("introduce");
    }

    public void click_10()
    {
        PlayerPrefs.SetInt("number", 10);
        SceneManager.LoadScene("introduce");
    }

    public void click_11()
    {
        PlayerPrefs.SetInt("number", 11);
        SceneManager.LoadScene("introduce");
    }

    public void click_12()
    {
        PlayerPrefs.SetInt("number", 12);
        SceneManager.LoadScene("introduce");
    }

    public void click_13()
    {
        PlayerPrefs.SetInt("number", 13);
        SceneManager.LoadScene("introduce");
    }

    public void click_14()
    {
        PlayerPrefs.SetInt("number", 14);
        SceneManager.LoadScene("introduce");
    }

    public void click_15()
    {
        PlayerPrefs.SetInt("number", 15);
        SceneManager.LoadScene("introduce");
    }

    public void click_16()
    {
        PlayerPrefs.SetInt("number", 16);
        SceneManager.LoadScene("introduce");
    }

    public void click_17()
    {
        PlayerPrefs.SetInt("number", 17);
        SceneManager.LoadScene("introduce");
    }

    public void click_18()
    {
        PlayerPrefs.SetInt("number", 18);
        SceneManager.LoadScene("introduce");
    }

    public void click_19()
    {
        PlayerPrefs.SetInt("number", 19);
        SceneManager.LoadScene("introduce");
    }

    IEnumerator fade()
    {
        yield return new WaitForSeconds(1f);
        msg.text = "";
    }
}
