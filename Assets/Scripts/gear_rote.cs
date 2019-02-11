using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gear_rote : MonoBehaviour {
    private Animator animator;
    private Vector2 touch_1;
    private Vector2 touch_2;
    private float timer_1;
    private float timer_2;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnMouseDown()
    {
        touch_1 = Input.mousePosition;
        touch_2 = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        touch_2 = Input.mousePosition;
        if (touch_1.x > touch_2.x)
        {
            if (animator.GetBool("rote1")) { set(); animator.SetBool("rote3", true); }
            else { set(); animator.SetBool("rote1", true); }
        }
        else if (touch_1.x < touch_2.x)
        {
            if (animator.GetBool("rote2")) { set(); animator.SetBool("rote4", true); }
            else { set(); animator.SetBool("rote2", true); }
        }
    }

    private void set()
    {
        animator.SetBool("rote1", false);
        animator.SetBool("rote2", false);
        animator.SetBool("rote3", false);
        animator.SetBool("rote4", false);
    }
}


