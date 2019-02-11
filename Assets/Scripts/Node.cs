using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {
    private int father;
    private int layer;
    private bool extend;
    private bool show;
    private Image image;
    private string name;

    public Node(int father, int layer, bool extend, bool show, Image image, string name)
    {
        this.father = father;
        this.layer = layer;
        this.extend = extend;
        this.show = show;
        this.image = image;
        this.name = name;
    }

    public bool isExtend()
    {
        return extend;
    }

    public Image getImage()
    {
        return image;
    }

    public float get_x()
    {
        return image.rectTransform.position.x;
    }

    public float get_y()
    {
        return image.rectTransform.position.y;
    }

    public void setExtend(bool extend)
    {
        this.extend = extend;
    }

    public float getHeight()
    {
        return image.rectTransform.rect.height;
    }

    public bool isShow()
    {
        return show;
    }

    public int getFather()
    {
        return father;
    }

    public void setShow(bool show)
    {
        this.show = show;
    }

    public bool getShow()
    {
        return show;
    }

    public int getLayer()
    {
        return layer;
    }
}
