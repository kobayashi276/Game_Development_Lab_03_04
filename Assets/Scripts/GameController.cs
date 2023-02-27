using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;
    public GameObject rock;
    public int amount;
    public float time;
    public float deplayRespawn;
    public float deplayWave;
    private int score;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI gameoverUI;
    public TextMeshProUGUI restartUI;
    private bool gameover;
    private bool restart;
    // Start is called before the first frame update
    IEnumerator Start()
    {

        score = 0;

        gameoverUI.text = "";
        restartUI.text = "";
        gameover = false;
        yield return new WaitForSeconds(4);
        scoreUI.text = "Score: 0";
        StartCoroutine(Waves());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && restart){
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator Waves(){
        while (true){
            yield return new WaitForSeconds(time);
            for (int i=1;i<=amount;i++){
                Instantiate(rock, new Vector3(Random.Range(-xMinMax,xMinMax),0,zMin), Quaternion.identity);
                yield return new WaitForSeconds(deplayRespawn);
            }
            if(gameover){
                restart = true;
                restartUI.text = "Press 'S' to restart";
                break;
            }
            yield return new WaitForSeconds(deplayWave);
        }
 
            
    }

    public void addScore(int s){
        score+=s;
        scoreUI.text="Score: " + score.ToString();
    }

    public void gameOver(){
        gameoverUI.text = "Game over";
        gameover = true;
    }

}
