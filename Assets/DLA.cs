using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLA : MonoBehaviour
{
    public int numWalkers;
    public GameObject dotPrefab;
    readonly List<Walker> walkers = new List<Walker>();
    readonly List<Walker> tree = new List<Walker>();
    GameObject treeContainer;
    GameObject walkerContainer;

    void Start()
    {
        walkerContainer = GameObject.Find("Walkers");
        for (var i = 0; i < numWalkers; i++)
        {
            walkers.Add(CreateWalker());
        }
        treeContainer = GameObject.Find("Tree");
        Walker trunk = gameObject.AddComponent<Walker>();
        trunk.transform.position = Vector3.zero;
        trunk.Draw(dotPrefab, treeContainer);
        trunk.Attach(Vector3.zero);
        tree.Add(trunk);
    }

    float DistanceBetween(Vector3 v1, Vector3 v2)
    {
        Vector3 heading;
        heading.x = v1.x - v2.x;
        heading.y = v1.y - v2.y;
        heading.z = v1.z - v2.z;

        float distance = heading.x * heading.x + heading.y * heading.y + heading.z * heading.z;
        return distance;
    }

    Walker CreateWalker()
    {
        Walker walker = gameObject.AddComponent<Walker>();
        walker.Draw(dotPrefab, walkerContainer);
        walker.SetRandomPosition();
        return walker;
    }

    void Update()
    {
        float calcDist = Mathf.Pow(.5f, 2f);
        if (tree.Count < 200)
        {
            for (var i = walkers.Count - 1; i >= 0; i--)
            {
                Walker w = walkers[i];
                w.Walk();
                for (var j = tree.Count - 1; j >= 0; j--)
                {
                    if (DistanceBetween(w.Position, tree[j].Position) < calcDist)
                    {
                        tree.Add(w);
                        w.Attach(tree[j].Position);
                        walkers.RemoveAt(i);
                        walkers.Add(CreateWalker());
                        break;
                    }
                }
                // if (w.Position.y < 0)
                // {
                //     Destroy(w.dot);
                //     walkers.RemoveAt(i);
                // }
            }
        }
        else if (walkers.Count > 0)
        {
            for (var i = walkers.Count - 1; i >= 0; i--)
            {
                DestroyImmediate(walkers[i].dot, true);
                walkers.RemoveAt(i);
            }
        }
    }
}
