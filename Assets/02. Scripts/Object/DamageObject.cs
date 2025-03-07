using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int damage;              // 데미지
    public float damageRate;        // 피해 딜레이

    public List<ISObject> things = new List<ISObject>();

    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    void DealDamage()
    {
        for(int i= 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        }
    }

    // 만약 트리거에서 접근하게 되면
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ISObject damgealbe))
        {
            things.Add(damgealbe);
        }
    }

    // 만약 트리거에서 벗어나게 되면
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out ISObject damagealbe))
        {
            things.Remove(damagealbe);
        }
    }
}
