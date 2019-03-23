using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    private new PhotonView _photonView;
    public Camera cam;
    private Camera _thisCam;

    // Start is called before the first frame update
    void Start()
    {
        _photonView = gameObject.GetPhotonView();
        if (_photonView.IsMine)
        {
            var newCam = Instantiate(cam, transform.position, Quaternion.identity);
            
            newCam.transform.eulerAngles = new Vector3(90,0,0);
            newCam.transform.localPosition = new Vector3(0, 400f, 0);

            _thisCam = newCam;
        }
    }

    void Update()
    {
        if (_photonView.IsMine)
        {
            _thisCam.transform.position = new Vector3(transform.position.x, _thisCam.transform.position.y, transform.position.z);
            if (Input.GetKey(KeyCode.W))
            {
                transform.GetComponent<Rigidbody>().AddForce((transform.Find("Nose").position - transform.position) * 30);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.GetComponent<Rigidbody>().AddForce((transform.Find("Nose").position - transform.position) * -30);
            }
            if (Input.GetKey(KeyCode.D))
            {
               transform.Rotate(0,1,0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0,-1,0);
            }
        
        }

        if (transform.eulerAngles.z > 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.transform.CompareTag("fllor"))
        {
            
            Debug.Log("been hit");
        }
    }
}