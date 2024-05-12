using UnityEngine;

namespace SexyDu.PageViewSystem.Sample
{
    public class SampleHome : MonoBehaviour, IObserverContentsCount
    {
        private MonoPageRoot PageRoot { get { return PageViewLoader.Instance.Current; } }

        public void Initialize()
        {
            // 옵저버 등록
            PageRoot.ContentsHandler.Subscribe(this);

            SetActive(PageRoot.ContentsHandler.Count);
        }

        private void OnDestroy()
        {
            // 옵저버 해제
            PageRoot.ContentsHandler.Unsubscribe(this);
        }

        public void OnContentsCountChanged(int count)
        {
            Debug.LogFormat("활성화 MonoPage 수 : {0}", count);

            SetActive(count);
        }

        #region ObjectCaches
        [SerializeField] private GameObject gameObjectCache;
        private GameObject GameObjectCache { get { return gameObjectCache; } }

        private void SetActive(bool active)
        {
            GameObjectCache.SetActive(active);
        }

        private void SetActive(int pageCount)
        {
            SetActive(pageCount.Equals(0));
        }
        #endregion
    }
}