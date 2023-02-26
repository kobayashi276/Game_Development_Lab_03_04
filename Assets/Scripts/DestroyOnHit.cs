using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.tag=="Range" || other.tag=="Rock"){
            return;
        }
        Instantiate(explosion,transform.position,transform.rotation);
        if(other.tag=="Player"){
            Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
        }
        // GetComponent<AudioSource>().Play();
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
