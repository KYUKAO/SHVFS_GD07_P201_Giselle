using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEvent : MonoBehaviour
{
    public DamagableComponent player;
    public DamageEvent(DamagableComponent en)
    {
        this.player = en;
    }
}
