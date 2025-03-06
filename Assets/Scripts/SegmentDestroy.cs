using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SegmentDestroy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject segment;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider player)
    {
        StartCoroutine(DestSeg());
    }

    IEnumerator DestSeg()
    {
        
        yield return new WaitForSeconds(15);
        Destroy(segment);

    }
}
