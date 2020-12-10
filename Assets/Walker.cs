using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public GameObject dot;
    public GameObject branchPrefab;
    float areaSize = 10f;
    Renderer r;

    void Start()
    {
    }

    public void Draw(GameObject dotP, GameObject container)
    {
        dot = Instantiate(dotP, Vector3.zero, Quaternion.identity);
        dot.transform.SetParent(container.transform);
        dot.transform.position = Vector3.zero;
        r = dot.GetComponent<Renderer>();
        r.enabled = false;
    }

    public void Attach(Vector3 toPos)
    {
        r.enabled = true;
        Vector3 pos = Vector3.Lerp(toPos, Position, .5f);
        branchPrefab = (GameObject)Resources.Load("Branch");
        GameObject branch = Instantiate(branchPrefab);
        branch.transform.position = pos;
        branch.transform.up = toPos - Position;
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
