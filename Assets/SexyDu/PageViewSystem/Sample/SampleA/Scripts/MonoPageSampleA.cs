using UnityEngine;

namespace SexyDu.PageViewSystem.Sample
{
    public class MonoPageSampleA : MonoPageView
    {
        #region MonoPageView
        public const string ResourcePath = "MonoPage/SampleA";

        public override IMonoPage Initialize(object arg = null)
        {
            if (arg is int)
                Initialize((int)arg);
            else
                Initialize();

            return this;
        }

        private void Initialize(int depth)
        {
            sampleLoader.SetDepth(depth).SetCurrentName("SampleA");

            Initialize();
        }

        private void Initialize()
        {
            Debug.Log("MonoPageSampleA Complete initialization");
        }

        public override void Clear()
        {
            Debug.Log("MonoPageSampleA Clear (Release memories)");
        }
        #endregion

        [Header("SampleA")]
        [SerializeField] private SampleLoader sampleLoader;

        public void GoToHome()
        {
            PageViewLoader.Instance.Current.ContentsHandler.RemoveAll();
        }
    }
}