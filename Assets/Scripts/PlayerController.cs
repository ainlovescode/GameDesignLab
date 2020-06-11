using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public float roundDuration;
    private float timeElapsed;
    private float timeLeft;

    public Text scoreText; //Store a reference to the UI Text component which will display the number of pickups collected.
    public Text winText; //Store a reference to the UI Text component which will display the number of pickups collected.
    public Text loseText; //Store a reference to the UI Text component which will display the number of pickups collected.
    public Text timerText;
    private int score = 0;              //Integer to store the number of pickups collected so far.    void Start()
    private AudioSource audioSource;

    /* GAME PROCEDURES */
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    /* GAME MECHANICS */

    void Start()
    {
        timeLeft = roundDuration;
        SetScoreText();
        audioSource = GetComponent<AudioSource>();

        winText.enabled = false;
        loseText.enabled = false;


    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        GetComponent<Rigidbody2D>().AddForce(movement * speed);

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Time.timeScale = 0f;
            loseText.enabled = true;
        }
        else
        {

            timerText.text = "Time left: " + ((int)timeLeft).ToString();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            audioSource.Play();
            score += 1;
            other.gameObject.SetActive(false);
            SetScoreText();

            /*
            if (score == 5)
            {
                Time.timeScale = 0f;
                winText.enabled = true;
            }*/
        }

    }




}
