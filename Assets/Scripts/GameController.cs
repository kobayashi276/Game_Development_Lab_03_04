using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;
    public GameObject rock;
    public int amount;
    public float time;
    public float deplayRespawn;
    public float deplayWave;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Waves(){
        while (true){
            yield return new WaitForSeconds(time);
            for (int i=1;i<=amount;i++){
                Instantiate(rock, new Vector3(Random.Range(-xMinMax,xMinMax),0,zMin), Quaternion.identity);
                yield return new WaitForSeconds(deplayRespawn);
            }
            yield return new WaitForSeconds(deplayWave);
        }
 
            
    }
}
