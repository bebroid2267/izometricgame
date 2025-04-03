using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMoveController : MonoBehaviour
{

    public float speed;  
    public float speedTurn;  
    public bool matrix = false; 
    
    public Animator animator;

    public Button FreeCameraBtn;
    public bool isCameraMode = false;

    public float cameraSpeed = 20f;

    private Vector2 lastTouchPosition;
    private NavMeshAgent agent;
    private Camera mainCamera;
    private Rigidbody _rb;
    private Vector3 _input;
    private Vector3 relative;

    public CameraFollowTarget followTarget;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
        FreeCameraBtn.onClick.AddListener(ToggleCameraMode);

    }

    private void Awake()
    {
        if (animator) { gameObject.GetComponent<Animator>(); }
        if (_rb) { gameObject.GetComponent<Animator>(); }
    }

    void Update()
    {
        if (isCameraMode)
        {
            MoveCamera();  
        }
        else
        {
            InputGet();
            Look();
        }
    }
    private void MoveCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector2 delta = (Vector2)Input.mousePosition - lastTouchPosition;
            lastTouchPosition = Input.mousePosition;

            float h = delta.x * cameraSpeed * Time.deltaTime;
            float v = delta.y * cameraSpeed * Time.deltaTime;

            mainCamera.transform.position -= new Vector3(h, 0, v);
        }
    }


    private void FixedUpdate()
    {
        if (_input != Vector3.zero)
        {
            Move();
        }
    }

    private void InputGet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (!agent.enabled)
                {
                    agent.enabled = true;
                }
                agent.SetDestination(hit.point);
                GetComponent<PlayerAnimtaionCon>().Run(speed, true);
            }
            else
            {
                GetComponent<PlayerAnimtaionCon>().Run(speed, false);
            }
        }
        else if (!agent.hasPath)
        {
            GetComponent<PlayerAnimtaionCon>().GroundWalk();
        }
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * speed * Time.deltaTime);
    }
    private void ToggleCameraMode()
    {
        isCameraMode = !isCameraMode;
        followTarget.isNeed = !isCameraMode;
        mainCamera.GetComponent<CameraFollowTarget>().enabled = !isCameraMode;
    }

    private void Look()
    {
        if (_input != Vector3.zero)
        {
            if (matrix == false)
            {
                relative = (transform.position + _input) - transform.position;
            }
            else
            {
                var isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
                relative = (transform.position + ToIso(_input, isoMatrix) - transform.position);
            }
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, speedTurn * Time.deltaTime);
        }
    }
    public Vector3 ToIso(Vector3 input, Matrix4x4 _isoMatrix) => _isoMatrix.MultiplyPoint3x4(input);

}
