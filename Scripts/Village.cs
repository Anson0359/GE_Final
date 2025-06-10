using NUnit.Framework;
using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private TextAsset talkContent = null;

    private void Init()
    {
        if (talkContent != null)
        {
            List player = JsonUtility.FromJson<List>(talkContent.text);

        }
    }
}
