using UnityEngine;

namespace SexyDu.PageViewSystem
{
    /// <summary>
    /// MonoPage 관리 루트 클래스
    /// </summary>
    public abstract class MonoPageRoot : MonoBehaviour
    {
        [SerializeField] private Transform pageViewParent;

        private PageContentsHandler contentsHandler = new PageContentsHandler();
        public PageContentsHandler ContentsHandler { get { return contentsHandler; } }

        public virtual void RegisterPageRoot()
        {
            PageViewLoader.Instance.SetPageRoot(this);
        }

        public virtual void UnregisterPageRoot()
        {
            PageViewLoader.Instance.ReleasePageRoot(this);
        }

        public void Add(string resourcesPath, object arg = null)
        {
            ContentsHandler.Add(resourcesPath, arg, pageViewParent);
        }
    }
}