using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public List<PersistentHighScore> ObjectsToSave;

    public void OnEnable()
    {
        for(int i=0;i<ObjectsToSave.Count; i++)
        {
            var so = ObjectsToSave[i];
            so.Load();
        }
    }

    public void OnDisable()
    {
        for(int i=0; i<ObjectsToSave.Count; i++)
        {
            var so = ObjectsToSave[i];
            so.Save();
        }
    }
}
