using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class introduce_content : MonoBehaviour {
    public Image image;
    public Sprite []sprite = new Sprite[20];
    public Text name;
    public Text content;
    public TextAsset[] texts = new TextAsset[20];
    public Image AR;

    private int number;
    private string[] names = { "中轴骨骼", "躯干骨骼", "椎骨", "胸廓", "颅骨", "四肢骨骼", "上肢骨骼", "锁骨", "肩胛骨", "上肢自由骨", "尺骨和桡骨", "肱骨", "手掌骨",
                                "下肢骨骼", "下肢带骨", "下肢自由骨", "股骨", "胫骨和腓骨", "脚掌骨", "髌骨"};

    // Use this for initialization
    void Start () {
        number = PlayerPrefs.GetInt("number");
        image.sprite = sprite[number];
        name.text = names[number];
        content.text = texts[number].text;

        if (number == 0 || number == 1 || number == 5 || number == 13 || number == 9 || number == 15)
        {
            AR.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
	}

    public void back()
    {
        SceneManager.LoadScene("menu");
    }

    public void load_ARCamere()
    {
        string index = string.Format("{0:00}", number);
        SceneManager.LoadScene(index);
    }
}
