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
        private PageContentsHandler contentsHandler = null;
        public PageContentsHandler ContentsHandler { get { return contentsHandler; } }

        /// <summary>
        /// 초기 설정
        /// </summary>
        public virtual void Initialize()
        {
            if (contentsHandler == null)
            {
                // PageContentsHandler 생성
                contentsHandler = new PageContentsHandler();
            }
            else
            {
                Debug.LogWarning("이미 PageContentsHandler가 생성되어 있는데 Initialize가 호출되었습니다.");
            }
        }

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