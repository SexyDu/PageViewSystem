using UnityEngine;

namespace SexyDu.PageViewSystem.Sample
{
    public class MonoPageSampleB : MonoPageView
    {
        #region MonoPageView
        public const string ResourcePath = "MonoPage/SampleB";

        public override IMonoPage Initialize(object arg = null)
        {
            // InitializeArgument 사용 예시
            if (arg is InitializeArgument)
                Initialize(arg as InitializeArgument);
            else if (arg is int)
                Initialize((int)arg);
            else
                Initialize();

            return this;
        }

        private void Initialize(InitializeArgument arg)
        {
            // InitializeArgument를 통해 전달받은 데이터를 활용헤 페이지 구성 가능
            Debug.LogFormat("MonoPageSampleB Call from {0}", arg.From);

            Initialize(arg.Depth);
        }

        private void Initialize(int depth)
        {
            sampleLoader.SetDepth(depth).SetCurrentName("SampleB"); ;

            Initialize();
        }

        private void Initialize()
        {
            Debug.Log("MonoPageSampleB Complete initialization");
        }

        public override void Clear()
        {
            Debug.Log("MonoPageSampleB Clear (Release memories)");
        }
        #endregion

        [Header("SampleB")]
        [SerializeField] private SampleLoader sampleLoader;

        public void GoToHome()
        {
            PageViewLoader.Instance.Current.ContentsHandler.RemoveAll();
        }

        #region InitializeArgument
        /// <summary>
        /// MonoPageSampleB 초기설정 사용 데이터 클래스
        /// </summary>
        public class InitializeArgument : InitializeArgumentBase
        {
            private readonly object someObject;
            private readonly int depth = 0;

            public object SomeObject { get { return someObject; } }
            public object Depth { get { return depth; } }

            public InitializeArgument(object someObject, int depth, string from) : base(from)
            {
                this.someObject = null;
                this.depth = depth;
            }
        }
        #endregion
    }
}