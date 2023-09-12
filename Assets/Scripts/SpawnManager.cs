using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //---------------Prefabs And Its int Value-----------//
    public GameObject[] enemyPrefab;
    int enemienumbers;
    //---------------Random Area To Spawn Values-----------//
    public float minX, maxX;

    //---------------Reference For Other Script(GameManager)-----------//
    public static int numberofEnemies;
    public static bool allenemiesDeployed = false;
    // Start is called before the first frame update
    void Start()
    {
         enemienumbers = Random.Range(4, 7);
        numberofEnemies = enemienumbers;  //did this as a refrence so i can show total number of enemies as text(gamemanager)
         SpawnEnemies();  
    }

    public void SpawnEnemies()
    {      
        for(int i = 0;i < enemienumbers;i++) 
        {
            float  rand = Random.Range(minX, maxX);
            Vector3 randXposition = new Vector3(rand,transform.position.y + 1.653f, transform.position.z);

            GameObject randomEnemyPrefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
            Instantiate(randomEnemyPrefab,randXposition, Quaternion.identity);

            if(i == enemienumbers-1)  //if all the enemies are deployed 
            {
                allenemiesDeployed=true;  //then setting the bool to true so it can start calculation if all the enemies are dead or not(Gamemanager)
                Debug.Log(allenemiesDeployed);
            }
        }
    }
}
