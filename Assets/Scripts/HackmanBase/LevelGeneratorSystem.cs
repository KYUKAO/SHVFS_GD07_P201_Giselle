using UnityEngine;
using HackMan_GD07;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace HackMan_GD07
{
    public class LevelGeneratorSystem : MonoBehaviour
    {
        public List<int[,]> Levels = new List<int[,]>();
        public int MaxmumOfLevels = 10;
        public BaseGridObject[] BaseGridObjectPrefabs;
        GameObject lastLevelContainer;
        public static int[,] Grid = new int[,] { };
        int oldRand = 0;
        int rand = 0;

        private void Update()
        {
            if (GameOverSystem.IsGameOver)
            {
                RandomlyChooseALevel();
                FillLevelWithGrid();
                GameOverSystem.IsGameOver = false;
            }
            //For Test
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                IntializeLevels();
                Grid = Levels[5];
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CollectorComponent.NumOfCollectable = FindObjectsOfType<CollactableComponent>().Length;
            }
        }
        public void FillLevelWithGrid()
        {
            if (lastLevelContainer)
            {
                Destroy(lastLevelContainer);
            }
            GameObject LevelContainer = new GameObject("LevelContainer");
            var gridSizeY = Grid.GetLength(0);
            var gridSizeX = Grid.GetLength(1);
            for (var y = 0; y < gridSizeY; y++)
            {
                for (var x = 0; x < gridSizeX; x++)
                {
                    //Normally with "math",x comes first ,then y...
                    var objectType = Grid[y, x];
                    var gridObjectPrefab = BaseGridObjectPrefabs[objectType];
                    var gridObjectClone = Instantiate(gridObjectPrefab);
                    gridObjectClone.GridPosition = new IntVector2(x, -y);
                    gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x, gridObjectClone.GridPosition.y, 0);
                    gridObjectClone.transform.SetParent(LevelContainer.transform);
                    lastLevelContainer = LevelContainer;
                }
            }
            CollectorComponent.NumOfCollectable = 0;
            for (int i = 0; i < LevelContainer.transform.childCount; i++)
            {
                var obj = LevelContainer.transform.GetChild(i);
                if (obj.GetComponent<CollactableComponent>())
                {
                    CollectorComponent.NumOfCollectable++;
                }
            }
        }

        public void RandomlyChooseALevel()
        {
            IntializeLevels();
            while (oldRand == rand)
            {
                rand = Random.Range(0, Levels.Count);
            }
            Grid = Levels[rand];
            oldRand = rand;
            Debug.Log($"CurrentLevel : Level_{rand}");
        }

        void IntializeLevels()
        {
            Levels.Clear();
            for (int n = 0; n < MaxmumOfLevels; n++)
            {
                var newLevel = AppDataSystem.Load<int[,]>($"Level_{n}");
                if (newLevel != null)
                {
                    Levels.Add(newLevel);
                }
            }
        }

        [ContextMenu("New Save Level")]
        private void NewSaveLeve()
        {
            Levels.Clear();
            var directoryPath = $"{Application.dataPath}/StreamingAssets/{typeof(int[,]).Name}";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            for (int i = 0; i < MaxmumOfLevels; i++)
            {
                var filePath = $"{Application.dataPath}/StreamingAssets/{typeof(int[,]).Name}/Level_{i}.json";
                if (!File.Exists(filePath))
                {
                    AppDataSystem.Save<int[,]>(Grid, $"Level_{i}");
                    Debug.Log($"Saved Level_{i} as {Grid}");
                    break;
                }
            }
        }

        //[ContextMenu("Save Level")]
        //private void SaveLevel()
        //{
        //    var savedGrid = JsonConvert.SerializeObject(Grid);
        //    var directoryPath = $"{Application.dataPath}/StreamingAssets/Levels";

        //    if (!Directory.Exists(directoryPath))
        //    {
        //        Directory.CreateDirectory(directoryPath);
        //    }
        //    var fullFilePath = $"{Application.dataPath}/StreamingAssets/Levels/Level_0.json";

        //    if (!File.Exists(fullFilePath))
        //    {
        //        var fileStream = File.Create(fullFilePath);
        //        fileStream.Close();
        //    }
        //    File.WriteAllText(fullFilePath, savedGrid);
        //    Debug.Log($"saved level: {savedGrid}");
        //}

        //[ContextMenu("Log Grid")]
        //private void LogGrid()
        //{
        //    var obj = JsonConvert.SerializeObject(Grid);
        //    Debug.Log(obj);
        //}

        //HW:Finish save and Load for AppDataSystem
        //Make 10 different levels
        //LevelGenerator should pick a random level from the 10
        //Bonus Points -> Create a LoadAll method in the AppDataSystem
        //When the game is run ,won, or lost,user should see a UI message telling them what happened ,and have a button to click to play another level

        //string fullFilePath =$"{Application.dataPath}/StreamingAssets/Levels/Level_1.json";
        //0=pill,1=wall,2=hackman,3=ghost
        //4 Features:
            //Health system
            //Can transport to another level with current position and transport back
            //After transported ,the current level savesitself.
            //The AI will chase you if you are nearby?
    }
}