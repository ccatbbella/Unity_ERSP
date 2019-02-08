using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//generate 10 resprouters and seeders at random location of terrain
public class TreeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject resprouterPrefab;
    [SerializeField] private GameObject seederPrefab;
    [SerializeField] private Size rs;
    [SerializeField] private Size ss;
    [SerializeField] private int numberOfResprouters = 15;
    [SerializeField] private int numberOfSeeder = 15;
    /*
    public void AddTree(Transform newTree)
    {
        newTree.localScale = Vector3.one * 5f;  
    }
    */
        // Start is called before the first frame update
    void Awake()
    {
        GameObject thisTree;
        for (int i = 0; i< numberOfResprouters;i++)
        {
            thisTree = GenerateTree(resprouterPrefab);
            rs.AddTree(thisTree.transform);
        }
        for (int i = 0; i < numberOfSeeder; i++)
        {
            thisTree = GenerateTree(seederPrefab);
            ss.AddTree(thisTree.transform);
        }
    }
    private GameObject GenerateTree(GameObject treePrefab)
    {
        Vector3 p = new Vector3(Random.Range(100f, 1000f), 0, Random.Range(100f, 1000f));  //p decide the area trees are in
        return GameObject.Instantiate(treePrefab, p, Quaternion.identity);
    }
    
}
