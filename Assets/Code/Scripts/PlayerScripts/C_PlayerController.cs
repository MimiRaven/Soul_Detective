using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//using TMPro;

[RequireComponent(typeof(CharacterController))]
public class C_PlayerController : MonoBehaviour
{

    [SerializeField]
    private PlayerInput playerInput;

    //Player Values
    [SerializeField]
    public float playerSpeed = 5f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    public float rotationSpeed = .8f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

   // float stamina = 10, maxStamina = 10;
   // float walkSpeed, runSpeed;
   // bool isRunning;

    private Transform cameraTransfrom;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction sprintAction;

    //[SerializeField]
    //private PlayerInput playerInput;

    public bool Possesed;

    private float boostTimer;
    private bool boosting;
    private bool quit;
    public GameObject PlayerCams;

   // public int maxHealth = 10;
   // public int health { get { return currentHealth; } }
   // int currentHealth;

    public bool WeaponWheel;
    public GameObject Abilitys,WeaponWheelObject,PlayerModle;

    public bool isRunning;
    public float CurrentStamina;
    public float MaxStamina;

    public GameObject PlayerInputObject;

    //public int souls;
    //public TextMeshProUGUI soulsUI; 


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        //playerInput = GetComponent<PlayerInput>();

        //walkSpeed = playerSpeed;
        //runSpeed = walkSpeed + 5;
        
        cameraTransfrom = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        sprintAction = playerInput.actions["Sprint"];

        boostTimer = 0;
        boosting = false;
        quit = false;

       // currentHealth = maxHealth;

        Cursor.visible = false;

        Possesed = true;

        CurrentStamina = MaxStamina;
        isRunning = false;
    }

    void RunningFunction()
    {
        Sprinter.instance.SetValue(CurrentStamina / MaxStamina);
        if (isRunning)
        {
            ActiveRunning();
        }
        else
        {
            Resting();
           
        }

    }

    void ActiveRunning()
    {
        if (CurrentStamina >= 0)
        {
            playerSpeed = 10;
            CurrentStamina -= Time.deltaTime;

        }
        else
        {
            playerSpeed = 5;
        }
    }

    void Resting()
    {
        
        if (CurrentStamina < MaxStamina)
        {
            playerSpeed = 5;
            CurrentStamina += Time.deltaTime;
        }
    }

    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);

    }

    void Update()
    {
        IsPossesed();
        RunningFunction();
        //soulsUI.text = "Souls: " + souls.ToString();

        if (boosting)
        {
            boostTimer += Time.deltaTime;
            playerSpeed = 10;
            if (boostTimer >= 5)
            {
                playerSpeed = 5;
                boostTimer = 0;
                boosting = false;
            }
        }

        if(quit == true)
        {
            QuitGame();
        }

        



    }

    void IsPossesed()
    {
        if (Possesed == true)
        {
            Debug.Log("Player Posesed");
            Movement();
            PlayerCams.SetActive(true);
            Abilitys.SetActive(true);
            WeaponWheelObject.SetActive(true);
            PlayerModle.SetActive(true);
            //PlayerInputObject.SetActive(true);
        }
        else 
        { 
            Debug.Log("Player Not Possesd");
            PlayerCams.SetActive(false);
            Abilitys.SetActive(false);
            WeaponWheelObject.SetActive(false);
            PlayerModle.SetActive(false);
            //PlayerInputObject.SetActive(false);
        }
    }


    void Movement()
    {
        if (WeaponWheel == false)
        {
            Cursor.visible = false;

            //Player Movement Code
            groundedPlayer = controller.isGrounded;
          if (groundedPlayer && playerVelocity.y < 0)
          {
              playerVelocity.y = 0f;
          }

          Vector2 input = moveAction.ReadValue<Vector2>();
          Vector3 move = new Vector3(input.x, 0, input.y);
          move = move.x * cameraTransfrom.right.normalized + move.z * cameraTransfrom.forward.normalized;
          move.y = 0f;
          controller.Move(move * Time.deltaTime * playerSpeed);


          //Player Rotation  
          if (move != Vector3.zero)
          {
              Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);

              transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
          }

          //Player Jump Code
          if (jumpAction.triggered && groundedPlayer)
          {
              playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
          }
          playerVelocity.y += gravityValue * Time.deltaTime;
          controller.Move(playerVelocity * Time.deltaTime);

        }
    }

    void OnQuit()
    {
        quit = true;

    }

    void QuitGame()
    {
        Application.Quit();
        //SceneManager.LoadScene(0);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Speed")
        {
            boosting = true;
            Destroy(other.gameObject);
        }
    }



}
