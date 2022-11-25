using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCamera : MonoBehaviour
{
    [SerializeField] float runSpeed = 100;
    [SerializeField] float rotationSpeed = 3;
    [SerializeField] Animator anim;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody rb;
    [SerializeField] float range = 5f;

    

    private float _horizontalMove;
    private float _verticalMove;
    private Rigidbody _rigidbody;
    private bool _canJump = false;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        JumpTwo();
        //&& _canJump == true)
      //  if (Input.GetKeyDown(KeyCode.Space)) 
       // {
           // Jump();
       // }
    }
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(_horizontalMove, 0, _verticalMove);

        transform.Translate(dir * Time.deltaTime * runSpeed);
        // rb.AddForce(dir * runSpeed);
        

        SetAnimationsParameters();
    }

    private void SetAnimationsParameters()
    {
        anim.SetFloat("VelX", _horizontalMove);
        anim.SetFloat("VelY", _verticalMove);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.layer == 11)
        {
            _canJump = true;
            Debug.Log("Tocando el piso");
        }      
    }   

    private void OnTriggerExit(Collider col)
    {
        if (col.transform.gameObject.layer == 11)
        {
            _canJump = false;
        }
    }

    private void JumpTwo()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.forward, out hit, range))
        {
            if (Input.GetKey(KeyCode.Space) && _canJump == true)
            {
                Jump();
            }            
        }
    }
}
