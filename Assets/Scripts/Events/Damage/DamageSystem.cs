using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem:MonoBehaviour
{
    private void OnEnable()
    {
        Evently.Instance.Subscribe<DamageEvent>(OnDamaged);
    }
    private void OnDisable()
    {
        Evently.Instance.Unsubscribe<DamageEvent>(OnDamaged);
    }
    private void OnDamaged(DamageEvent damageEvent)
    {
        Evently.Instance.Publish(new GameOverEvent(false));
    }
}