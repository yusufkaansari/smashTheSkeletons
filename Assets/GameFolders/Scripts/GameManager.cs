using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    [SerializeField]
    TextMeshProUGUI killedText, timeCountText;

    float floatTime;

    int killEnemyNumber=0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {        
            Timer();
            DisplayTime(floatTime);
            DisplayKilled();
        }
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void UpdateKillEnemyNumber()
    {
        killEnemyNumber++;
    }
    void Timer()
    {        
        floatTime += Time.deltaTime;
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeCountText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void DisplayKilled()
    {
        killedText.text = "x " + killEnemyNumber;
    }
}
