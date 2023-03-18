using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletionManager : MonoBehaviour, IDataPersistence
{
    public bool Lv1Complete;
    public bool Lv2Complete;
    public bool Lv3Complete;

 

    public void LoadData(GameData data)
    {
        this.Lv1Complete = data.Level1Complete;
        this.Lv2Complete = data.Level2Complete;
        this.Lv3Complete = data.Level3Complete;
    }

    public void SaveData(GameData data)
    {
        data.Level1Complete = this.Lv1Complete;
        data.Level2Complete = this.Lv2Complete;
        data.Level3Complete = this.Lv3Complete;
    }
}
