using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObject : MonoBehaviour
{
    public int jumpPower;           // ���ư��� ��

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

    // ���� Ʈ���ſ��� �����ϰ� �Ǹ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ISObject jumpAmount))
        {
            things.Add(jumpAmount);
        }
    }

    // ���� Ʈ���ſ��� ����� �Ǹ�
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ISObject jumpAmount))
        {
            things.Remove(jumpAmount);
        }
    }
}

