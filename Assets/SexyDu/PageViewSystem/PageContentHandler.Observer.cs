using System.Collections.Generic;

namespace SexyDu.PageViewSystem
{
    /// <summary>
    /// PageContent 스택 기반 리스트 관리
    /// * PageContent 생성 및 제거에 따른 리스트 변경사항 서브젝트
    /// </summary>
    public partial class PageContentsHandler : ISubjectContentsCount
    {
        // PageContent 수 변경(생성/제거) 옵저버
        private List<IObserverContentsCount> observers = new List<IObserverContentsCount>();

        /// <summary>
        /// 옵저버 등록
        /// </summary>
        public void Subscribe(IObserverContentsCount observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }
        /// <summary>
        /// 옵저버 해제
        /// </summary>
        public void Unsubscribe(IObserverContentsCount observer)
        {
            observers.Remove(observer);
        }
        /// <summary>
        /// 페이지 수 옵저버에 노티
        /// </summary>
        private void NotifyContentsCount()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].OnContentsCountChanged(Count);
            }
        }
    }
}