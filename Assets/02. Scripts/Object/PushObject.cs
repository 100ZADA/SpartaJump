using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushStool : MonoBehaviour
{
    public int pushPower;              // �и��� ��
    public float pushInterval;         // ȣ�� ����

    public List<ISObject> things = new List<ISObject>();

    void Start()
    {
        InvokeRepeating("PushPower", 0, pushInterval);
    }

    void PushPower()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalPush(pushPower);
        }
    }

    // ���� Ʈ���ſ��� �����ϰ� �Ǹ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ISObject pushAmount))
        {
            things.Add(pushAmount);
        }
    }

    // ���� Ʈ���ſ��� ����� �Ǹ�
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ISObject pushAmount))
        {
            things.Remove(pushAmount);
        }
    }
}

