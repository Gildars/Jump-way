using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour // класс усложняет игру
{
    private bool hard;

    private void Update()
    {
        if (CubeJump.count_blocks > 0)
        {
            if (CubeJump.count_blocks % 2 == 0 && !hard)
            {
                print("Harder");
                Camera.main.GetComponent<Animation>().Play("Harder");
                hard = true;
            }
            else if (CubeJump.count_blocks % 3 == 0 && hard)
            {
                print("Easyer");
                hard = false;
                Camera.main.GetComponent<Animation>().Play("Easier");
            }
        }
    }
}
    
