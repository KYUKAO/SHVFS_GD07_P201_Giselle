using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;

namespace HeckMan_GD07
{
    public class BaseGridMovement : BaseGridObject
    {
        public float MovementSpeed;
        protected IntVector2 targetGridPosition;
        protected float progressToTarget = 1f;
        protected IntVector2 currentInputDirection;
        protected IntVector2 previousInputDirection;
        private void Start()
        {
            
        }
        protected virtual void Update()
        {
            if (transform.position == targetGridPosition.ToVector3())
            {
                progressToTarget = 0f;
                GridPosition = targetGridPosition;
            }
            if (GridPosition == targetGridPosition 
                && LevelGeneratorSystem.Grid[Mathf.Abs(GridPosition.y + currentInputDirection.y), Mathf.Abs(GridPosition.x + currentInputDirection.x)] != 1)
            {
                targetGridPosition += currentInputDirection;
                previousInputDirection = currentInputDirection;
            }
            else if (GridPosition == targetGridPosition 
                && LevelGeneratorSystem.Grid[Mathf.Abs(GridPosition.y + previousInputDirection.y), Mathf.Abs(GridPosition.x + previousInputDirection.x)] != 1)
            {
                targetGridPosition += previousInputDirection;
            }
            if (GridPosition == targetGridPosition) return;
            progressToTarget += MovementSpeed * Time.deltaTime;
        }
    }
    public static class ExtensionMethods
    {//Extension methods allows us to EXTEND the functionality of our classes,without MODIFYING the class itself
        //This follows one of our principles
        public static Vector3 ToVector3(this BaseGridObject.IntVector2 vector2)
        {
            return new Vector2(vector2.x, vector2.y);
        }
        public static BaseGridObject.IntVector2 IntVector2(this Vector3 vector3)
        {
            return new BaseGridObject.IntVector2((int)vector3.x, (int)vector3.y);
        }
    }
}


