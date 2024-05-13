using UnityEngine;
using TMPro;

namespace SexyDu.PageViewSystem.Sample
{
    public class SampleLoader : MonoBehaviour
    {
        /// <summary>
        /// 현재 PageRoot
        /// </summary>
        private MonoPageRoot PageRoot { get { return PageViewLoader.Instance.Current; } }

        private string currentName = string.Empty;

        private const string DepthStringFormat = "- Depth : {0} -";
        private int depth = 0;
        [SerializeField] private TMP_Text textDepth;

        public SampleLoader SetDepth(int depth)
        {
            this.depth = depth;

            textDepth.text = string.Format(DepthStringFormat, this.depth);

            return this;
        }

        public SampleLoader SetCurrentName(string currentName)
        {
            this.currentName = currentName;

            return this;
        }

        public void OnClickSampleA()
        {
            // int 형 argument로 SampleA 추가(로드)
            PageRoot.Add(MonoPageSampleA.ResourcePath, depth + 1);
        }

        public void OnClickSampleB()
        {
            // class 형 argument로 SampleB 추가(로드)
            PageRoot.Add(MonoPageSampleB.ResourcePath, new MonoPageSampleB.InitializeArgument(null, depth + 1, currentName));
        }
    }
}