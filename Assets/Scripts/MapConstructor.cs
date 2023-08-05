using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConstructor : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject pillar;
    public GameObject winPillar;
    public int pillarCount = 12;

    private int initialObject = 2;
    private float Length = 0;

    void Awake()
    {
        for(int i = 0; i < pillarCount; i++)
        {
            CreatePillar();
        }
        CreateWinPillar();
    }
    private void CreatePillar()
    {
        float objLength = (int)(Random.Range(4, 10))/2;
        
        GameObject obj = Instantiate(pillar, new Vector3(0, -1.7f, 0), Quaternion.identity);
        ConfigObject(obj, new Vector3(1, 4, objLength), new Vector3(0, -1.7f, Length - objLength/2));
        CreateObjects(new Vector3(0, 0.3f, Length - objLength/2));

        Length -= objLength + Random.Range(1, 3);
    }
    private void ConfigObject(GameObject obj, Vector3 scale, Vector3 position)
    {
        obj.transform.SetParent(transform);
        obj.transform.localScale = scale;
        obj.transform.position = position;
    }
    private void CreateObjects(Vector3 position)
    {
        if(initialObject > 0)
        {
            initialObject--;
            return;
        }
        Instantiate(objects[Random.Range(0, objects.Length)], position, Quaternion.identity);
    }
    private void CreateWinPillar()
    {
        GameObject obj = Instantiate(winPillar, new Vector3(0, -1.7f, 0), Quaternion.identity);
        ConfigObject(obj, new Vector3(1, 1, 1), new Vector3(0, 3f, Length - 2f));
    }
}
