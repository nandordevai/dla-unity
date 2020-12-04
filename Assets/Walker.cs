using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    GameObject dot;

    void Start()
    {
    }

    public void Draw(GameObject dotP, GameObject container)
    {
        dot = Instantiate(dotP, new Vector3(0, 0, 0), Quaternion.identity);
        dot.transform.SetParent(container.transform);
    }

    public void SetRandomPosition()
    {
        dot.transform.position = new Vector3(Random.value * 20 - 10, Random.value * 20, 0);
    }

    public void Walk()
    {
        dot.transform.position += new Vector3(Random.value / 10 - 0.05f, -Random.value / 10, 0);
    }

    void Update()
    {

    }
}
