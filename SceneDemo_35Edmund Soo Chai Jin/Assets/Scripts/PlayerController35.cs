using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController35 : MonoBehaviour
{
    public Text scoreText;

    public float speed = 5.0f;
    public float score = 10.0f;
    int PowerUpLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ForwardKey();
        BackKey();
        LeftKey();
        RightKey();

        PowerUpLeft = GameObject.FindGameObjectsWithTag("PowerUp").Length;

        print("PowerUps Left: " + PowerUpLeft);

        scoreText.GetComponent<Text>().text = "Game Score: " + score;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            score--;

            if(score <= 0)
            {
                score = 0.0f;
            }
        }

        if(score == 0)
        {
            SceneManager.LoadScene("EndScene");
        }

        if(PowerUpLeft == 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUp")
        {
            score++;

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    private void ForwardKey()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void BackKey()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }

    private void LeftKey()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    private void RightKey()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
