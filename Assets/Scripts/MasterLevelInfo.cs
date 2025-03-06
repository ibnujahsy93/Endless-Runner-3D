using UnityEngine;

public class MasterLevelInfo : MonoBehaviour
{
    public static int coinCount = 0;
    [SerializeField] GameObject player;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject coinDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinCount = 0;
        if (PlayerPrefs.GetInt("ChoosenChar",0) == 1)
        {
            player.SetActive(true);
        } else if (PlayerPrefs.GetInt("ChoosenChar",0) == 2)
        {
            player1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
    }
}
