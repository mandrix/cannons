using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementCañon : MonoBehaviour
{
    private Vector3 mousePosition;
    private bool findBarral = false;
    public bool isSetCannon = false;
    public GameObject deployCannon;
    public GameObject createCannon;
    public GameObject shootPrefab;
    public Transform shootPoint;
    private GameManager manager;
    public float shootSpeed = 10f;
    public int damage = 1;
    public ReceiptCannon receipt;
    public Transform center;

    public void ShootUp(int up) {
        damage += up;
    }

    public void Shoot()
    {
        //deployCannon.GetComponentInChildren
        GameObject newShoot = Instantiate(shootPrefab, shootPoint.position, shootPoint.rotation);

        Rigidbody balaRigidbody = newShoot.GetComponent<Rigidbody>();

        balaRigidbody.velocity = shootPoint.forward * shootSpeed;
    }

    public void SetManager(GameManager newManager) => manager = newManager;

    public void SetCenter(Transform newCenter) => center = newCenter;

    public void SetReceipt(ReceiptCannon newReceipt) => receipt = newReceipt;

    public int GetDamage() => damage;

    public GameObject getDeployCannon() {
        return deployCannon;
    }

    public GameObject getCreateCannon()
    {
        return createCannon;
    }

    public void SetPositionCañon(Transform center)
    {
        transform.position = center.position;
    }
    public void CenterCannon() {
        SetPositionCañon(center);
    }
    public void UnsetCannon() => isSetCannon = false;

    public void SetCannon() => isSetCannon = true;
    public void ToggleFindBarral() => findBarral = !findBarral ;


    private Vector3 MousePos => Camera.main.WorldToScreenPoint(transform.position);

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - MousePos;
    }

    private void OnMouseDrag()
    {
        if (isSetCannon)
        {
            return;
        }
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        
    }

    private void OnMouseUp()
    {
        if (findBarral && receipt)
        {
            receipt.UnsetReceipt();
            receipt.SetCannon(this);
            manager.GameFlow2();
        }
        else
        {
            CenterCannon();
        }
    }
}
