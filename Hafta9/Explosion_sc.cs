using UnityEngine;

public class Explosion_sc : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }
}
