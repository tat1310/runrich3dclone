using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public float speedMove = 5;
    public float speedTurn = 10;
    public Rigidbody rb;

    float horizontal;
    float demnguocdoichieu;
    private float rotateDir;
    private Quaternion rotation = Quaternion.identity;

    private float timestop = 0.2f;
    private float timetangtoc = 1f;
    private float newspeedmove;
    private bool run;
    private bool tangtoc;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        demnguocdoichieu = Random.Range(0f, 4f);
        Debug.Log(demnguocdoichieu);
        newspeedmove = speedMove;
        run = true;
        tangtoc = false;
    }
    private void FixedUpdate()
    {
        timestop -= Time.deltaTime;
        timetangtoc -= Time.deltaTime;
        if (timestop < 0 && run == false)
        {
            run = true;
            newspeedmove = speedMove;
        }
        if (timetangtoc < 0 && tangtoc == true)
        {
            tangtoc = false;
            newspeedmove = speedMove;
            //Debug.Log("Quay lai toc do ban dau");
        }
        Vector3 moveForward = transform.forward * newspeedmove * Time.fixedDeltaTime;
        Vector3 moveHorizontal = transform.right * horizontal * speedTurn * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveForward + moveHorizontal);
    }
    private void Update()
    {
        AImoveBOT();   

        rotation = Quaternion.Euler(0, transform.rotation.y + (rotateDir), 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }
    private void AImoveBOT()
    {
        if(demnguocdoichieu > 2.5f)
        {
            horizontal = 1;
            demnguocdoichieu -= Time.deltaTime;
            if (demnguocdoichieu < 0f)
            {
                demnguocdoichieu = Random.Range(0f, 4f);
            }
        }
        if (demnguocdoichieu <= 2.5f && demnguocdoichieu >= 1.5f)
        {
            horizontal = 0;
            demnguocdoichieu -= Time.deltaTime;
            if (demnguocdoichieu < 0f)
            {
                demnguocdoichieu = Random.Range(0f, 4f);
            }
        }
        if (demnguocdoichieu < 1.5f)
        {
            horizontal = -1;
            demnguocdoichieu -= Time.deltaTime;
            if (demnguocdoichieu < 0f)
            {
                demnguocdoichieu = Random.Range(0f, 4f);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "quay phai")
        {
            rotateDir = rotateDir + 90;
        }
        if (other.tag == "quay trai")
        {
            rotateDir = rotateDir - 90;
        }
    }
    public void chamchuongngaivat(float speed)
    {
        newspeedmove = speed;
        timestop = 0.2f;
        run = false;
    }
    public void itemspeed(float speed)
    {
        newspeedmove = speed;
        timetangtoc = 1f;
        tangtoc = true;
    }
}
