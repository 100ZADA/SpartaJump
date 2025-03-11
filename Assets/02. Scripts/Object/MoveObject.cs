using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float startPoint;                // 시작점
    public float turningPoint;              // 반환점
    public float moveSpeed;                 // 이동 속도

    bool turnSwitch;

    // X축 이동 조정
    void PositionX()
    {
        float currentPositionX = transform.position.x;

        if(currentPositionX >= startPoint)
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

        if(currentPositionY >= startPoint)
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

        if (currentPositionZ >= startPoint)
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
        else if (gameObject.name == "XMoveObject")
        {
            PositionX();
        }
        else if (gameObject.name == "ZMoveObject")
        {
            PositionZ();
        }
    }
}
