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
            Walker walker = gameObject.AddComponent<Walker>();
            walker.Draw(dotPrefab, walkerContainer);
            walker.SetRandomPosition();
            walkers.Add(walker);
        }
        treeContainer = GameObject.Find("Tree");
        Walker trunk = gameObject.AddComponent<Walker>();
        trunk.transform.position = new Vector3(0, 0, 0);
        trunk.Draw(dotPrefab, treeContainer);
        tree.Add(trunk);
    }

    void Update()
    {
        for (var i = walkers.Count - 1; i >= 0; i--)
        {
            Walker w = walkers[i];
            w.Walk();
        }
    }
}
