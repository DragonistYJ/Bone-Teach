using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tree : MonoBehaviour {
    private static int SUM = 20;
    private Node[] nodes = new Node[SUM];
    private float []interval = new float[7];
    private float top;

    public Image[] images = new Image[SUM];
    public Image panel;
    
	// Use this for initialization
	void Start () {
        //int father, int layer, bool extend, bool show, Image image, string name
        nodes[0] = new Node(-1, 0, false, true, images[0], "中轴骨骼");
        nodes[1] = new Node(0, 1, false, false, images[1], "躯干骨骼");
        nodes[2] = new Node(1, 2, false, false, images[2], "椎骨");
        nodes[3] = new Node(1, 2, false, false, images[3], "胸廓");
        nodes[4] = new Node(0, 1, false, false, images[4], "颅骨"); 
        nodes[5] = new Node(-1, 0, false, true, images[5], "四肢骨骼");
        nodes[6] = new Node(5, 1, false, false, images[6], "上肢骨骼");
        nodes[7] = new Node(6, 2, false, false, images[7], "锁骨");
        nodes[8] = new Node(6, 2, false, false, images[8], "肩胛骨");
        nodes[9] = new Node(6, 2, false, false, images[9], "上肢自由骨");
        nodes[10] = new Node(9, 3, false, false, images[10], "尺骨和桡骨");
        nodes[11] = new Node(9, 3, false, false, images[11], "肱骨");
        nodes[12] = new Node(6, 2, false, false, images[12], "手掌骨");
        nodes[13] = new Node(5, 1, false, false, images[13], "下肢骨骼");
        nodes[14] = new Node(13, 2, false, false, images[14], "下肢带骨");
        nodes[15] = new Node(13, 2, false, false, images[15], "下肢自由骨");
        nodes[16] = new Node(15, 3, false, false, images[16], "股骨");
        nodes[17] = new Node(15, 3, false, false, images[17], "胫骨和腓骨");
        nodes[18] = new Node(13, 2, false, false, images[18], "脚掌骨");
        nodes[19] = new Node(13, 2, false, false, images[19], "髌骨");


        interval[0] = nodes[0].get_y() - nodes[5].get_y();     //第零层之间
        interval[1] = nodes[5].get_y() - nodes[1].get_y();     //第零层与第一层
        interval[2] = nodes[1].get_y() - nodes[4].get_y();      //第一层之间
        interval[3] = nodes[4].get_y() - nodes[2].get_y();      //第一层与第二层
        interval[4] = nodes[2].get_y() - nodes[3].get_y();      //第二层之间
        interval[5] = nodes[3].get_y() - nodes[10].get_y();      //第二层和第三层
        interval[6] = nodes[10].get_y() - nodes[11].get_y();      //第三层之间

        top = nodes[0].get_y();

        for (int i = 1; i < SUM; i++)
        {
            nodes[i].getImage().enabled = false;
            nodes[i].getImage().GetComponentInChildren<Text>().enabled = false;
            nodes[i].getImage().transform.GetChild(1).GetComponent<Image>().enabled = false;
        }
        nodes[5].getImage().enabled = true ;
        nodes[5].getImage().GetComponentInChildren<Text>().enabled = true;
        nodes[5].getImage().transform.GetChild(1).GetComponentInChildren<Image>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void click_0()
    {
        if (nodes[0].isExtend())
        {
            for (int i = 1; i < SUM; i++)
            {
                if (nodes[i].getFather() == 0 || nodes[i].getFather() == 1)
                {
                    nodes[i].setShow(false);
                }
            }
            nodes[0].setExtend(false);
            nodes[1].setExtend(false);
        } else
        {
            nodes[1].setShow(true);
            nodes[4].setShow(true);
            nodes[0].setExtend(true);
        }

        display();
        check();
    }

    public void click_1()
    {
        if (nodes[1].isExtend())
        {
            for (int i = 1; i < SUM; i++)
            {
                if (nodes[i].getFather() == 1)
                {
                    nodes[i].setShow(false);
                }
            }
            nodes[1].setExtend(false);
        }
        else
        {
            nodes[2].setShow(true);
            nodes[3].setShow(true);
            nodes[1].setExtend(true);
        }

        display();
        check();
    }

    public void click_5()
    {
        if (nodes[5].isExtend())
        {
            for (int i = 1; i < SUM; i++)
            {
                if (nodes[i].getFather() == 5 || nodes[i].getFather() == 6 || nodes[i].getFather() == 13 || nodes[i].getFather() == 15 || nodes[i].getFather() == 9)
                {
                    nodes[i].setShow(false);
                }
            }
            nodes[5].setExtend(false);
            nodes[6].setExtend(false);
            nodes[13].setExtend(false);
            nodes[15].setExtend(false);
            nodes[9].setExtend(false);
        }
        else
        {
            nodes[6].setShow(true);
            nodes[13].setShow(true);
            nodes[5].setExtend(true);
        }

        display();
        check();
    }

    public void click_6()
    {
        if (nodes[6].isExtend())
        {
            for (int i = 1; i < SUM; i++)
            {
                if (nodes[i].getFather() == 6 || nodes[i].getFather() == 9)
                {
                    nodes[i].setShow(false);
                }
            }
            nodes[6].setExtend(false);
            nodes[9].setExtend(false);
        }
        else
        {
            nodes[7].setShow(true);
            nodes[8].setShow(true);
            nodes[9].setShow(true);
            nodes[12].setShow(true);
            nodes[6].setExtend(true);
        }

        display();
        check();
    }

    public void click_9()
    {
        if (nodes[9].isExtend())
        {
            for (int i = 1; i < SUM; i++)
            {
                if (nodes[i].getFather() == 9)
                {
                    nodes[i].setShow(false);
                }
            }
            nodes[9].setExtend(false);
        }
        else
        {
            nodes[10].setShow(true);
            nodes[11].setShow(true);
            nodes[9].setExtend(true);
        }

        display();
        check();
    }

    public void click_13()
    {
        if (nodes[13].isExtend())
        {
            for (int i = 1; i < SUM; i++)
            {
                if (nodes[i].getFather() == 13 || nodes[i].getFather() == 15)
                {
                    nodes[i].setShow(false);
                }
            }
            nodes[13].setExtend(false);
            nodes[15].setExtend(false);
        }
        else
        {
            nodes[14].setShow(true);
            nodes[15].setShow(true);
            nodes[18].setShow(true);
            nodes[19].setShow(true);
            nodes[13].setExtend(true);
        }

        display();
        check();
    }

    public void click_15()
    {
        if (nodes[15].isExtend())
        {
            nodes[16].setShow(false);
            nodes[17].setShow(false);
            nodes[15].setExtend(false);
        }
        else
        {
            nodes[16].setShow(true);
            nodes[17].setShow(true);
            nodes[15].setExtend(true);
        }

        display();
        check();
    }

    void display()
    {
        int pre = 0;
        for (int i = 1; i < SUM; i++)
        {
            if (nodes[i].getShow())
            {
                nodes[i].getImage().enabled = true;
                nodes[i].getImage().GetComponentInChildren<Text>().enabled = true;
                nodes[i].getImage().transform.GetChild(1).GetComponentInChildren<Image>().enabled = true;
                nodes[i].getImage().transform.position = new Vector2(nodes[i].get_x(), nodes[pre].get_y() - interval[nodes[pre].getLayer() + nodes[i].getLayer()]);
                pre = i;
            }
            else
            {
                nodes[i].getImage().enabled = false;
                nodes[i].getImage().GetComponentInChildren<Text>().enabled = false;
                nodes[i].getImage().transform.GetChild(1).GetComponentInChildren<Image>().enabled = false;
                //nodes[i].getImage().transform.position = new Vector2(nodes[i].get_x(), 2000);
            }
        }

        if (nodes[pre].get_y() - interval[nodes[pre].getLayer()] < 0 )      //底部超出边界
        {
            panel.rectTransform.offsetMin = new Vector2(0, nodes[pre].get_y() - interval[nodes[pre].getLayer()] - 300);
        } else if ((nodes[0].get_y() - top) < 10 && nodes[pre].get_y() > 0)     //顶部不动，底部收缩回边界
        {
            panel.rectTransform.offsetMax = new Vector2(0, 0);
            panel.rectTransform.offsetMin = new Vector2(0, 0);
        } else if ((nodes[0].get_y() - top) > 10 && (nodes[pre].get_y() > 0))        //顶部超出边界，底部回收回边界
        {
            if ((nodes[0].get_y() - top) > nodes[pre].get_y())
            {
                panel.rectTransform.offsetMax = new Vector2(0, panel.rectTransform.offsetMax.y - nodes[pre].get_y());
            } else
            {
                panel.rectTransform.offsetMax = new Vector2(0, panel.rectTransform.offsetMax.y - (nodes[0].get_y() - top));
            }
        }
    }

    void check()
    {
        if (panel.rectTransform.offsetMin.y > 0 && panel.rectTransform.offsetMax.y > 0)     //缩小了就回放
        {
            panel.rectTransform.offsetMin = new Vector2(0, 0);
        }
    }
}
