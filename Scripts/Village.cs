using NUnit.Framework;
using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private TextAsset talkContent = null;

    public void Init()
    {
        if (talkContent != null)
        {
            List player = JsonUtility.FromJson<List>(talkContent.text);

        }
    }
}
