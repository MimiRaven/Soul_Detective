using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C_XpScore : MonoBehaviour, IDataPersistence
{

    public int CurrentScore;
    public int MaxScore;

    public float SkillPoints;

    public TextMeshProUGUI soulsUI;

    // Start is called before the first frame update
    void Start()
    {
        MaxScore = 2;
    }

    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    public void LoadData(GameData data)
    {
        this.SkillPoints = data.SkillPoints;
        this.CurrentScore = data.CurrentXpAmmount;
    }

    public void SaveData(GameData data)
    {
        data.SkillPoints = this.SkillPoints;
        data.CurrentXpAmmount = this.CurrentScore;
    }


    // Update is called once per frame
    void Update()
    {
        soulsUI.text = " " + SkillPoints.ToString();
        GainPoint();
    }

    void GainPoint()
    {
        if (CurrentScore >= MaxScore)
        {
            CurrentScore = 0;
            SkillPoints += 1;
        }


        C_UIxpBar.instance.SetValue(CurrentScore / (float)MaxScore);
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "XPpickup")
        {

            CurrentScore += 1;
            Destroy(collision.gameObject);
        }



    }
}