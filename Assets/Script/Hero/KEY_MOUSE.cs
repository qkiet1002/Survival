using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swinming : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private bool isSwimming = false;
    private float waterLevel = 4.4f;
    [SerializeField]private float buoyancy = 1.5f; // Điều chỉnh lực nổi
    [SerializeField] private float maxBuoyancy = 1.2f; // Lực nổi tối đa
    [SerializeField] private float minBuoyancy = 0.5f; // Lực nổi tối thiểu

    public HPHERO Thanhmau;
    [SerializeField] private float thisHP;
    [SerializeField] private float MaxHP = 100;

    bool isMousePressed = true; //Input.GetMouseButton(0);





    void Start()
    {
        thisHP = MaxHP;
        Thanhmau.UpdateHP(thisHP, MaxHP);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }





    void Update()
    {
        if (transform.position.y <= waterLevel && !isSwimming)
        {
            StartSwimming();
        }
        else if (transform.position.y > waterLevel && isSwimming)
        {
            StopSwimming();
        }

        if (isSwimming)
        {
            ApplyBuoyancy();
        }

       // animationgun();

        HandleInput();
    }
    
    public void TakeDamage(int amout)
    {
        thisHP -= amout;
        Thanhmau.UpdateHP(thisHP, MaxHP);
    }


    /*
    public void animationgun() {
        // Kiểm tra nếu nút chuột trái được bấm
        bool isMousePressed = Input.GetMouseButton(0);
        // Kiểm tra nếu các nút W, A, S, D được bấm
        bool isWPressed = Input.GetKey(KeyCode.W);
        bool isSKey = Input.GetKey(KeyCode.S);
        bool isAKey = Input.GetKey(KeyCode.A);
        bool isDKey = Input.GetKey(KeyCode.D);
        //nhay ban
        bool isjumprun = Input.GetKey(KeyCode.Space);
        
        if (isMousePressed)
        {
            animator.SetBool("gun", true);
        }
        else if (!isMousePressed)
        {
            animator.SetBool("gun", false);
        }
        //KEY A
        if (isAKey && isMousePressed)
        {
            animator.SetBool("gun", false);
            // Chuyển sang animation đặc biệt
            animator.SetBool("runleft_gun", true);
        }
        if (!isMousePressed || !isAKey)
        {
            animator.SetBool("runleft_gun", false);
        }

        //KEY D
        if (isDKey && isMousePressed)
        {
            animator.SetBool("gun", false);
            // Chuyển sang animation đặc biệt
            animator.SetBool("runright_gun", true);
        }
        if (!isMousePressed || !isDKey)
        {
            animator.SetBool("runright_gun", false);
        }

        //key S
        //chuot trai va nut S
        if (isSKey && isMousePressed)
        {
            animator.SetBool("gun", false);
            // Chuyển sang animation đặc biệt
            animator.SetBool("backrun_gun", true);
        }
        if (!isMousePressed || !isSKey)
        {
            animator.SetBool("backrun_gun", false);
        }

        //KEY W

        // Nếu nút chuột trái và  nút W
        if (isWPressed && isMousePressed)
        {
            animator.SetBool("gun", false);
            // Chuyển sang animation đặc biệt
            animator.SetBool("run_gun", true);
        }
        if (!isMousePressed || !isWPressed)
        {
            animator.SetBool("run_gun", false);
        }
    }*/

    public void offrunR()
    {
        
        animator.SetBool("gun", false);
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("attack");
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("gun", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("gun", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isSwimming = true;
            animator.SetBool("isSwimming", true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isSwimming = false;
            animator.SetBool("isSwimming", false);

            // Nếu cần thêm logic khi rời khỏi nước
        }
    }

    void StartSwimming()
    {
        isSwimming = true;
        animator.SetBool("isSwimming", true);
        //animator.Play("SwimmingAnimation", 0, 0f);
        rb.useGravity = false;
    }

    void StopSwimming()
    {
        isSwimming = false;
        animator.SetBool("isSwimming", false);
        rb.useGravity = true;
    }
    void ApplyBuoyancy()
    {
        // Tính khoảng cách từ mức nước đến vị trí của nhân vật
        float depth = waterLevel - transform.position.y;

        // Điều chỉnh lực nổi dựa trên độ sâu
        float adjustedBuoyancy = Mathf.Clamp(buoyancy + (depth*0.55f), minBuoyancy, maxBuoyancy);

        // Tạo lực nổi hướng lên
        Vector3 buoyancyForce = -Physics.gravity * adjustedBuoyancy;

        // Áp dụng lực nổi
        rb.AddForce(buoyancyForce, ForceMode.Acceleration);
    }
}
