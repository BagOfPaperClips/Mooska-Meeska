using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public CharacterController c;
    public float speed = 7f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    public Rigidbody player;

    Vector3 moveDir;

    public float sprintTime = 3;
    public float remainingTime;
    [SerializeField] int seconds;
    public Image stamBar;

    public float maxStam;
    public bool isReady = false;
    public bool start = true;

    private void Start()
    {
        remainingTime = sprintTime;
    }
    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKey(KeyCode.LeftShift)) && remainingTime > 0 && start)
        {
            speed = 20f;
            remainingTime -= Time.deltaTime;
            isReady = true;


        }
        else
        {
            isReady = false;
            if (remainingTime < 3 && isReady == false)
            {
                remainingTime += Time.deltaTime * 0.7f;
                start = false;
            }
            else
            {
                start = true;
            }
                speed = 7f;
        }
        stamBar.fillAmount = remainingTime / sprintTime;

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

            
        }

    }

}
