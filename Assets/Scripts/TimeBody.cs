using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePoint
{
    public Vector3 position;
    public Quaternion rotation;

    public TimePoint(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}

public class TimeBody : MonoBehaviour
{

    public bool isRewinding = false;
    private List<TimePoint> recordedPos;
    private Rigidbody rigid;
    //---
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        recordedPos = new List<TimePoint>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            isRewinding = true;
        }else if(Input.GetKeyUp(KeyCode.T))
        {
            isRewinding = false;
        }

       
    }

    private void FixedUpdate()
    {
        if(!isRewinding)
        {
            Record();
        }else if(isRewinding)
        {
            Rewind();
        }
    }

    private void Record()
    {
        rigid.isKinematic = false;
        recordedPos.Insert(0, new TimePoint(transform.position, transform.rotation));
    }

    private void Rewind()
    {
        if(recordedPos.Count - 1 > 1)
        {
            rigid.isKinematic = true;
            transform.position = recordedPos[0].position;
            transform.rotation = recordedPos[0].rotation;
            recordedPos.RemoveAt(0);
        }
        
    }

}
