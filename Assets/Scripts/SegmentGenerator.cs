using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;
   

    [SerializeField] int zPos = 50;
    [SerializeField] bool spawnSegment = false;
    [SerializeField] int segmentNum;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnSegment == false)
        {
            spawnSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, 3);
        Instantiate(segment[segmentNum], new Vector3(0,0,zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(3);
        spawnSegment = false;

    }
}
