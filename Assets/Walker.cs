using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    GameObject dot;
    float maxY = 20f;

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
        dot.transform.position = new Vector3(Random.value * 20 - 10, Random.value * maxY, 0);
    }

    public Vector3 Position
    {
        get => dot.transform.position;
    }

    public void Walk()
    {
        dot.transform.position += new Vector3(Random.value / 10 - 0.05f, -Random.value / 10, 0);
        if (dot.transform.position.y < 0) {
            dot.transform.position = new Vector3(Random.value * 20 - 10, maxY, 0);
        }
    }

    void Update()
    {

    }
}
