using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OuttroScript : MonoBehaviour
{

    public float setTime;
    public float TimeLeft;
    public bool TimerOn;
    // Start is called before the first frame update
    void Start()
    {
		TimerOn = true;
		TimeLeft = 17;
    }

    // Update is called once per frame
    void Update()
    {
		Timmer();
		
    }

	void Timmer()
	{

		if (TimerOn)
		{

			if (TimeLeft > 0)
			{
				TimeLeft -= Time.deltaTime;

			}
			else
			{
				Debug.Log("Time is Up");
				TimerOn = false;
				SceneManager.LoadScene("Win Screen");

			}

		}
	}
}
