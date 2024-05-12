#define USE_IMONOPAGE

using System.Collections.Generic;
using UnityEngine;

namespace SexyDu.PageViewSystem
{
    /// <summary>
    /// PageContent 스택 기반 리스트 관리
    /// </summary>
    public class PageContentsHandler : IPageContentRemoveReceiver, ISubjectContentsCount
    {
        // 한번에 살아있을 수 있는 최대 PageView 수
        private const int MaxAlivePageViewCount = 5;

        // 생성된 PageContent 리스트
        private List<PageContent> contents = new List<PageContent>();
        // 리스트의 마지막 인덱스
        private int lastIndex { get { return Count - 1; } }

        // 현재 활성화 PageContent
        public PageContent Current
        {
            get
            {
                if (Count.Equals(0))
                    return null;
                else
                    return contents[lastIndex];
            }
        }

        #region Subject - ISubjectContentsCount
        private List<IObserverContentsCount> observers = new List<IObserverContentsCount>();

        public int Count { get { return contents.Count; } }
        public void Subscribe(IObserverContentsCount observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }
        public void Unsubscribe(IObserverContentsCount observer)
        {
            observers.Remove(observer);
        }

        private void NotifyContentsCount()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].OnContentsCountChanged(Count);
            }
        }
        #endregion

        /// <summary>
        /// PageContent 추가
        /// </summary>
        public void Add(PageContent content)
        {
            if (content != null)
            {
                InactiveLastestPageView();

                content.SetRemoveReceiverInterface(this);
#if USE_IMONOPAGE
                content.LoadMonoPage();
#else
                content.LoadPageView();
#endif

                contents.Add(content);

                ActiveLastestPageView();

                DestroyLegacyPageView();

                NotifyContentsCount();
            }
        }

        /// <summary>
        /// PageContent 추가
        /// </summary>
        /// <param name="resourcesPath">MonoPage 리소스 경로</param>
        /// <param name="arg">MonoPage 초기설정 argument</param>
        /// <param name="parent">MonoPage 부모 Transform</param>
        public void Add(string resourcesPath, object arg = null, Transform parent = null)
        {
            Add(Create(resourcesPath, arg, parent));
        }

        /// <summary>
        /// PageContent 생성
        /// </summary>
        /// <param name="resourcesPath">MonoPage 리소스 경로</param>
        /// <param name="arg">MonoPage 초기설정 argument</param>
        /// <param name="parent">MonoPage 부모 Transform</param>
        /// <returns>생성된 PageContent</returns>
        private PageContent Create(string resourcesPath, object arg, Transform parent)
        {
            return new PageContent(resourcesPath, arg, parent);
        }

        /// <summary>
        /// 특정 PageContent 제거
        /// </summary>
        public void Remove(PageContent content)
        {
            contents.Remove(content);

            content.Dispose();

            ActiveLastestPageView();

            ReloadLagecyPageView();

            NotifyContentsCount();
        }

        /// <summary>
        /// 최근 PageContent 제거
        /// </summary>
        public void RemoveLastest()
        {
            if (Count > 0)
                Remove(contents[lastIndex]);
        }

        /// <summary>
        /// 전체 PageContent 제거
        /// </summary>
        public void RemoveAll()
        {
            for (int i = 0; i < contents.Count; i++)
            {
                contents[i].Dispose();
            }

            contents.Clear();

            NotifyContentsCount();
        }

        #region Handling PageView
        /// <summary>
        /// 최신 PageContent 활성화 처리
        /// </summary>
        private void ActiveLastestPageView()
        {
            // enable 상태에 따라 활성화 여부 결정
#if USE_IMONOPAGE
            if (Count > 0)
                contents[lastIndex].SetMonoPageActive(enable);
#else
            if (Count > 0)
                contents[lastIndex].SetPageViewActive(enable);
#endif

        }

        /// <summary>
        /// 최근 PageContent 비활성화
        /// </summary>
        private void InactiveLastestPageView()
        {
#if USE_IMONOPAGE
            if (Count > 0)
                contents[lastIndex].SetMonoPageActive(false);
#else
            if (Count > 0)
                contents[lastIndex].SetPageViewActive(false);
#endif
        }

        /// <summary>
        /// Stack상 오래된 PageContent의 MonoPage 파괴
        /// </summary>
        private void DestroyLegacyPageView()
        {
            int index = Count - 1 - MaxAlivePageViewCount;

#if USE_IMONOPAGE
            if (index >= 0)
                contents[index].DestoryMonoPage();
#else
            if (index >= 0)
                contents[index].DestoryPageView();
#endif
        }

        /// <summary>
        /// 파괴된 MonoPage 리로드
        /// </summary>
        private void ReloadLagecyPageView()
        {
            int index = Count - MaxAlivePageViewCount;

#if USE_IMONOPAGE
            if (index >= 0 && !contents[index].HasMonoPage)
                contents[index].LoadMonoPage(false);
#else
            if (index >= 0 && !contents[index].HasPageView)
                contents[index].LoadPageView(false);
#endif
        }
        #endregion
        
        #region Enable
        /// <summary>
        /// 핸들러를 통한 MonoPage 활성화 여부
        /// </summary>
        private bool enable = true;
        public bool Enable
        {
            get { return enable; }

            set
            {
                enable = value;

                ActiveLastestPageView();
            }
        }
        #endregion
    }
}