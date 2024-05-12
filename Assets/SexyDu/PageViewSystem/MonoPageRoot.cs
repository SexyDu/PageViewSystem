using UnityEngine;

namespace SexyDu.PageViewSystem
{
    /// <summary>
    /// MonoPage 관리 루트 클래스
    /// </summary>
    public abstract class MonoPageRoot : MonoBehaviour
    {
        // MonoPage 부모 Transform
        [SerializeField] private Transform pageViewParent;

        // PageContent 관리
        private PageContentsHandler contentsHandler = new PageContentsHandler();
        public PageContentsHandler ContentsHandler { get { return contentsHandler; } }

        /// <summary>
        /// 메인 PageRoot 등록
        /// </summary>
        public virtual void RegisterPageRoot()
        {
            PageViewLoader.Instance.SetPageRoot(this);
        }

        /// <summary>
        /// 메인 PageRoot 해제
        /// </summary>
        public virtual void UnregisterPageRoot()
        {
            PageViewLoader.Instance.ReleasePageRoot(this);
        }

        /// <summary>
        /// 핸들러에 PageContent 추가
        /// </summary>
        public void Add(string resourcesPath, object arg = null)
        {
            ContentsHandler.Add(resourcesPath, arg, pageViewParent);
        }
    }
}