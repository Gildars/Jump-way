using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1f,1f,1f);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
       
    }

    private void OnMouseUpAsButton() // метод сработает когда мы нажали на кнопку и отжали палец на тойже кнопке 
    {
        switch (gameObject.name)
        {
            case "Restart": //если нажали на кнопку рестарт
                SceneManager.LoadScene("main"); //загружаем сцену
                break;
            case "Facebook": //если нажали на кнопку рестарт
                Application.OpenURL("https://www.pornhub.com/");
                break;
        }
    }
  
}
