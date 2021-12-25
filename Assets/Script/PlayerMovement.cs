using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speedMove = 5;
    public float speedTurn = 10;

    private float horizontal;
    private float rotateDir;
    private Quaternion rotation = Quaternion.identity;

    private float timestop = 0.2f;
    private float timetangtoc = 1f;
    private float newspeedmove;
    private bool run;
    private bool tangtoc;

    private Animator animator;

    public static int sovang;
    public Text scoreText;

    public AudioSource coinsound;
    public AudioSource itemsound;

    public GameObject effectItem;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sovang = 0;
        newspeedmove = speedMove;
        run = true;
        tangtoc = false;
    }
    private void FixedUpdate()
    {
        timestop -= Time.deltaTime;
        timetangtoc -= Time.deltaTime;
        if(timestop < 0 && run == false)
        {
            run = true;
            newspeedmove = speedMove;
            animator.SetBool("isIdle", false);
        }
        if(timetangtoc < 0 && tangtoc == true)
        {
            tangtoc = false;
            animator.SetBool("isWalk", true);
            newspeedmove = speedMove;
            Debug.Log("Quay lai toc do ban dau");
        }
        Vector3 moveForward = transform.forward * newspeedmove * Time.fixedDeltaTime;
        Vector3 moveHorizontal = transform.right * horizontal * speedTurn * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveForward + moveHorizontal);
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        rotation = Quaternion.Euler(0, transform.rotation.y + rotateDir, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);

        scoreText.text = "" + PlayerMovement.sovang;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "quay phai")
        {
            rotateDir = rotateDir + 90;
        }
        if (other.tag == "quay trai")
        {
            rotateDir = rotateDir - 90;
        }
        if (other.tag == "coin")
        {
            coinsound.Play();
        }
        if (other.tag == "item")
        {
            itemsound.Play();
            if(effectItem != null)
            {
                Instantiate(effectItem, transform.position, Quaternion.identity);
            }
        }
    }
    public void chamchuongngaivat(float speed)
    {   
        newspeedmove = speed;
        timestop = 0.2f;
        run = false;
        animator.SetBool("isIdle", true);
    }
    public void itemspeed(float speed)
    {
        newspeedmove = speed;
        timetangtoc = 1f;
        tangtoc = true;
        animator.SetBool("isWalk", false);
    }
}
