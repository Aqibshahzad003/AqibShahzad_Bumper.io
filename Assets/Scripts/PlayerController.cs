using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]  private float forceImpact;

    [Header("PlayerMovementSettings")]
    public float speed;
    public float rotationSpeed;
    private Rigidbody rb;

    private Vector3 originalScale;

    public static bool PlayerDefeated = false;

    //---------------Materials For Player-----------//
    [Header("Materials")]
    [SerializeField] private Material GreenMaterial;
    [SerializeField] private Material YellowMaterial;
    [SerializeField] private Material OrangeMaterial;
    [SerializeField] private Material PurpleMaterial;
    int colors;
    // Start is called before the first frame update
    void Start()
    {
        //Getting the component of rigidbody
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;
    }
    void Update()
    {
        //Moving Inputs and system
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 Movement = new Vector3(horizontalInput, 0, verticalInput);
        Movement.Normalize();

        transform.Translate(Movement * speed * Time.deltaTime,Space.World);

        //changing shape and material/texture
        if(Enemy.enemykilled)
        {
            Enemy.enemykilled = false;
            ChangeForm();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Rigidbody enemyrb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayVector = (collision.gameObject.transform.position - transform.position);
            enemyrb.AddForce(awayVector * forceImpact,ForceMode.Impulse);  //adding force to the enemy
            Debug.Log("Collided with Enemy");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            PlayerDefeated = true;
            Destroy(gameObject);
        }
    }

    void ChangeForm()
    {
        Renderer playerRenderer = GetComponent<Renderer>();  //accessing the rendeerer component 
        colors++;
        if (colors >= 4) 
        {
            colors = 0;
        }
        switch (colors) 
        {
            case 0:
                playerRenderer.material = GreenMaterial;
                break;
            case 1:
                playerRenderer.material = YellowMaterial;
                break;
            case 2:
                playerRenderer.material = PurpleMaterial;
                break;
            case 3:
                playerRenderer.material = OrangeMaterial;
                break;
        }


        gameObject.transform.localScale = originalScale += new Vector3(.5f, .5f, .5f); //scale changing
        Renderer playerRend = gameObject.GetComponent<Renderer>();
      
        Debug.Log("Form Changed");
        Debug.Log("Current material of the player is " +playerRend.material.name);
    }
}
