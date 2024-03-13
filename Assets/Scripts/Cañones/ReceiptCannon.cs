using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiptCannon : MonoBehaviour
{
    public Transform parent;
    public ManagementCañon cannon;    // valor que dicta si ya hay un cañon aqui, al inicio del turno 
    static ReceiptCannon where;       // valor que dicta donde esta el cañon seteado


    public void SetCannon(ManagementCañon newCannon) {
        if (cannon)
        {
            cannon.ShootUp(newCannon.GetDamage());
        }
        cannon = newCannon;
    }
    public void UnsetCannon() => cannon = null;

    public void UnsetReceipt() => where = null;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Canon"))
        {
            if (!where)
            {
                where = this;
                ManagementCañon managementCannon = other.GetComponent<ManagementCañon>();
                managementCannon.getDeployCannon().GetComponent<Transform>().parent = null;
                managementCannon.getCreateCannon().SetActive(false);
                managementCannon.getDeployCannon().SetActive(true);
                managementCannon.getDeployCannon().GetComponent<Transform>().position = parent.position;
                managementCannon.ToggleFindBarral();
                Debug.Log("stay");
                managementCannon.SetReceipt(this);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Canon"))
        {
            if (this == where)
            {
                where = null;
                ManagementCañon managementCannon = other.GetComponent<ManagementCañon>();
                managementCannon.getDeployCannon().GetComponent<Transform>().parent = other.transform;
                managementCannon.getCreateCannon().SetActive(true);
                managementCannon.getDeployCannon().SetActive(false);
                Debug.Log("exit");
                managementCannon.ToggleFindBarral();

            }

        }
    }
}
