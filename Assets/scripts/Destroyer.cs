using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public enum Type
    {
        death,
        defaultType,
        blast
    }
    public Type type;
    void Update()
    {
        switch (type)
        {
            case Type.death:
                Destroy(gameObject,0.3f);
                break;
            case Type.defaultType:
                Destroy(gameObject,6f);
                break;
            case Type.blast:
                Destroy(gameObject, 0.8f);
                break;
        }

    }
}
