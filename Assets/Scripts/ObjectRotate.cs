using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField]float xSpeed, ySpeed, zSpeed;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

            transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
        
        
    
    }
}
