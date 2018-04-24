using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour { // скрипт отвечает за передвижение блоков

    private bool moved = true;
    private Vector3 target;

    private void Start () {
        target = new Vector3(-1.66f, 2.36f, 0f); // указываем изначальные позиции кубика, что бы как только игра загрузилась он не  куда не двигался
	}

    private void Update()
    {

        if (CubeJump.nextBlock) // если nextBlock == true значит мы прыгнули
        {
            print("Target : " + target);
            if (transform.position != target) // двигаем кубик если он находится не в таргете
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);
            } else if (transform.position == target && !moved) // добавляем новый таргет
            {
                target = new Vector3(transform.position.x - 3.4f, transform.position.y + 2.29f, transform.position.z);
                CubeJump.jump = false;
                moved = true;
            }
            if (CubeJump.jump)
            {
                moved = false;
            }
        }
    }

}
