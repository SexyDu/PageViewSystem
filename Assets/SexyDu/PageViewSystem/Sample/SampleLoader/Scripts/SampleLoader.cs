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
            PageRoot.Add(MonoPageSampleA.ResourcePath, this.depth + 1);
        }

        public void OnClickSampleB()
        {
            PageRoot.Add(MonoPageSampleB.ResourcePath, new MonoPageSampleB.InitializeArgument(null, depth + 1, currentName));
        }
    }
}