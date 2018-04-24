using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
    public static bool jump, nextBlock; //если jump == true, то мы можем прыгать
    public GameObject mainCube, buttons, lose_buttons;
    private bool animate, lose;
    private float scratch_speed = 0.5f, startTime, yPosCube;
    public static int count_blocks;
    private void Start()
    {
        jump = false;
        nextBlock = false;
        StartCoroutine(CanJump());
       
    }

    private void FixedUpdate()
    {
        /**Сжимаем  кубик при нажатии**/
        if (mainCube != null)
        {
            if (mainCube.GetComponent<Rigidbody2D>())
            {
                if (animate && mainCube.transform.localScale.y > 0.4f)
                {
                    PressCube(-scratch_speed);
                }
                else if (!animate && mainCube != null) // возвращаем кубик в исходное положение
                {
                    if (mainCube.transform.localScale.y < 1f)
                    {
                        PressCube(scratch_speed * 3f);
                    }
                    else if (mainCube.transform.localScale.y != 1f)
                    {
                        mainCube.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                }
                if ((mainCube.transform.position.x > 5f || mainCube.transform.position.y < -6f) && mainCube != null) // проиграли если кубик далеко улетел
                {
                    lose = true;
                    Destroy(mainCube, 1f);
                    print("Game over");
                }
            }
        }

        if (lose)
        {
            PlayerLose();
        }
    }

    void PlayerLose()
    {
        buttons.GetComponent<ScrollObjects>().checkPos = 10;
        if (!lose_buttons.activeSelf)
        {
            lose_buttons.SetActive(true);
        }
        lose_buttons.GetComponent<ScrollObjects>().checkPos = 50;
    }
    private void OnMouseDown()
    {
        if (nextBlock && mainCube.GetComponent<Rigidbody2D>())
        {
            animate = true;
            startTime = Time.time;
            yPosCube = mainCube.transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
        if (nextBlock && mainCube.GetComponent<Rigidbody2D>() && startTime != 0)
        {
            animate = false;
            jump = true;
            float force, diff;

            diff = Time.time - startTime; // время удержания кубика пальцем
          
            if (diff < 3f)
            {
                force = 190 * diff;
            }
            else
            {
                force = 280;
            }
            if (force < 60f)
            {
                force = 60f;
            }
            print(force);
            mainCube.GetComponent<Rigidbody2D>().AddRelativeForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody2D>().AddRelativeForce(mainCube.transform.right * force);

            StartCoroutine(checkCubesPos());
            nextBlock = false;
        }
    }
    private void PressCube(float force)
    {
        mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
    }

    IEnumerator checkCubesPos() // отслеживаем попали ли мы на другую платформу или остались на той же платформе 
    {
        yield return new WaitForSeconds(1f);
        if(false) // не работает, потом исправлю  (yPosCube == mainCube.transform.localPosition.y
        {
            print("Player Lose");
            lose = true;
            nextBlock = false;
        }
        else
        {
            while (!mainCube.GetComponent<Rigidbody2D>().IsSleeping()) // пока кубик двигается
            {
                yield return new WaitForSeconds(0.05f);
                if (mainCube != null)
                {
                    break; // как только кубик засыпает мы выходим из цикла  
                }
            }
            if (!lose)
            {
                nextBlock = true;
                count_blocks++;
                print("Next one");
             //   mainCube.transform.localPosition = new Vector3(0, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z); // выравниваем кубик по центру платформы
                mainCube.transform.localEulerAngles = new Vector3(0f,360f, 0f); // кубик будет всегда повернут в нужную нам сторону 
            }
        }
    }

    IEnumerator CanJump() // эта куратина нужна что бы была задержка после запуска игры, после чего можно прыгать 
    {
        while (!mainCube.GetComponent<Rigidbody2D>()) // ждем пока кубик не получит компонент Rigidbody
        {
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1f); //после того как кубик получил компонент Rigidbody ждем 1 сек
        nextBlock = true;
    }
}
