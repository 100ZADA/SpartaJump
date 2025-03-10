using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float distance;
    public float turningPoint;
    public float moveSpeed;

    float initPositionX;
    float initPositionY;
    float initPositionZ;

    bool turnSwitch;

    private void Awake()
    {
        if(gameObject.name == "XMoveObject")            //  X축 이동
        {
            initPositionX = transform.position.x;
        }

        if(gameObject.name == "YMoveObject")            // Y축 이동
        {
            initPositionY = transform.position.y;
        }

        if (gameObject.name == "ZMoveObject")            //  Z축 이동
        {
            initPositionZ = transform.position.x;
        }
    }

    // X축 이동 조정
    void PositionX()
    {
        float currentPositionX = transform.position.x;

        if(currentPositionX >= initPositionX)
        {
            turnSwitch = false;
        }
        else if(currentPositionX <= turningPoint)
        {
            turnSwitch = true;
        }

        if (turnSwitch)
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
        }
    }

    // Y축 이동 조정
    void PositionY()
    {
        float currentPositionY = transform.position.y;

        if(currentPositionY >= initPositionY)
        {
            turnSwitch = false;
        }
        else if(currentPositionY <= turningPoint)
        {
            turnSwitch = true;
        }

        if(turnSwitch)
        {
            transform.position = transform.position + new Vector3(0,1,0) * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime;
        }
    }

    // Z축 이동 조정
    void PositionZ()
    {
        float currentPositionZ = transform.position.z;

        if (currentPositionZ >= initPositionZ)
        {
            turnSwitch = false;
        }
        else if (currentPositionZ <= turningPoint)
        {
            turnSwitch = true;
        }

        if (turnSwitch)
        {
            transform.position = transform.position + new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime;
        }
    }

    void Update()
    {
        if(gameObject.name == "YMoveObject")
        {
            PositionY();
        }

        if (gameObject.name == "XMoveObject")
        {
            PositionX();
        }

        if (gameObject.name == "ZMoveObject")
        {
            PositionZ();
        }
    }
}
