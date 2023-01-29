using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OuttroScript : MonoBehaviour
{

	public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
	public string SceneName;

    [SerializeField]
    private PlayerInput playerInput;
    private InputAction SkipAction;

    void Start()
	{
		VideoPlayer.loopPointReached += LoadScene;
	}
	void LoadScene(VideoPlayer vp)
	{
		SceneManager.LoadScene("Win Screen");
	}

    private void Awake()
    {
        SkipAction = playerInput.actions["SkipCutsceen"];
    }

    private void OnEnable()
    {
        SkipAction.performed += _ => StartSkip();
        SkipAction.canceled += _ => CancelSkip();


    }

    private void OnDisable()
    {
        SkipAction.performed -= _ => StartSkip();
        SkipAction.canceled -= _ => CancelSkip();

    }

    public void StartSkip()
    {
        SceneManager.LoadScene("Win Screen");
    }

    public void CancelSkip()
    {
        
    }

}
