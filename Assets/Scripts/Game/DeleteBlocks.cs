using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlocks : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) // когда другая платформа попадет в этот блок мы удаляем его
    {
        if(other.tag == "Block")
        {
            Destroy(other.gameObject);
        }
    }

}
