using UnityEngine;
using System.Collections;

public class SpawnStars : MonoBehaviour
{

    public GameObject star;
    void Start()
    {
        StartCoroutine(spawn()); // создаем куратину https://habrahabr.ru/post/216185/
    }

    IEnumerator spawn()
    {
        while (true) // бесконечный цыкл для создания звездочек
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            Instantiate(star, pos, Quaternion.Euler(0,0, Random.Range(0f,360f))); /* создание звездочки Quaternion.identity 
            Quaternion.Euler меняем  по оси z рандомный угол от 0 до 360 градусов.
            */
            yield return new WaitForSeconds(5.01f); // создаем новую звездочку через 5 сек
        }
    }
}
