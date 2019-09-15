using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Init : MonoBehaviour
{
    public Text englishText;
    public Text chineseText;
    public Text contextText;
    public Image back;
    public Image AR;
    public TextAsset[] texts = new TextAsset[20];


    private string englishName;

    private string chineseName;

    private string[] names =
    {
        "中轴骨骼", "躯干骨骼", "椎骨", "胸廓", "颅骨", "四肢骨骼", "上肢骨骼", "锁骨", "肩胛骨", "上肢自由骨", "尺骨和桡骨", "肱骨", "手掌骨",
        "下肢骨骼", "髋骨", "下肢自由骨", "股骨", "胫骨和腓骨", "脚掌骨", "髌骨"
    };

    public void ARClick()
    {
        SceneManager.LoadScene(chineseName);
    }

    public void BackClick()
    {
        SceneManager.LoadScene("menu");
    }

    // Start is called before the first frame update
    void Start()
    {
        chineseName = PlayerPrefs.GetString("name");
        englishName = PlayerPrefs.GetString("english");
        chineseText.text = chineseName;
        englishText.text = englishName;

        int i = 0;
        for (i = 0; i < 20; i++)
        {
            if (names[i] == chineseName) break;
        }

        contextText.text = texts[i].text;
    }

    // Update is called once per frame
    void Update()
    {
    }
}