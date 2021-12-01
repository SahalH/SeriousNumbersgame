using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public float fullHealth;
    public GameObject deathFX;
    public AudioClip playerHurt;
    public restartGame theGameManager;


    float currentHealth;

    playerController controlMovement;

    AudioSource playerAS;

    //HUD variables
    public Slider healthSlider;
    public Text gameOverScreen;
    public Text winGameScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        controlMovement = GetComponent<playerController>();

        //HUD Initilization
        
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        

        playerAS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        playerAS.clip = playerHurt;
        playerAS.Play();

      

        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth (float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        healthSlider.value = currentHealth;
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);

        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        theGameManager.restartTheGame();
    }

    public void winGame()
    {
        Destroy(gameObject);
        theGameManager.restartTheGame();
        Animator winGameAnimator = winGameScreen.GetComponent<Animator>();
        winGameAnimator.SetTrigger("gameOver");
    }
}
