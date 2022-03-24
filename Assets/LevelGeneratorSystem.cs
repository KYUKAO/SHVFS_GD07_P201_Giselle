using UnityEngine;
using HackMan_GD07;

namespace HackMan_GD07
{
    public class LevelGeneratorSystem : MonoBehaviour
    {
        public BaseGridObject[] BaseGridObjectPrefabs;
        public static int[,] Grid = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1 },
            {1,0,1,0,1,0,0,0,0,1 },
            {1,0,1,0,0,0,2,0,0,1 },
            {1,0,1,0,0,1,0,0,1,1 },
            {1,0,3,0,0,1,0,0,0,1 },
            {1,0,0,0,0,1,3,0,0,1 },
            {1,1,1,1,1,1,1,1,1,1 },
        };
        private void Awake()
        {
            //Debug.Log(Grid[2,5]);
            var gridSizeY = Grid.GetLength(0);
            var gridSizeX = Grid.GetLength(1);
            for(var y = 0; y < gridSizeY; y++)
            {
                for(var x = 0; x < gridSizeX; x++)
                {
                    //Normally with "math",x comes first ,then y...
                    var objectType = Grid[y,x];
                    var gridObjectPrefab = BaseGridObjectPrefabs[objectType];
                    var gridObjectClone = Instantiate(gridObjectPrefab);
                    gridObjectClone.GridPosition = new BaseGridObject.IntVector2(x, -y);
                    gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x, gridObjectClone.GridPosition.y, 0);
                }
            }
        }

    }
}

