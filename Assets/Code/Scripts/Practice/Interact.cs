using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public bool Level1Range;
    public bool Level2Range;
    public bool Level3Range;
    public bool TypeWriterRange;

    public bool SkillTreeOn;

    public SkilltreeManager SkilltreeManager;

    [SerializeField]
    private PlayerInput playerInput;

    private InputAction Interaction;

   // public GameObject SkillTreeCanvas;

    private void Awake()
    {
        Interaction = playerInput.actions["Diolouge"];
    }

    void OnEnable()
    {
        Interaction.performed += _ => InteractStart();
        Interaction.canceled += _ => InteractStop();
    }

    void OnDisable()
    {
        Interaction.performed -= _ => InteractStart();
        Interaction.canceled -= _ => InteractStop();
    }
    void Start()
    {
        //SkillTreeCanvas.SetActive(false);

        if (SceneManager.GetActiveScene().name == "HubWorld")
        {
            Level1Range = false;
            Level2Range = false;
            Level3Range = false;
        }
    }

    void Update()
    {

    }

    public void InteractStart()
    {
        if(Level1Range == true)
        {
            SceneManager.LoadScene("Level 1");
            Level1Range= false;
        }

        if(Level2Range == true)
        {
            SceneManager.LoadScene("Lv2 intro");
            Level2Range= false;
        }

        if(Level3Range == true)
        {
            SceneManager.LoadScene("Lv3 intro");
            Level3Range= false;
        }

        if(TypeWriterRange == true)
        {
            SkillTreeOn = !SkillTreeOn;

            if(SkillTreeOn)
            {
            SkilltreeManager.WheelActivated();

            }
            else
            {
                SkilltreeManager.WheelDeactivated();
            }
            // SkillTreeCanvas.SetActive(true);
        }
    }

    public void InteractStop()
    {
        //SkilltreeManager.WheelDeactivated();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Level 1")
        {
            Level1Range = true;
        }

        if (other.tag == "Level 2")
        {
            Level2Range = true;
        }

        if (other.tag == "Level 3")
        {
            Level3Range = true;
        }

        if(other.tag == "Typewriter")
        {
            TypeWriterRange = true;
        }
    } 

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Typewriter")
        {
            TypeWriterRange = false;
        }
        if (other.tag == "Level 1")
        {
            Level1Range = false;
        }

        if (other.tag == "Level 2")
        {
            Level2Range = false;
        }

        if (other.tag == "Level 3")
        {
            Level3Range = false;
        }
    }
}