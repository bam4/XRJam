using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    public GameObject photoScreen;

    public List<GameObject> suspects = new List<GameObject>();
    public List<Sprite> photos = new List<Sprite>();

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
        timer = 48f;
        suspectCount = 0;
        suspects[0].GetComponent<InterrogateSuspect>().IsSecretAgent = true;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = Mathf.Floor(timer / 60) + ":" + (timer % 60);
        if (timer <= 0) {
            timerText.text = "Game Over!";
        }
    }

    public void CorrectHit(GameObject suspect) {
        score++;
        timer += 2;
        StartCoroutine(meshOffTemp(suspect));
        scoreText.text = "Score: " + score;
        suspects[suspectCount].GetComponent<InterrogateSuspect>().IsSecretAgent = false;
        if(suspectCount < suspects.Count - 1){
            suspectCount++;
        } else {
            suspectCount = 0;
        }
        suspects[suspectCount].GetComponent<InterrogateSuspect>().IsSecretAgent = true;
        photoScreen.GetComponent<SpriteRenderer>().sprite = photos[suspectCount];
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
