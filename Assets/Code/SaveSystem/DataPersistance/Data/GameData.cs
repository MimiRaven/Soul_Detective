using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{

    public int PlayerCurrentHealth;
    public int PlayerCurrentLives;


    //Save Menu Continue Button
    public long lastUpdated;

    //PlayerPosition
    public Vector3 playerPositionInHubWorld;
    public Vector3 playerPositionInLevel1;
    public Vector3 playerPositionInLevel2;
    public Vector3 playerPositionInLevel3;

    //Enterd Levels bool


    //EnemyTracker
    public SerializableDictionary<string,bool> EnemysKilled;

    //Level Completion Tracker
    public bool Level1Complete;
    public bool Level2Complete;
    public bool Level3Complete;

    //Tracking Current Level
    public bool InHubWorld;
    public bool InLevel1;
    public bool InLevel2;
    public bool InLevel3;




    //Skill Tree Values
    public int CurrentXpAmmount;
    public float SkillPoints;

    public bool TeleTimeUpgrade1;
    public bool TeleTimeUpgrade2;
    public bool TeleTimeUpgrade3;

    public bool RangeAttTimeUpgrade1;
    public bool RangeAttTimeUpgrade2;
    public bool RangeAttTimeUpgrade3;

    public bool PossesionTimeUpgrade1;
    public bool PossesionTimeUpgrade2;
    public bool PossesionTimeUpgrade3;

    public bool PossesionCoolDownTimeUpgrade1;
    public bool PossesionCoolDownTimeUpgrade2;
    public bool PossesionCoolDownTimeUpgrade3;

    public bool PlayerWeaponUpgrade1;
    public bool PlayerWeaponUpgrade2;
    public bool PlayerWeaponUpgrade3;


    //Level 1 Quest Values
    public bool Quest1;
    public bool Quest2;
    public bool Quest3;
    public bool Quest4;
    public bool Quest5;

    public bool KeepSakeQuest;
    public bool EscortQuest;

    //Level 2 Quest Value
    public bool RightBossDead;
    public bool LeftBossDead;

    public bool LV2Boss1Dead;
    public bool LV2Boss2Dead;

    public bool LV2Quest1;
    public bool LV2Quest2;
    public bool LV2Quest3;
    public bool LV2Quest4;

    public bool RiddleQuest;
    public bool ProspectorQuest;

    //Level 3 Quest Value
    public bool FirstBossDead;
    public bool SecondBossDead;
    public bool ThirdBossDead;
    public bool MiniBossesDead;
    public bool FinalBossDead;
    public GameData()
    {
        Level1Complete = false;
        Level2Complete = false;
            Level3Complete = false;
        this.SkillPoints = 0;
        this.CurrentXpAmmount= 0;
        this.PlayerCurrentLives = 3;
        this.PlayerCurrentHealth = 10;
      //  playerPosition= Vector3.zero;
        
        EnemysKilled= new SerializableDictionary<string,bool>();

        

        this.TeleTimeUpgrade1= false;
        this.TeleTimeUpgrade2 = false;
        this.TeleTimeUpgrade3 = false;

        this.RangeAttTimeUpgrade1 = false;
        this.RangeAttTimeUpgrade2 = false;
        this.RangeAttTimeUpgrade3 = false;

        this.PossesionTimeUpgrade1 = false;
        this.PossesionTimeUpgrade2 = false;
        this.PossesionTimeUpgrade3 = false;

        this.PossesionCoolDownTimeUpgrade1 = false;
        this.PossesionCoolDownTimeUpgrade1 = false;
        this.PossesionCoolDownTimeUpgrade1 = false;

        this.PlayerWeaponUpgrade1 = false;
        this.PlayerWeaponUpgrade2 = false;
        this.PlayerWeaponUpgrade3 = false;

        //Level 1
        Quest1= false;
        Quest2= false;
        Quest3= false;
        Quest4= false;
        Quest5= false;
        KeepSakeQuest = false;
        EscortQuest = false;

        //Level 2
        RightBossDead = false;
        LeftBossDead= false;
        LV2Quest1= false;
        LV2Quest2= false;
        LV2Quest3= false;
        LV2Quest4= false;

        LV2Boss1Dead= false;
        LV2Boss2Dead= false;

        RiddleQuest = false;
        ProspectorQuest = false;

        //Level 3
        FirstBossDead = false;
        SecondBossDead= false;
        ThirdBossDead= false;
        MiniBossesDead= false;
        FinalBossDead= false;

    }
}


