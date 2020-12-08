using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public GameObject dot;
    float areaSize = 10f;
    Renderer r;

    void Start()
    {
    }

    public void Draw(GameObject dotP, GameObject container)
    {
        dot = Instantiate(dotP, new Vector3(0, 0, 0), Quaternion.identity);
        dot.transform.SetParent(container.transform);
        r = dot.GetComponent<Renderer>();
        // r.enabled = false;
    }

    public void Attach()
    {
        // r.enabled = true;
    }

    public void SetRandomPosition()
    {
        dot.transform.position = new Vector3(
            Random.value * areaSize - areaSize / 2,
            Random.value * areaSize,
            Random.value * areaSize - areaSize / 2
        );
    }

    public Vector3 Position
    {
        get => dot.transform.position;
    }

    public void Walk()
    {
        float dx = Random.value / 10 - 0.05f;
        float dy = -.15f;
        float dz = Random.value / 10 - 0.05f;
        dot.transform.position += new Vector3(dx, dy, dz);
        if (dot.transform.position.y < 0) {
            dot.transform.position = new Vector3(
            Random.value * areaSize - areaSize / 2,
            areaSize,
            Random.value * areaSize - areaSize / 2
        );
        }
    }

    void Update()
    {

    }
}
