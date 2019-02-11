using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panel_mid : MonoBehaviour {
    public Text name;
    public Image mid;
    public Image left;
    public Image right;
    public Sprite[] sprites = new Sprite[12];

    private Animator animator;
    private Vector2 touch_1;
    private Vector2 touch_2;
    private string[,] names = new string[4,3];
    private int num_1, num_2, sum;
    private int[] amount = new int[4];

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        names[0, 0] = "椎骨"; names[0, 1] = "肋骨"; names[0, 2] = "胸骨"; amount[0] = 3;
        names[1, 0] = "脑颅骨"; names[1, 1] = "面颅骨"; amount[1] = 2;
        names[2, 0] = "上肢带骨"; names[2, 1] = "上肢自由骨"; names[2, 2] = "手掌骨"; amount[2] = 3;
        names[3, 0] = "下肢带骨"; names[3, 1] = "下肢自由骨"; names[3, 2] = "脚掌骨"; amount[3] = 3;
        name.text = names[num_1, num_2];

        num_1 = 0; num_2 = 0; sum = 0;
        for (int i = 0; i < num_1; i++) sum = sum + amount[num_1];

        mid.sprite = sprites[sum + num_2];
        if (num_2 == amount[num_1] - 1) right.sprite = sprites[sum];
        else right.sprite = sprites[sum + num_2 + 1];
        if (num_2 == 0) left.sprite = sprites[sum + amount[num_1] - 1];
        else left.sprite = sprites[sum + num_2 - 1];
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void begin()
    {
        touch_1 = Input.mousePosition;
    }

    public void end()
    {
        touch_2 = Input.mousePosition;
        if (touch_1.x > touch_2.x) to_left();
        else to_right();
    }

    private void to_left()
    {
        num_2 = (num_2 + 1) % amount[num_1];
        name.text = names[num_1, num_2];
        animator.SetBool("isplay", true);
        animator.SetBool("toleft", true);
        StartCoroutine(sleep());
    }

    private void to_right()
    {
        num_2 = num_2 - 1;
        if (num_2 < 0) num_2 = amount[num_1] - 1;
        name.text = names[num_1, num_2];
        animator.SetBool("isplay", true);
        animator.SetBool("toright", true);
        StartCoroutine(sleep());
    }

    IEnumerator sleep()
    {
        yield return new WaitForSeconds(1.25f);
        mid.sprite = sprites[sum + num_2];
        if (num_2 == amount[num_1] - 1) right.sprite = sprites[sum];
        else right.sprite = sprites[sum + num_2 + 1];
        if (num_2 == 0) left.sprite = sprites[sum + amount[num_1] - 1];
        else left.sprite = sprites[sum + num_2 - 1];
        animator.SetBool("isplay", false);
        animator.SetBool("toright", false);
        animator.SetBool("toleft", false);
    }
}
