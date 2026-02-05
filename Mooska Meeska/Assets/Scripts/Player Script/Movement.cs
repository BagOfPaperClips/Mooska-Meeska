using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController c;
    public float speed = 7f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    public Rigidbody player;

    Vector3 moveDir;

    //DASH SECTION
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 1000f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    // Update is called once per frame
    void Update()
    {
        
        if (isDashing)
        {
            return;
        }

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

            if ((Input.GetKeyDown(KeyCode.LeftShift) && canDash) || (Input.GetKeyDown(KeyCode.LeftShift) && canDash))
            {
                StartCoroutine(Dash());
            }
        }

    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        Debug.Log(moveDir);
        c.Move(moveDir * 100f * Time.deltaTime);

        yield return new WaitForSeconds(dashingTime);
        isDashing = false;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
