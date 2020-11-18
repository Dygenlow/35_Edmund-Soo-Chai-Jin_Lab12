using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController35 : MonoBehaviour
{
    public GameObject CoinCollected;
    public float speed;
    public float rotateSpeed;

    private int coinCount;
    private int totalCoin;

    // Start is called before the first frame update
    void Start()
    {
        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        ForwardKey();
        BackKey();
        LeftRotate();
        RightRotate();

        if(coinCount == totalCoin)
        {
            print("You win!");
            SceneManager.LoadScene("WinScene");
        }

        if(transform.position.y <= -5)
        {
            print("You lose");
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinCount++;

            CoinCollected.GetComponent<Text>().text = "Coin Collected: " + coinCount;

            Destroy(other.gameObject);
        }
    }

    private void ForwardKey()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void BackKey()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }

    private void LeftRotate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate (new Vector3(0, Time.deltaTime * -rotateSpeed, 0));
        }

    }

    private void RightRotate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed, 0));
        }
    }
}
