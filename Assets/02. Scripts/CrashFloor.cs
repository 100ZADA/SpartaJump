using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrashFloor : MonoBehaviour
{
    public int damage;

    public List<ISObject> things = new List<ISObject>();

    void Start()
    {
        InvokeRepeating("FloorDamage", 0, 1f);
    }

    void FloorDamage()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalFloor(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������ �ް� ���� ��ҷ� ���ƿ���
        ISObject isObject = other.GetComponent<ISObject>();

        if (isObject != null)
        {
            isObject.TakePhysicalFloor(damage);
        }
    }
}
