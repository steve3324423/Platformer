using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
