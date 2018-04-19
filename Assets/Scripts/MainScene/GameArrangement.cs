using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameArrangement : MonoBehaviour {

    public GameObject[] cubes;
    public GameObject buttons, m_cube;
    public Text playTxt, gameName; // текстовые поля
    public Light dirLight, dirLight_2;
    public Animation cubes_anim, block;

    private bool clicked;

    void Update()
    {
        if (clicked && dirLight.intensity != 0)
        {
            dirLight.intensity -= 0.03f; // уменьшает интенсивнсоть света
            if (clicked && dirLight_2.intensity >= 1.05f)
            {
                dirLight_2.intensity -= 0.025f;
            }
        }
    }

    void OnMouseDown()
    {
        if (!clicked) // если мы один раз нажали, то все больше эти действия не будут выполняться 
        {
            StartCoroutine(delCubes());
            clicked = true;
            playTxt.gameObject.SetActive(false); // деактивируем / скрываем 
            gameName.text = "0"; // здесь будет записываться кол. очков 
            buttons.GetComponent<ScrollObjects>().speed = -5f; // кнопки двигаються вниз 
            buttons.GetComponent<ScrollObjects>().checkPos = -130f;
            m_cube.GetComponent<Animation>().Play("StartGameCube"); // проигрываем анимацию mainCube
            StartCoroutine(cubeToBlock());
            m_cube.transform.localScale = new Vector3(1f, 1f, 1f);
            cubes_anim.Play(); // проигрываем всю анимацию кубиков
        }
    }



    IEnumerator delCubes() // куратина которая удаляет кубики по очереди 
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            cubes[i].GetComponent<FallCube>().enabled = true;
        }
    }
    IEnumerator cubeToBlock()
    {
        yield return new WaitForSeconds(m_cube.GetComponent<Animation>().clip.length);
        block.Play();
    }
}﻿

