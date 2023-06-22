using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text winLoseText;
    public Image winLoseBG;
    public Text scoreText;
    public Text healthText;
    public float speed = 5f;
    private int score = 0;
    public int health = 5;

    private Rigidbody playerRigidBody;
    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        playerRigidBody.velocity = movement * speed;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            ///Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
            //Debug.Log("Health: " + health);

            if (health <= 0)
            {
                GameOver();
            }
        }
        else if (other.CompareTag("Goal"))
        {
            ///Debug.Log("You win!");
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;
            winLoseBG.color = Color.green;

            StartCoroutine(LoadScene(3)); 
        }
    }
    private void Update()
    {
        if (health <=0 )
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        winLoseText.text = "Game Over!";
        winLoseText.color = Color.white;
        winLoseBG.color = Color.red;
        //Debug.Log("Game Over!");
        score = 0;
        health = 5;

        SetScoreText();
        SetHealthText();

        StartCoroutine(LoadScene(3));
    }

    public void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    private IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
