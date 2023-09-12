using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    //---------------Top Left Kill Count Text Refrences-----------//
    [SerializeField] private TextMeshProUGUI kill_Text;
    int killCount = 0;

    //---------------Win or Over Refrences-----------//
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI Totalkill_Text;
    int totalKillCount;
    [SerializeField] private TextMeshProUGUI TotalEnemiestext;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        killCount=0;
        kill_Text.text = "Kills: " + killCount.ToString();
        panel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnManager.allenemiesDeployed)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");  //finding if all the enemies are dead or not

            if(enemies.Length == 0)
            {//if they are dead then show panel and setting the timscale to 0
                ShowPanel();
                Time.timeScale = 0f;

                Debug.Log("Showing panel");
            }
        }
        if(PlayerController.PlayerDefeated) //same as if player is defeated or lost
        {
            ShowPanel();
            Time.timeScale = 0f;
            PlayerController.PlayerDefeated = false;
        }
    }
    public void AddKill()
    {
        killCount++;
        kill_Text.text = "Kills: " + killCount.ToString();
    }
    public void ShowPanel()
    {
        panel.gameObject.SetActive(true);
        totalKillCount = killCount;
        Totalkill_Text.text = "TotalKills: " + totalKillCount.ToString();
        TotalEnemiestext.text= "Total Enemies: " + SpawnManager.numberofEnemies.ToString();

    }

    public void ReplayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }    
}
