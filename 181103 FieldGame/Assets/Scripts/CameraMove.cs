using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float speedH = 2.0f;  // 세로 회전속도(감도)
    public float speedV = 2.0f; 

    public float yaw = 0.0f;
    public float pitch = 0.0f;
    public bool isYaw = true;
    public bool isPitch = true;
    public float pitchData = 0.0f;
    private float visibleYaw = 0.0f;
    private float visiblePitch = 0.0f;
    bool isCamera = true;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate()
    {
        // 가로회전
        yaw += speedH * Input.GetAxis("Mouse X");
        // 세로회전
        pitch -= speedV * Input.GetAxis("Mouse Y");

        //if (pitch > pitchData)
        //    isPitch = true;

        //if (isYaw)
        //    visibleYaw = yaw;
        //if (isPitch)
        //    visiblePitch = pitch;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 5f)
            && hit.transform.tag != "Player")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) *
          5f, Color.red, 100f);
            //Debug.Log("Did Hit");

            transform.GetChild(0).transform.position = hit.point;
            isCamera = false;

        }


        if (!isCamera && !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 5f)
            )
        {
            Vector3 child = transform.GetChild(0).position;
            Vector3 me = transform.position;
            if (Vector3.Distance(child, me) < 5f)
            {
                //Debug.Log("카메라 정상작동");

                Vector3 heading = child - me;
                float distance = heading.magnitude;
                Vector3 direction = heading / distance;

                Ray cameraRay = new Ray(transform.position, direction);

                transform.GetChild(0).position = me + direction * 5f;
            }
        }
    }
}
