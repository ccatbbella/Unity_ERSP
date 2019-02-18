using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Size : MonoBehaviour
{
    private int index = 0;   // use to index my sizes list
    [SerializeField] private float growthTime = 1;    // how long to pause before reading the next value in sizes
    [SerializeField] private string fileName;
    List<float> sizes = new List<float>();
    private List<Transform> trees = new List<Transform>();

    private void Start()
    {
        sizes = GameFunctions.Read(fileName, "biomass");
        Debug.Log("Read sizes size is " + sizes.Count);
        StartCoroutine(WaitThenChangeSize(0));
    }

    IEnumerator WaitThenChangeSize(float time)
    {
        yield return new WaitForSeconds(time);
        foreach (Transform t in trees)
        {
            t.localScale = Vector3.one * (sizes[index] /100f);
            Debug.Log(t.localScale.x);
        }
        index++;
        Debug.Log(index);
        if( index >= sizes.Count)
        {
            Debug.Break();
        }
        StartCoroutine(WaitThenChangeSize(growthTime));
    }
    public void AddTree(Transform t)
    {
        trees.Add(t);
    }
}
