using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{

    public GameObject mainCube;
    private bool animate, jumped;
    private float scratch_speed = 0.5f, startTime, yPosCube;

    private void FixedUpdate()
    {
        /**Сжимаем  кубик при нажатии**/
        if (animate && mainCube.transform.localScale.y > 0.4f)
        {
            PressCube(-scratch_speed);
        }
        else if (!animate) // возвращаем кубик в исходное положение
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
        if (mainCube.GetComponent<Rigidbody>())
        {
            if(mainCube.GetComponent<Rigidbody>().IsSleeping() && jumped) //  если кубик стоит и не двигается и мы прыгнули значит кубик стоит на новой платформе
            {
                print("Next one");
                mainCube.transform.localPosition = new Vector3(0f, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z); // выравниваем кубик по центру платформы
                mainCube.transform.localEulerAngles = new Vector3(0f, mainCube.transform.eulerAngles.y, 0f); // кубик будет всегда повернут в нужную нам сторону 
            }
        }
    }
    private void OnMouseDown()
    {
        if (mainCube.GetComponent<Rigidbody>())
        {
            animate = true;
            startTime = Time.time;

            yPosCube = mainCube.transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
        if (mainCube.GetComponent<Rigidbody>())
        {
            animate = false;

            //Прыжок
            jumped = true;
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
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * -force);

            StartCoroutine(checkCubesPos());
            
        }
    }
    private void PressCube(float force)
    {
        mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
    }

    IEnumerator checkCubesPos() //  отслеживаем попали ли мы на другой кубик или на тот же самый кубик
    {
        yield return new WaitForSeconds(1f);
        if(yPosCube == mainCube.transform.localPosition.y) // не работает, потом исправлю 
        {
            print("Player Lose");
        }
    }
}
