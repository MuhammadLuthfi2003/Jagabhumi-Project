using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private int lifeCount = 5;
    [SerializeField]private Text lifeAmount;
    [SerializeField] private AudioSource deathSound;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Trap")){
            lifeCount--;
            lifeAmount.text = "Life: " + lifeCount;
            anim.SetTrigger("damaged");

            if(lifeCount == 0){    
                Die();
            }
        }
    }

    private void Die(){
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        deathSound.Play();
    }

    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
