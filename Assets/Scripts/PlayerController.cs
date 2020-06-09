using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text scoreText; //Store a reference to the UI Text component which will display the number of pickups collected.
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
        SetScoreText();
        audioSource = GetComponent<AudioSource>();

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        GetComponent<Rigidbody2D>().AddForce(movement * speed);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            audioSource.Play();
            score += 1;
            other.gameObject.SetActive(false);
            SetScoreText();
        }

    }




}
