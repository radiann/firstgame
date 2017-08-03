using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRotate : MonoBehaviour {
    public GameObject AroundPoint;
    public GameObject target;
    private Vector2 startPos;
    private Vector2 direction;
    private Vector2 savePos;
    private float touchspeed;
    private float Pow;
    private float Timer;
    private float nomalspeed;
    private bool kansei;
    private bool istouch;
	// Use this for initialization
	void Start () {
        nomalspeed = 50;
        touchspeed = 0f;
        kansei = false;
        istouch = false;
}
	
	// Update is called once per frame
	void Update () {
        Vector3 UPAxis = AroundPoint.transform.TransformDirection(Vector3.up);
        Vector3 DOWNAxis = AroundPoint.transform.TransformDirection(Vector3.down);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    touchspeed = 1;
                    GetComponent<Rigidbody>().Sleep();
                    break;
                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    if (direction.x < 0)
                    {
                        transform.RotateAround(target.transform.position, Vector3.up, nomalspeed*touchspeed * Time.deltaTime);
                    }
                    else if (direction.x > 0)
                    {
                        transform.RotateAround(target.transform.position, Vector3.down, nomalspeed *touchspeed* Time.deltaTime);
                    }
                    break;                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    GetComponent<Rigidbody>().AddTorque(touch.deltaPosition.x, touch.deltaPosition.y, 0, ForceMode.Impulse);
                    break;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            savePos = Input.mousePosition;
            touchspeed = 1;
            Timer = 0;
            kansei = false;
            istouch = true;
            direction = Vector2.zero;
        }
        if (Input.GetMouseButton(0))
        {
            Timer += Time.deltaTime;
                Vector2 movepos = Input.mousePosition;
                direction = movepos - startPos;
                if (Timer >= 0.1f)
                {
                    savePos = startPos;
                    startPos = Input.mousePosition;
                    Timer = 0;
                }
            if (startPos.x > savePos.x +15 || startPos.x < savePos.x -15)
            {
                touchspeed = 3;
                if (startPos.x > savePos.x + 30 || startPos.x < savePos.x - 30)
                {
                    touchspeed = 6;
                    if (startPos.x > savePos.x + 45 || startPos.x < savePos.x - 45)
                    {
                        touchspeed = 9;
                        if (startPos.x > savePos.x + 60 || startPos.x < savePos.x - 60)
                        {
                            touchspeed = 12;
                            if (startPos.x > savePos.x + 75 || startPos.x < savePos.x - 75)
                            {
                                touchspeed = 15;
                            }
                        }
                    }
                }
            }
            else
            {
                touchspeed = 1;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Timer = 0;
            istouch = false;
        }
        if (istouch||kansei)
        {
            if (direction.x < 0)
            {
                this.transform.RotateAround(target.transform.position, UPAxis, nomalspeed * touchspeed * Time.deltaTime);
            }
            else if (direction.x > 0)
            {
                this.transform.RotateAround(target.transform.position, DOWNAxis, nomalspeed * touchspeed * Time.deltaTime);
            }
        }
        Debug.Log("speed"+touchspeed);
        if (touchspeed > 1)
        {
            kansei = true;
            touchspeed = Mathf.Lerp(touchspeed, 0, 0.1f);
        }
        else
        {
            kansei = false;
        }
    }
    private void LateUpdate()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
