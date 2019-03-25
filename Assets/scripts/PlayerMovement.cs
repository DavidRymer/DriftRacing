using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    private new PhotonView _photonView;
    public Camera cam;
    private Camera _overheadCam;
    private Camera _firstPersonCam;
    private bool fpEnabled = true;
    [System.NonSerialized] public int position;


    // Start is called before the first frame update
    void Start()
    {
        _photonView = gameObject.GetPhotonView();
        if (_photonView.IsMine)
        {
            SpawnOverheadCam();
            SpawnFirstPersonCam();
            _overheadCam.enabled = false;
            _firstPersonCam.enabled = true;
        }
    }

    void SpawnOverheadCam()
    {
        var newCam = Instantiate(cam, transform.position, Quaternion.identity);

        newCam.transform.eulerAngles = new Vector3(90, 0, 0);
        newCam.transform.localPosition = new Vector3(0, 80f, 5);

        _overheadCam = newCam;
    }

    void SpawnFirstPersonCam()
    {
        var newCam = Instantiate(cam, transform.position, Quaternion.identity);

        newCam.transform.eulerAngles = new Vector3(0, 0, 0);
        newCam.transform.localPosition = new Vector3(0, 5f, 5);

        _firstPersonCam = newCam;
        _firstPersonCam.transform.SetParent(transform);
    }

    void Update()
    {
        CarControls();
        CameraControls();
    }

    private void CarControls()
    {
        if (_photonView.IsMine)
        {
            _overheadCam.transform.position = new Vector3(transform.position.x, _overheadCam.transform.position.y,
                transform.position.z);
            _firstPersonCam.transform.position = new Vector3(transform.position.x, _firstPersonCam.transform.position.y,
                transform.position.z);
            var direction = transform.Find("Nose").position - transform.position;
            direction.y = 0;

            if (Input.GetKey(KeyCode.W))
            {
                transform.GetComponent<Rigidbody>().AddForce(direction * 10);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.GetComponent<Rigidbody>().AddForce(direction * -10);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 1, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -1, 0);
            }
        }

        if (transform.eulerAngles.z > 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        if (transform.eulerAngles.x > 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }

    private void CameraControls()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _photonView.IsMine)
        {
            if (fpEnabled)
            {
                _overheadCam.enabled = true;
                _firstPersonCam.enabled = false;
                fpEnabled = false;
            }
            else
            {
                _overheadCam.enabled = false;
                _firstPersonCam.enabled = true;
                fpEnabled = true;
            }
        }
    }

    void ChangeToOverHead()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.transform.CompareTag("fllor"))
        {
            Debug.Log("been hit");
        }
    }
}