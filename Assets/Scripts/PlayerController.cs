using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector3 minScreen;
    private Vector3 maxScreen;
    // Start is called before the first frame update
    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(new Vector3(0.0f,0.0f,0.0f));
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0.0f,Screen.height));
        Debug.Log(Screen.width.ToString() + " " + Screen.height.ToString());
        Debug.Log(maxScreen.ToString());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        // Vector3 movement = new Vector3(Mathf.Clamp(horAxis,minScreen.x,maxScreen.x), 0.0f, Mathf.Clamp(verAxis,0,maxScreen.z));
        Vector3 movement = new Vector3(horAxis,0.0f,verAxis);
        Debug.Log(horAxis.ToString());
        Debug.Log(verAxis.ToString());
        Debug.Log(movement.ToString());
        
        GetComponent<Rigidbody>().AddForce(movement * speed);
    }
}
