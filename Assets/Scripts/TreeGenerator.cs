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
    private color rc;
    private color sc;

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
        
        Vector3 p = new Vector3(Random.Range(0f, 500f), 0, Random.Range(0f, 500f));  //p decide the area trees are in
        return GameObject.Instantiate(treePrefab, p, Quaternion.identity);
        
        

    }
    
}
