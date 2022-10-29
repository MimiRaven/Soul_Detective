using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class C_PlayerController : MonoBehaviour
{
    //Player Values
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    public float rotationSpeed = .8f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Transform cameraTransfrom;

    private InputAction moveAction;
    private InputAction jumpAction;
    private PlayerInput playerInput;

    public bool Possesed = true;

    public C_EnemyPossesed c_EnemyPossesed;
    public GameObject PlayerCams;

    public int maxHealth = 10;
    public int health { get { return currentHealth; } }
    int currentHealth;

    public bool WeaponWheel;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        
        cameraTransfrom = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
     

        currentHealth = maxHealth;

        Cursor.visible = false;

        Possesed = true;
}

    void Update()
    {

        if (Possesed == true)
        {
            Debug.Log("Player Posesed");
            Movement();
            PlayerCams.SetActive(true);
        }
        else 
        { 
            Debug.Log("Player Not Possesd");
            PlayerCams.SetActive(false);

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

     public void ChangeHealth(int amount)
    {
        if (health <= 1)
        {
            playerSpeed = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
