using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : MonoBehaviour
{
     public ScoreManager scoreManager;
    public bool stop;

    private void Start()
    {
        stop = true;
        scoreManager = FindObjectOfType<ScoreManager>();

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Plane") && stop)
        {
            transform.parent.GetComponent<Rigidbody>().isKinematic = true;
            stop = false;

        }
        if (other.CompareTag("Pencil"))
        {
            Force(other, 5f);
            

        }
        if (other.CompareTag("Lego"))
        {
            if (other.transform.position.x>0)
            {
                Force(other, 5f);

            }
            else if (other.transform.position.x < 0)
            {
                Force(other, -5f);
            }

        }
        if (other.CompareTag("hollow"))
        {
            if (other.transform.localPosition.x > 0)
            {
                Force(other, 5f);

            }
            else if (other.transform.localPosition.x <= 0)
            {
                Force(other, -5f);
            }
        }
        Finish(other);
     
    }
    void Force(Collider other,float Force)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {

            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(Vector3.right * Force, ForceMode.Impulse);
            scoreManager.ScoreUpdate(5);


        }
    }

    /// <summary>
    /// Oyun bitimindeki küpleri üstündeki textin içindeki katsayý ile puan atmasý yapar ve ardýndan level atlatýr.
    /// </summary>
    /// <param name="other"></param>
    void Finish(Collider other)
    {
        if (other.GetComponentInChildren<TextMesh>() != null)
        {
            string text = other.GetComponentInChildren<TextMesh>().text;
            transform.parent.GetComponent<Rigidbody>().isKinematic = true;
            int scorePump = int.Parse(text[1].ToString());
            GetComponentInChildren<Knife>().scoreManager.ScoreUpdate(10 * scorePump);
           PlayerControl playerControl= transform.parent.GetComponent<PlayerControl>();
           playerControl.GameManager.NextLevelPanel();
           playerControl.GameManager.gameOver = true;// next level metodu gelecek 1 level diye game over geldi.
        }
    }

}
