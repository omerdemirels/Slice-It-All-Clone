using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody playerRb;
   


    GameManager gameManager;

    public GameManager GameManager { get { return gameManager;} }



    void Start()
    {
        if(GetComponent<Rigidbody>() != null)
        {
            playerRb = GetComponent<Rigidbody>();
            playerRb.isKinematic = true;

        }
        if (FindObjectOfType<GameManager>() != null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            gameManager.GameOverPanel();
        }
      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();

    }


    /// <summary>
    /// Karakter hareket mekanikleri
    /// </summary>
    void Move()
    {
        if (playerRb.velocity.y < 0 && transform.rotation.eulerAngles.magnitude >= 254 && transform.rotation.eulerAngles.magnitude <= 269 && transform.position.y <= 6)
        {
            playerRb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        if (transform.localPosition.y >= 2.61f)
        {
            transform.GetChild(0).GetComponent<Knife>().stop = true;

        }
        if (Input.GetKeyDown(KeyCode.Space) && !gameManager.gameOver)
        {
            playerRb.isKinematic = false;
            playerRb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            if (transform.position.y <= 100)
            {
                playerRb.AddForce(Vector3.up * 9f, ForceMode.Impulse);

            }



            playerRb.AddForce(Vector3.forward * 2f, ForceMode.Impulse);
            if (playerRb.angularVelocity.x <= 5)
            {
                playerRb.AddTorque(Vector3.right * 10f, ForceMode.Impulse);
            }
            

        }

    }
    

}
