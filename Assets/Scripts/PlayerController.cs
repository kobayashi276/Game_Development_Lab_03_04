using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Limit{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector3 minScreen;
    private Vector3 maxScreen;
    public float tilt;
    public Limit limit;

    public GameObject quad_bullet;
    public Transform bullet;

    public float firerate;
    private float timerate;
    
    // Start is called before the first frame update
    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(new Vector3(0.0f,0.0f,0.0f));
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0.0f,Screen.height));
        Debug.Log(Screen.width.ToString() + " " + Screen.height.ToString());
        Debug.Log(maxScreen.ToString());
    }

    void Update(){
        if (Input.GetKey(KeyCode.Space) && Time.time>timerate){
            timerate = Time.time + firerate;
            Instantiate(quad_bullet,transform.position,bullet.rotation);
            Debug.Log(bullet.position.ToString());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        // Vector3 movement = new Vector3(Mathf.Clamp(horAxis,minScreen.x,maxScreen.x), 0.0f, Mathf.Clamp(verAxis,0,maxScreen.z));
        Vector3 movement = new Vector3(horAxis,0.0f,verAxis);
        Debug.Log(transform.position.x.ToString());
        Debug.Log(transform.position.z.ToString());
        // Debug.Log(movement.ToString());
        
        GetComponent<Rigidbody>().velocity=movement * speed;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,limit.xMin,limit.xMax),0,Mathf.Clamp(transform.position.z,limit.zMin,limit.zMax)
        );
        transform.rotation = Quaternion.Euler(new Vector3(0,0,GetComponent<Rigidbody>().velocity.x * -tilt));
    }
}
