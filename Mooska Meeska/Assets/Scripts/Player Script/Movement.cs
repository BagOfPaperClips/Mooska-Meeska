using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{

    public CharacterController c;
    public float speed = 9f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    public Rigidbody player;

    Vector3 moveDir;

    public float sprintTime = 1;
    public float remainingTime;
    [SerializeField] int seconds;
    public Image stamBar;

    public float maxStam;
    public bool isReady = false;
    public bool start = true;

    public Animator walk;

    private void Start()
    {
        remainingTime = sprintTime;
        walk.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        speed = 20f;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;

        if(dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            c.Move(moveDir * speed * Time.deltaTime);

            walk.SetBool("isWalking", true);
            walk.SetBool("isStanding", false);

        }
        else if(dir.magnitude < 0.1f)
        {
            walk.SetBool("isStanding", true);
            walk.SetBool("isWalking", false);
        }
    }

}
