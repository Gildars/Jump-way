using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour {

    public GameObject block;
    private GameObject blockInst;
    private Vector3 blockPos;
    private float speed = 7f;
	void Start () {
        blockPos = new Vector3(Random.Range(1.7f, 1.7f), -Random.Range(0.7f, 3.2f), -2f); //рандомная позиция блока
        blockInst = Instantiate(block, new Vector3(5f, -6f, 0f), Quaternion.identity) as GameObject; // спвним блок за пределами камеры
        blockInst.transform.localScale = new Vector3(randScale(), blockInst.transform.localScale.y, 5f);
	}
	
	void Update () {
		if(blockInst.transform.position != blockPos)
        {
           blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed); // двигаем блок к указаным позициям
        }
	}
    private float randScale()
    {
        float rand;
        if (Random.Range(0,100) > 80)
        {
            rand = Random.Range(1.2f, 2f);
        } else
        {
            rand = Random.Range(1.2f, 1.5f);
        }
        return rand;
    }
}
