using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    void Start()
    {

    }

    public void Draw(GameObject dot)
    {
        Instantiate(dot, new Vector3(Random.value * 20 - 10, Random.value * 20, 0), Quaternion.identity);
    }

    void Update()
    {

    }
}
