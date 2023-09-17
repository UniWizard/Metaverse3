using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BayatGames.SaveGameFree.Types;
using BayatGames.SaveGameFree.Serializers;
using BayatGames.SaveGameFree;

public class GameObjectSaveRotation : MonoBehaviour
{

    public Transform target;
    public bool loadOnStart = true;
    public string identifier = "exampleSaveRotation.dat";

    // Use this for initialization
    void Start()
    {
        SaveGame.Serializer = new SaveGameBinarySerializer();
        if (loadOnStart)
        {
            Load();
        }
    }

    //Save on exit
    void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        SaveGame.Save<QuaternionSave>(identifier, target.rotation, SaveGamePath.DataPath);
    }

    public void Load()
    {
        target.rotation = SaveGame.Load<QuaternionSave>(
                identifier,
                Quaternion.identity,
                SaveGamePath.DataPath);
    }
}
