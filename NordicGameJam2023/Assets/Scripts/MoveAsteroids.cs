using UnityEngine;

public class MoveAsteroids : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Planet")
        {
            
            Destroy(this.gameObject);
        }
    }
}
