using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace R_D_2.Script.Services
{
    public class LevelService
    {
        private List<INeedLevelUpdate> allLevelUpdate = new List<INeedLevelUpdate>();

        public LevelService()
        {
            SceneManager.sceneLoaded += UpdateAllLevelUpdate;
        }

        public string GetLevelName()
        {
            return SceneManager.GetActiveScene().name;
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        #region LevelUpdate
        public void UpdateAllLevelUpdate(Scene scene, LoadSceneMode mode)
        {
            Debug.Log($"Scene : {scene.name} is loaded sucessfully");

            foreach (INeedLevelUpdate lu in allLevelUpdate)
            {
                lu.UpdateLevelInformation();
            }
        }

        public void RegisterForLevelUpdate(INeedLevelUpdate classNeed)
        {
            allLevelUpdate.Add(classNeed);
        }

        public void UnregisterForLevelUpdate(INeedLevelUpdate classNeed)
        {
            allLevelUpdate.Remove(classNeed);

        }
        #endregion
    }

}