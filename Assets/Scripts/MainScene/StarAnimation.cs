using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour {

    private SpriteRenderer star;
    private float _movementSpeed = 0.1f;

     void Start()
    {
        star = GetComponent<SpriteRenderer>(); //присвоение 
        Destroy(gameObject, 5f); // уничтожаем звездочку через 5сек
    }
     void Update()
    {
        star.color = new Color(star.color.r, star.color.g, star.color.b, Mathf.PingPong(Time.time / 2.5f, 1.0f)); //меняем прозрачность
        transform.position += transform.up * Time.deltaTime * _movementSpeed; //перемещаем

    }
}
