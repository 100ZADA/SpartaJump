using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObject : MonoBehaviour
{
    public int jumpPower;           // 날아가는 힘

    public List<ISObject> things = new List<ISObject>();

    void Start()
    {
        InvokeRepeating("JumpPower", 0, 0.1f);
    }

    void JumpPower()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalJump(jumpPower);
        }
    }

    // 만약 트리거에서 접근하게 되면
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ISObject jumpAmount))
        {
            things.Add(jumpAmount);
        }
    }

    // 만약 트리거에서 벗어나게 되면
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ISObject jumpAmount))
        {
            things.Remove(jumpAmount);
        }
    }
}

