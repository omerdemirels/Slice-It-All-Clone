using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    // Start is called before the first frame update
    Transform cameraPos;
    private Transform playerPos;
    [SerializeField] float camSpeed = 5f;
    public Vector3 offSet;
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        offSet = CameraDistance(transform.position, playerPos);
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        MoveTheCamera();
    }
    private void MoveTheCamera()
    { //lerp metodu sayesinde yumu�ak kemra takibi yapar.
      //fixedupdate t�m fiziksel i�lemler bittikten sonra �al���r
        if (playerPos != null)
        {
            Vector3 mesafe = playerPos.position + offSet;
            transform.position = Vector3.Lerp(transform.position, mesafe, camSpeed * Time.deltaTime);

        }
        else
        {
            offSet = CameraDistance(transform.position, GameObject.FindGameObjectWithTag("Player").transform);
        }

    }
    public Vector3 CameraDistance(Vector3 cam, Transform newTarget)
    {
        return cam - newTarget.position;
    }
}