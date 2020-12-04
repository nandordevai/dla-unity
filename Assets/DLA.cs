using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLA : MonoBehaviour
{
    public int numWalkers;
    public GameObject dotPrefab;

    List<Walker> walkers = new List<Walker>();

    void Start()
    {
        for (var i = 0; i < numWalkers; i++) {
            Walker walker = gameObject.AddComponent<Walker>();
            walker.Draw(dotPrefab);
            walkers.Add(walker);
        }
    }

    void Update()
    {
        
    }
}
