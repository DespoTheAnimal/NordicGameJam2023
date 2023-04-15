using UnityEngine;

public class MoveAsteroids : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Planet")
        {
            collision.gameObject.GetComponent<MeteorScript>().instantiatedAsteroids.Clear();
            Destroy(this.gameObject);
        }
    }
}
