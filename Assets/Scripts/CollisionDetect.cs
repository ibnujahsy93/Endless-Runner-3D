using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerAnim;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject playerAnim1;
    
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject mainCam1;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject GameOverMenu;

    [SerializeField] GameObject TextScore;
    [SerializeField] GameObject TextHighScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextHighScore.GetComponent<TMPro.TMP_Text>().text = "" + PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CollisionEnd());
    }

    IEnumerator CollisionEnd()
    {
        if (MasterLevelInfo.coinCount > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore",MasterLevelInfo.coinCount);
        }
        SoundManager.Instance.PlaySound2D("CollisionStumble");
        if (PlayerPrefs.GetInt("ChoosenChar",0) == 1)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            playerAnim.GetComponent<Animator>().Play("Stumble Backwards");
            mainCam.GetComponent<Animator>().Play("CollisionCam");
        } else if (PlayerPrefs.GetInt("ChoosenChar",0) == 2)
        {
            player1.GetComponent<PlayerMovement>().enabled = false;
            playerAnim1.GetComponent<Animator>().Play("Stumble Backwards");
            mainCam1.GetComponent<Animator>().Play("CollisionCam");
        }
        
        TextScore.GetComponent<TMPro.TMP_Text>().text = "" + MasterLevelInfo.coinCount;
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        
        GameOverMenu.SetActive(true);
        Time.timeScale = 0;
        

    }
}
