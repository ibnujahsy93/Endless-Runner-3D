using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        SoundManager.Instance.PlaySound2D("Coin");
        MasterLevelInfo.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
