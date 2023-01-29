using System.Linq;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private float _rayDistance = 5.0f;
    private float _stoppingDistance = 1.5f;
    public float speed;

    private Vector3 _destination;
    private Quaternion _desiredRotation;
    private Vector3 _direction;

    //public GameObject Self;
    private Rigidbody objectRb;
    public Transform Player;
    public GameObject playerObject;

    public bool Attacking;
    //public bool Roaming;

    void Awake()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Attacking == false)
        {
            Wander();

        }
        AgroCheck();
        AttackingFunction();
    }

    void Wander()
    {
        
        

            if (NeedsDestination())
            {
                GetDestination();
            }

            transform.rotation = _desiredRotation;

            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            var rayColor = IsPathBlocked() ? Color.red : Color.green;
            Debug.DrawRay(transform.position, _direction * _rayDistance, rayColor);

            while (IsPathBlocked())
            {
                Debug.Log("Path Blocked");
                GetDestination();
            }

        
    }

    private bool IsPathBlocked()
    {
        Ray ray = new Ray(transform.position, _direction);
        var hitSomething = Physics.RaycastAll(ray, _rayDistance, _layerMask);
        return hitSomething.Any();
    }

    private void GetDestination()
    {
        Vector3 testPosition = (transform.position + (transform.forward * 4f)) +
                               new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), 0f,
                                   UnityEngine.Random.Range(-4.5f, 4.5f));

        _destination = new Vector3(testPosition.x, 1f, testPosition.z);

        _direction = Vector3.Normalize(_destination - transform.position);
        _direction = new Vector3(_direction.x, 0f, _direction.z);
        _desiredRotation = Quaternion.LookRotation(_direction);
    }

    private bool NeedsDestination()
    {
        if (_destination == Vector3.zero)
            return true;

        var distance = Vector3.Distance(transform.position, _destination);
        if (distance <= _stoppingDistance)
        {
            return true;
        }

        return false;
    }



    Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    void AgroCheck()
    {
        
        float aggroRadius = 10f;

        RaycastHit hit;
        var angle = transform.rotation * startingAngle;
        var direction = angle * Vector3.forward;
        var pos = transform.position;
        for (var i = 0; i < 100; i++)
        {

            Debug.DrawRay(pos, direction * aggroRadius, Color.white);

            if (Physics.Raycast(pos, direction, out hit, aggroRadius))
            {
                //var drone = hit.collider.GetComponent<C_PlayerController>();
                if (hit.transform.tag == "Player")
                {
                    //objectRb.MovePosition(Player.position);
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    Attacking = true;
                }
                else
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.yellow);
                    
                    Attacking = false;
                }

                //if(drone = null )
                //{
                //    Attacking = false;
                //} 
            }
            else
            {
                //Attacking = false;
                Debug.DrawRay(pos, direction * aggroRadius, Color.white);
            }
            direction = stepAngle * direction;
        }
    }

    void AttackingFunction()
    {
        if(Attacking == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, speed * Time.deltaTime);
            transform.LookAt(Player);

        }
    }

}
