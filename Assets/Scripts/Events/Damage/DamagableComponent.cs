using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableComponent : MonoBehaviour
{
    public static int Health = 100;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<WallComponent>()||other.GetComponent<EnemyInputComponent>())
        {
            Evently.Instance.Publish(new DamageEvent(this));
            Evently.Instance.Publish(new GameOverEvent(false));
        }
    }
}
