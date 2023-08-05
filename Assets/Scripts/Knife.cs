using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float moveY = 250f;
    [SerializeField] private float moveZ = -125f;

    private int knifeStatus = 0;
    private bool rotating = false;
    private bool playing = false;
    private float rotateTimes = 0;

    private GameManager gameManager;
    private Animator anim;
    private Rigidbody rb;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!playing) return;
            Move();
            Rotate();
            gameManager.MoveSound();
        }
    }

    private void Move()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(0, moveY, moveZ);
    }

    private void Rotate()
    {
        anim.speed = 3f;
        rotating = true;
        rotateTimes = knifeStatus == 0 ? 1 : 2;
    }

    private void CheckRotation()
    {
        rotateTimes -= 1;
        if(rotateTimes == 0)
        {
            rotating = false;
            anim.speed = 1f;
        }
    }

    public void Stop()
    {
        anim.speed = 0f;
        Invoke("Play", 0.1f);
    }

    public void Play()
    {
        anim.speed = 1f;
    }

    public void FlipStatus(int status)
    {
        knifeStatus = status;
        if(rotating) CheckRotation();
    }

    public void SetKnifeStatus(bool value)
    {
        if(!playing && !value) return;
        playing = value;
        rb.isKinematic = false;
        if(value)
        {
            Move();
            Rotate();
            gameManager.MoveSound();
        }
        else
        {
            Destroy(anim);
            rb.constraints = RigidbodyConstraints.None;
            GameObject.FindGameObjectWithTag("FIXED").SetActive(false);
            GameObject.FindGameObjectWithTag("FIXED").SetActive(false);
        }
    }
    public void Lose()
    {
        if(!playing) return;
        SetKnifeStatus(false);
    }
}
