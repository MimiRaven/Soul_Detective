using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C_XpScore : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        soulsUI.text = "SkillPoints: " + SkillPoints.ToString();
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
