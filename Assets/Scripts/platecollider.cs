﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platecollider : MonoBehaviour
{
    [SerializeField] private bool status;
    [SerializeField] private GameObject txt;
    private SpriteRenderer spriteR;
    public Sprite active;
    public Sprite unactive;
    

    private void Start() {
        spriteR = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameManager.instance.player )
        {
           txt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        inputController input;
        if(other.gameObject == GameManager.instance.player )
        {
            input = other.gameObject.GetComponent<inputController>();
            if(input.action)
            {
                if(status)
                {
                    status = false;
                    ChangeAnswerQuantity();
                    return;
                }
                else if(textManager.instance.activatedTexts < 2)
                {
                    status = true;
                    ChangeAnswerQuantity();
                }
            }
        }
    }

    private void ChangeAnswerQuantity()
    {
        if(status)
        {
            textManager.instance.activatedTexts++;
        }
        else
        {
            textManager.instance.activatedTexts--;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == GameManager.instance.player )
        {
            txt.SetActive(false);
        }
    }

    private void Update() {
        if(status)
        {
            spriteR.sprite = active;
        }
        else
        {
            spriteR.sprite = unactive;
        }
    }
}
