using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeckMan_GD07
{
    public class BaseGridObject : MonoBehaviour
    {
        //    //All of our objects will inherit from this...our pills,walls,ghosts,and HackMan
        public IntVector2 GridPosition;
        //    public Vector2Int GridPos;
        //    private void OnEnable()
        //    {
        //        var whatever = Vector2Int.zero;
        //        var whateverAlso = new Vector2Int(0, 0);
        //        var whateverAgain = IntVector2.zero;
        //    }
        //}
        [Serializable]
        public struct IntVector2
        {
            public int x;
            public int y;
            public static IntVector2 zero => new IntVector2(0, 0);
            public IntVector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
             public static IntVector2 operator +(IntVector2 v1,IntVector2 v2)
            {
                return new IntVector2(v1.x + v2.x, v1.y + v2.y);
            }
            public static IntVector2 operator -(IntVector2 v)
            {
                return new IntVector2(-v.x,-v.y);
            }
            public static bool operator ==(IntVector2 v1, IntVector2 v2)
            {
                return (v1.x==v2.x&&v1.y==v2.y);
            }
            public static bool operator !=(IntVector2 v1, IntVector2 v2)
            {
                return (v1.x != v2.x || v1.y != v2.y);
            }
        }

    }
}
