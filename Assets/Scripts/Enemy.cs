using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float forceImpact;
    private GameManager manager;
    public static bool enemykilled = false;

    //---------------For Adding Force Against Player-----------//
    private GameObject player;
    private Rigidbody rb;
    [SerializeField] private float speed;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (player != null)
        {
            Vector3 lookDirection = (player.transform.position - rb.transform.position).normalized;
            rb.AddForce(lookDirection * speed);
        }
        
    }
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            manager.AddKill();
            enemykilled = true;
            Destroy(gameObject);
            Debug.Log("Kill added");
        }
    }
}
