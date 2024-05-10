using UnityEngine;

namespace SexyDu.PageViewSystem.Sample
{
    public class SamplePageRoot : MonoPageRoot
    {
        private void Awake()
        {
            RegisterPageRoot();

            home.Initialize();
        }

        private void OnDestroy()
        {
            UnregisterPageRoot();
        }

        [SerializeField] private SampleHome home;
    }
}