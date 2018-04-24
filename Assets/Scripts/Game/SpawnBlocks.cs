using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour {

    public GameObject block, allCubes;
    private GameObject blockInst;
    private Vector3 blockPos;
    private float speed = 7f;
    private bool onPlace;

	void Start () {
        spawn();
	}
	
	void Update () {
		if(blockInst.transform.position != blockPos && !onPlace)
        {
           blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed); // двигаем блок к указаным позициям
        } else if (blockInst.transform.position == blockPos )
        {
            onPlace = true;
        }
        if(CubeJump.jump && CubeJump.nextBlock)
        {
            spawn();
            onPlace = false;
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
    void spawn()
    {
        blockPos = new Vector3(Random.Range(0f, 2.45f), Random.Range(-1f, 1f), 1f); //рандомная позиция блока
        blockInst = Instantiate(block, new Vector2(5f, -6f), Quaternion.identity) as GameObject; // спвним блок за пределами камеры
        blockInst.transform.localScale = new Vector2(blockInst.transform.localScale.x, blockInst.transform.localScale.y);
        blockInst.transform.parent = allCubes.transform;
    }
}
