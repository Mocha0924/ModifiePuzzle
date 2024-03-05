using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject movePoint;
    private Rigidbody rb;
    [SerializeField] private float speed;
    private Vector3 direction;
    private float angle;
    [SerializeField] private float MaxResetTime;
    private float ResetTime = 0;
    private Vector3 Repos;
    [SerializeField] private List<ObstacleController> buttons = new List<ObstacleController>();
    public bool CreateMode = true;
    private float S;
    GameObject clickedGameObject;
    private ButtonController buttonController;
    public static PlayerController instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this);
    }
    void Start()
    {
        Repos = transform.position;
        direction = movePoint.transform.position - transform.position;
        S = Mathf.Sqrt(direction.x+direction.y+direction.z);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!CreateMode)
            if(rb.velocity.magnitude <speed)
            {
                float currentSpeed = speed - rb.velocity.magnitude;
                rb.AddForce(new Vector3(direction.x / S, 0, direction.z / S) * currentSpeed);
            }
           
      

    }
    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0)&&CreateMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
            }
            if (clickedGameObject.gameObject.tag != "ChangeGimmmick")
            {
                clickedGameObject = null;
            }
            else
            {
                buttonController = clickedGameObject.GetComponent<ButtonController>();
            }
        }
        if(Input.GetMouseButton(0)&&CreateMode&& clickedGameObject != null)
        {
            buttonController.Createpos();
        }
        if (Input.GetMouseButtonUp(0) && CreateMode)
        {
            clickedGameObject = null;
            buttonController = null;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            if(CreateMode)
            {
                CreateMode = false;
            }
            else
            {
                CreateMode = true;
                Reset();
            }
        }
        if(!CreateMode)
        {
            ResetTime += Time.deltaTime;
            if (ResetTime > MaxResetTime)
                Reset();
        }
           

    }

    public void Reset()
    {
        ResetTime = 0;
        transform.position = Repos;
        foreach(ObstacleController button in buttons)
        {
            button.Reset();
        }

    }
}
