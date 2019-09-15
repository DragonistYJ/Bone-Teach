using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    public Text columnName;
    public Text firstMenuName;
    public Text secondMenuName;
    public Text thirdMenuName;
    public Image firstMenu;
    public Image secondMenu;
    public Image thirdMenu;

    private readonly Node[] nodes = new Node[22];
    private Node currentNode;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 22; i++) nodes[i] = new Node();
        nodes[0].name = "全身骨骼";
        nodes[0].englishName = "Whole Skeleton";
        nodes[0].firstNext = nodes[1];
        nodes[0].secondNext = nodes[2];

        nodes[1].name = "中轴骨骼";
        nodes[1].englishName = "Axial Skeleton";
        nodes[1].pre = nodes[0];
        nodes[1].firstNext = nodes[3];
        nodes[1].secondNext = nodes[4];

        nodes[3].name = "颅骨";
        nodes[3].englishName = "Skull";
        nodes[3].pre = nodes[1];
        nodes[3].hasChild = false;

        nodes[4].name = "躯干骨骼";
        nodes[4].englishName = "Trunk Skeleton";
        nodes[4].pre = nodes[1];
        nodes[4].firstNext = nodes[5];
        nodes[4].secondNext = nodes[6];

        nodes[5].name = "椎骨";
        nodes[5].englishName = "Vertebrae";
        nodes[5].pre = nodes[4];
        nodes[5].hasChild = false;

        nodes[6].name = "胸廓";
        nodes[6].englishName = "Thorax";
        nodes[6].pre = nodes[4];
        nodes[6].hasChild = false;

        nodes[2].name = "四肢骨骼";
        nodes[2].englishName = "Limb Skeleton";
        nodes[2].pre = nodes[0];
        nodes[2].firstNext = nodes[7];
        nodes[2].secondNext = nodes[8];

        nodes[7].name = "上肢骨骼";
        nodes[7].englishName = "Upper Limb";
        nodes[7].pre = nodes[2];
        nodes[7].firstNext = nodes[9];
        nodes[7].secondNext = nodes[10];
        nodes[7].hasThirdChild = true;
        nodes[7].thirdNext = nodes[11];

        nodes[9].name = "上肢带骨";
        nodes[9].englishName = "Upper limb with bone";
        nodes[9].pre = nodes[7];
        nodes[9].firstNext = nodes[12];
        nodes[9].secondNext = nodes[13];

        nodes[12].name = "锁骨";

        nodes[12].pre = nodes[9];
        nodes[12].englishName = "Clavicle";
        nodes[12].hasChild = false;
        nodes[13].name = "肩胛骨";
        nodes[13].pre = nodes[9];
        nodes[13].hasChild = false;

        nodes[10].name = "上肢自由骨";
        nodes[10].englishName = "Free bone of upper limb";
        nodes[10].pre = nodes[7];
        nodes[10].firstNext = nodes[14];
        nodes[10].secondNext = nodes[15];

        nodes[14].name = "肱骨";
        nodes[14].englishName = "Humerus";
        nodes[14].pre = nodes[10];
        nodes[14].hasChild = false;

        nodes[15].name = "尺骨和桡骨";
        nodes[15].englishName = "Ulna and Radius";
        nodes[15].pre = nodes[10];
        nodes[15].hasChild = false;

        nodes[11].name = "掌骨";
        nodes[11].englishName = "Metacarpal Bone";
        nodes[11].pre = nodes[7];
        nodes[11].hasChild = false;

        nodes[8].name = "下肢骨骼";
        nodes[8].englishName = "Lower Limb Skeleton";
        nodes[8].pre = nodes[2];
        nodes[8].firstNext = nodes[16];
        nodes[8].secondNext = nodes[17];
        nodes[8].hasThirdChild = true;
        nodes[8].thirdNext = nodes[18];

        nodes[16].name = "髋骨";
        nodes[16].englishName = "Hip Bone";
        nodes[16].pre = nodes[8];
        nodes[16].hasChild = false;

        nodes[17].name = "下肢自由骨";
        nodes[17].englishName = "Free bone of lower extremity";
        nodes[17].pre = nodes[8];
        nodes[17].firstNext = nodes[19];
        nodes[17].secondNext = nodes[20];
        nodes[17].hasThirdChild = true;
        nodes[17].thirdNext = nodes[21];

        nodes[19].name = "股骨";
        nodes[19].englishName = "Femur";
        nodes[19].pre = nodes[17];
        nodes[19].hasChild = false;

        nodes[20].name = "髌骨";
        nodes[20].englishName = "Patella";
        nodes[20].pre = nodes[17];
        nodes[20].hasChild = false;

        nodes[21].name = "胫骨和腓骨";
        nodes[21].englishName = "Tibia and Fibula";
        nodes[21].pre = nodes[17];
        nodes[21].hasChild = false;

        nodes[18].name = "脚掌骨";
        nodes[18].englishName = "Feet Bone";
        nodes[18].pre = nodes[8];
        nodes[18].hasChild = false;

        currentNode = nodes[0];
    }

    // Update is called once per frame
    void Update()
    {
        //firstMenuName.transform.localPosition = new Vector2(100, 100);
    }

    public void FirstBook()
    {
        PlayerPrefs.SetString("name", currentNode.firstNext.name);
        PlayerPrefs.SetString("english", currentNode.firstNext.englishName);
        SceneManager.LoadScene("introduce");
    }

    public void FirstAR()
    {
        if (currentNode.firstNext.hasChild) return;

        SceneManager.LoadScene(currentNode.firstNext.name);
    }

    public void SecondBook()
    {
        PlayerPrefs.SetString("name", currentNode.secondNext.name);
        PlayerPrefs.SetString("english", currentNode.secondNext.englishName);
        SceneManager.LoadScene("introduce");
    }

    public void SecondAR()
    {
        if (currentNode.secondNext.hasChild) return;

        SceneManager.LoadScene(currentNode.secondNext.name);
    }

    public void ThirdBook()
    {
        PlayerPrefs.SetString("name", currentNode.thirdNext.name);
        PlayerPrefs.SetString("english", currentNode.thirdNext.englishName);
        SceneManager.LoadScene("introduce");
    }

    public void ThirdAR()
    {
        if (currentNode.thirdNext.hasChild) return;

        SceneManager.LoadScene(currentNode.thirdNext.name);
    }

    public void FirstMenuClick()
    {
        if (!currentNode.firstNext.hasChild) return;

        Change2Position();
        currentNode = currentNode.firstNext;
        columnName.text = currentNode.name;
        firstMenuName.text = currentNode.firstNext.name;
        secondMenuName.text = currentNode.secondNext.name;

        if (currentNode.hasThirdChild)
        {
            thirdMenuName.text = currentNode.thirdNext.name;
            Change3Position();
        }
    }

    public void SecondMenuClick()
    {
        if (!currentNode.secondNext.hasChild) return;

        Change2Position();
        currentNode = currentNode.secondNext;
        columnName.text = currentNode.name;
        firstMenuName.text = currentNode.firstNext.name;
        secondMenuName.text = currentNode.secondNext.name;

        if (currentNode.hasThirdChild)
        {
            thirdMenuName.text = currentNode.thirdNext.name;
            Change3Position();
        }
    }

    public void ThirdMenuClick()
    {
        if (!currentNode.thirdNext.hasChild) return;

        Change2Position();
        currentNode = currentNode.thirdNext;
        columnName.text = currentNode.name;
        firstMenuName.text = currentNode.firstNext.name;
        secondMenuName.text = currentNode.secondNext.name;

        if (currentNode.hasThirdChild)
        {
            thirdMenuName.text = currentNode.thirdNext.name;
            Change3Position();
        }
    }

    public void Back()
    {
        if (currentNode.name == "全身骨骼") return;
        currentNode = currentNode.pre;
        columnName.text = currentNode.name;
        firstMenuName.text = currentNode.firstNext.name;
        secondMenuName.text = currentNode.secondNext.name;

        if (currentNode.hasThirdChild)
        {
            thirdMenuName.text = currentNode.thirdNext.name;
            Change3Position();
        }
        else
        {
            Change2Position();
        }
    }

    private void Change2Position()
    {
        firstMenu.transform.localPosition = new Vector2(85, 200);
        secondMenu.transform.localPosition = new Vector2(85, -50);
        thirdMenu.transform.localPosition = new Vector2(800, -300);
    }

    private void Change3Position()
    {
        firstMenu.transform.localPosition = new Vector2(85, 250);
        secondMenu.transform.localPosition = new Vector2(85, 50);
        thirdMenu.transform.localPosition = new Vector2(85, -150);
    }

    public void setInit()
    {
        Change2Position();
        currentNode = nodes[0];
        columnName.text = currentNode.name;
        firstMenuName.text = currentNode.firstNext.name;
        secondMenuName.text = currentNode.secondNext.name;
    }
}