using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectClicks : MonoBehaviour {

    public GameObject buttons, m_cube;
    public Text playTxt, gameName; // текстовые поля
    private bool clicked;
    void OnMouseDown()
    {
        if (!clicked) // если мы один раз нажали, то все больше эти действия не будут выполняться 
        {
            clicked = true;
            playTxt.gameObject.SetActive(false); // деактивируем / скрываем 
            gameName.text = "0"; // здесь будет записываться кол. очков 
            buttons.GetComponent<ScrollObjects>().speed = -5f; // кнопки двигаються вниз 
            buttons.GetComponent<ScrollObjects>().checkPos = -130f;
            m_cube.GetComponent<Animation>().Play("StartGameCube");
        }
    }
}﻿

