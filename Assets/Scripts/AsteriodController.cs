using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * speed;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
    // }
}
