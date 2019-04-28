using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    public Image photoScreen;

    public List<GameObject> suspects = new List<GameObject>();
    public List<Sprite> photos = new List<Sprite>();

    bool gameStarted;
    bool twoPlayer;

    float timer;
    int score;
    int suspectCount;

    public Text timerText;
    public Text scoreText;
    
    void Awake()
    {
        if (gameManager == null){
            gameManager = this;
        } else {
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start()
    {
        gameStarted = false;
        suspects[0].GetComponent<InterrogateSuspect>().IsSecretAgent = true;
    }

    public void StartGame(int numplayers)
    {
        gameStarted = true;
        timer = 48f;
        suspectCount = 0;
        score = 0;
        suspects[0].GetComponent<InterrogateSuspect>().IsSecretAgent = true;
        if (numplayers == 2) {
        // suspects[0].GetComponent<CharacterController>().enabled = true;
        // suspects[0].GetComponent<FirstPersonController>().enabled = true;
        //suspects[0].GetComponentInChildren<Camera>().enabled = true;
        }
        photoScreen.sprite = photos[0];
        //photoScreen.GetComponent<SpriteRenderer>().sprite = photos[0];
    }

    void Update()
    {
        if (gameStarted)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.Floor(timer / 60) + ":" + (timer % 60);
            if (timer <= 0)
            {
                timerText.text = "Game Over!";
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartGame(1);
                print(gameStarted);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartGame(2);
            }
        }
    }

    public void CorrectHit(GameObject suspect) {
        score++;
        timer += 2;
        StartCoroutine(meshOffTemp(suspect));
        scoreText.text = "Score: " + score;
        suspects[suspectCount].GetComponent<InterrogateSuspect>().IsSecretAgent = false;
        if (twoPlayer)
        {
            // suspect.GetComponent<CharacterController>().enabled = false;
            // suspect.GetComponent<FirstPersonController>().enabled = false;
            // suspect.GetComponentInChildren<Camera>().enabled = false;
        }
        if (suspectCount < suspects.Count - 1){
            suspectCount++;
        } else {
            suspectCount = 0;
        }
        // suspects[suspectCount].GetComponent<InterrogateSuspect>().IsSecretAgent = true;
        // suspects[suspectCount].GetComponent<CharacterController>().enabled = true;
        // suspects[suspectCount].GetComponent<FirstPersonController>().enabled = true;
        // suspects[suspectCount].GetComponentInChildren<Camera>().enabled = true;
        //photoScreen.GetComponent<SpriteRenderer>().sprite = photos[suspectCount];
        photoScreen.sprite = photos[suspectCount];
    }

    public void IncorrectHit() {
        timer -= 4;
    }

    IEnumerator meshOffTemp(GameObject suspect)
    {
        suspect.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        suspect.GetComponent<MeshRenderer>().enabled = true;
        yield return null;
    }

}
