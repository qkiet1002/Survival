using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    vThirdPersonController thirdPersonController;
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonController = GetComponent<vThirdPersonController>();
        // Tìm GameObject chứa vThirdPersonController
        GameObject thirdPersonControllerGO = GameObject.Find("Klee");
       // GameObject Swingming1 = GameObject.Find("Klee");

        // Kiểm tra nếu tìm thấy
        if (thirdPersonControllerGO != null)
        {
            // Lấy component vThirdPersonController từ GameObject
            thirdPersonController = thirdPersonControllerGO.GetComponent<vThirdPersonController>();
        }

        else
        {
            // Xử lý khi không tìm thấy
            Debug.LogError("Không tìm thấy vThirdPersonController GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        thirdPersonController.UpdateMovementState(movementInput);
    }
}
