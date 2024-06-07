using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Invector.vCharacterController;


public class gun : MonoBehaviour
{
    //public int damage;
    private float timeBetweenShooting = 1f, timeBetweenShots = 0.5f;
    public float spread, range, reloadTime;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold = true;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public LayerMask whatIsEnemy;
    public LayerMask whatIsRig;
    public GameObject bulletHoleGraphicEnemy;
    public GameObject bulletHoleGraphicRig;
    public GameObject muzzleFlash;
    public GameObject bulletPrefab;
    public TextMeshProUGUI ammoText;

    vThirdPersonController thirdPersonController;

    public TextMeshProUGUI outOfAmmoText;

    swinming Swinming;

    //private Animator animator;



    private void Awake()
    {
        //animator = GetComponent<Animator>();
        bulletsLeft = magazineSize;
        readyToShoot = true;

        outOfAmmoText.gameObject.SetActive(false);

        // Directly get the components since they are on the same GameObject
        thirdPersonController = GetComponent<vThirdPersonController>();
        Swinming = GetComponent<swinming>();

        // Tìm GameObject chứa vThirdPersonController
        GameObject thirdPersonControllerGO = GameObject.Find("Klee");
        GameObject Swingming1 = GameObject.Find("Klee");
        
        // Kiểm tra nếu tìm thấy
        if (thirdPersonControllerGO != null)
        {
            // Lấy component vThirdPersonController từ GameObject
            thirdPersonController = thirdPersonControllerGO.GetComponent<vThirdPersonController>();
        }
        if (Swingming1 != null)
        {
            Swinming = Swingming1.GetComponent<swinming>();
        }
        else
        {
            // Xử lý khi không tìm thấy
            Debug.LogError("Không tìm thấy vThirdPersonController GameObject.");
        }
    }

    void Update()
    {
        HandleInput();
        ammoText.SetText(bulletsLeft + "/" + magazineSize);

        if (bulletsLeft == 0 && !reloading)
        {
            outOfAmmoText.gameObject.SetActive(true);
            Swinming.offrunR();
        }
    }

    private void HandleInput()
    {
        // Kiểm tra input di chuyển từ bàn phím
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        thirdPersonController.UpdateMovementState(movementInput);

        // Kiểm tra input bắn
        shooting = allowButtonHold ? Input.GetKey(KeyCode.Mouse0) : Input.GetKeyDown(KeyCode.Mouse0);
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
            Reload();

        // Chỉ bắn khi đã sẵn sàng và đang bắn
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = true;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.LookRotation(direction));
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        // bulletScript.damage = damage;
        bulletScript.whatIsEnemy = whatIsEnemy;
        bulletScript.whatIsRig = whatIsRig;
        bulletScript.bulletHoleGraphicEnemy = bulletHoleGraphicEnemy;
        bulletScript.bulletHoleGraphicRig = bulletHoleGraphicRig;

        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        Destroy(bullet, 3f);
        Destroy(bulletScript, 1f);

        bulletsLeft--;
        bulletsShot--;
        thirdPersonController.RotateToCameraDirection(fpsCam.transform.forward);

        // Wait for timeBetweenShots before setting readyToShoot to true again
        Invoke("ResetShot", timeBetweenShots);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
        else
            readyToShoot = true;
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
        outOfAmmoText.gameObject.SetActive(false);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

}
