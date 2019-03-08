using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private int numberOfObject1;
    [SerializeField] private int numberOfObject2;
    [SerializeField] private Texture2D myTexture;
    private Color[] myColors;
    public List<Color> result;
    private Terrain myTerrain;
    private TerrainData myTerrainData;
    private List<Vector3> takenCoordinates = new List<Vector3>();

    public bool IsSameColor(Color c1, Color c2)
    {   // check if c1 and c2 has similar color
        //basicColorHueValue: [0°:Red, 30°:Orange, 60°:Yellow, 90°:Chartreuse green, 120°:Green, 150°:Spring green, 180°:Cyan, 210°:Azure, 240°:Blue, 270°:Violet, 300°:Magenta, 330°:Rose]
        //Color.RGBTOHSV return a number from 0-1. It is the hue value(a degree) of the color divides by 360 degree
        
        Color.RGBToHSV(c1, out float H1, out float S1, out float V1);
        Color.RGBToHSV(c2, out float H2, out float S2, out float V2);

        float colorStep = 30f / 360f; //from the List basicColorHueValue above, you can see that every 30 degree, it shifts to another major color
        if (Math.Floor(H1 / colorStep) != Math.Floor(H2 / colorStep))
        {
            return false;
        }
        return true;
    }
    public bool Find(Color c, List<Color> colors)
    {
        // Find if Color s is in the colors list
        foreach(Color color in colors)
        {
            if(IsSameColor(c, color))
            {
                return true;
            }
        }
        return false;
    }
    public List<Color> GetColorList(Color[] allColors)
    {
        result = new List<Color>();

        foreach(Color color in allColors)
        {
           if(!Find(color, result))
            {
                result.Add(color);
            }
        }
        return result;
    }

    public GameObject AllocateObject(GameObject prefab, Color c)
    {
        //x, z are the coordinates of the top left corner of myTerrain
        float x = myTerrain.GetPosition().x;
        float z = myTerrain.GetPosition().z;
        float width = myTerrainData.size.x; //width of myTerrain
        float length = myTerrainData.size.z;  //length of myTerrain
        width = 2048;
        length = 2048;
        Debug.Log(width);

        for (int i = 0; i < width*length; i++)
        {
            float sampleX = UnityEngine.Random.Range(x, x + width); //x coordinates of my random sample point
            float sampleZ = UnityEngine.Random.Range(z, z + length);
            float sampleY = myTerrainData.GetHeight((int)(sampleX), (int)(sampleZ));
           
            Color samplePointColor = myTexture.GetPixel((int)(sampleX), (int)(sampleZ));
            Vector3 samplePoint = new Vector3(sampleX, sampleY, sampleZ);
            float realHeight = myTerrain.SampleHeight(samplePoint);
            samplePoint.y = realHeight;
            if (IsSameColor(c, samplePointColor) && takenCoordinates.IndexOf(samplePoint) == -1)
            {
                takenCoordinates.Add(samplePoint);
                return GameObject.Instantiate(prefab, samplePoint, Quaternion.identity);
                
            
            }
           
        }
        return null;
    }

    public void AllocateObjects(GameObject prefab, Color c, int numberOfObjects)
    {
        for(int i = 0; i < numberOfObjects; i++)
        {
            AllocateObject(prefab, c);
        }
    }
    
    void Start()
    {
        myTerrain = Terrain.activeTerrain;
        myTerrainData = Terrain.activeTerrain.terrainData;

        //GetPixels get an Color[] of the Color of all Pixels in the Texture.
        //myTexture is a public property. When run, assign your png to myTexture by using the inspector
        myColors = myTexture.GetPixels();
        List<Color> result = GetColorList(myColors);
        
        //This loop is for debugging, to print the hue of the list of color I have from GetColorList
        foreach(Color c in result)
        {
            Color.RGBToHSV(c, out float H1, out float S1, out float V1);
            Debug.Log(H1);
        }
        Color g = Color.green;
        Color.RGBToHSV(result[2], out float H2, out float S2, out float V2);
        AllocateObjects(object1, g, numberOfObject1);
        AllocateObjects(object2, result[1], numberOfObject2);
    }
}