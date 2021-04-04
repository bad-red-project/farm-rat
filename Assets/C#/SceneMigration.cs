using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMigration : MonoBehaviour
{
    void Start()
    {
        if (GetIsEntityAlreadyExists())
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private bool GetIsEntityAlreadyExists()
    {
        List<GameObject> searchedEnities = new List<GameObject>();
        string entityName = gameObject.name;

        foreach (GameObject seekedGameObj in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (entityName == seekedGameObj.name)
            {
                searchedEnities.Add(seekedGameObj);
            }
        }

        return searchedEnities.Count > 1;
    }
}
