using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Size : MonoBehaviour
{
    private float size;
    private int index;
    [SerializeField] private float growthTime = 1;
    [SerializeField] private string fileName;
    private float[] sizes;
    private List<Transform> trees = new List<Transform>(0);
   

    private void Start()
    {
        string[] sSizes = GameFunctions.ReadArray(fileName);
        sizes = new float[sSizes.Length];
        
        for(int i = 0; i < sSizes.Length; i++)
        {
            sizes[i] = float.Parse(sSizes[i]);
        }

        index = 0;
        StartCoroutine(WaitThenChangeSize(0));
    }

    IEnumerator WaitThenChangeSize(float time)
    {
        yield return new WaitForSeconds(time);
        foreach (Transform t in trees)
        {
            t.localScale = Vector3.one * sizes[index];
        }
        
        index++;
        if (index<sizes.Length)
        {
            StartCoroutine(WaitThenChangeSize(growthTime));
        }

    }
    public void AddTree(Transform t)
    {
        trees.Add(t);
    }
}
