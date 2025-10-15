using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CoreLib
{
    public class SceneLoader : MonoBehaviour
    {
		[SerializeField] private string Scene;

        private void Start()
        {
            Addressables.LoadSceneAsync(Scene);
        }
    }
}