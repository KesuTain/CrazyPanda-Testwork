using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Patron patron;
    [SerializeField] private Transform head;
    [SerializeField] private Transform tail;
    [SerializeField] private float powerOfShoot = 5f;
    public void Shoot()
    {
        Patron patronObj = Instantiate(patron, null, true);
        patronObj.transform.position = transform.position;

        Vector2 direction = head.transform.position - tail.transform.position;
        patronObj.RigidbodyItem.AddForce(direction * powerOfShoot, ForceMode2D.Impulse);
    }
}
