using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    void Start(){
        GameObject Controller = GameObject.FindWithTag("GameController");
        if (Controller!=null){
            gameController = Controller.GetComponent<GameController>();
        }
        if (gameController==null){
            Debug.Log("Can't find GameController.cs");
        }
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.tag=="Range" || other.tag=="Rock"){
            return;
        }
        Instantiate(explosion,transform.position,transform.rotation);
        if(other.tag=="Player"){
            Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
            gameController.gameOver();
        }
        else{
            gameController.addScore(1);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        // gameObject.GetComponent<AudioSource>().Play();

    }
}
