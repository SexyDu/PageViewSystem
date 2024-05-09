#define USE_IMONOPAGE

using System;

namespace SexyDu.PageViewSystem
{
#if USE_IMONOPAGE
    public interface IMonoPage
    {
        /// <summary>
        /// MonoPage 초기 설정 함수
        /// </summary>
        /// <param name="arg">MonoPage 구성을 위해 필요한 argument</param>
        /// <returns></returns>
        public IMonoPage Initialize(object arg = null);

        /// <summary>
        /// 클리어(메모리 해제 등) 함수
        /// </summary>
        public void Clear();

        /// <summary>
        /// MonoPage 파괴
        /// </summary>
        public void Destroy();

        /// <summary>
        /// MonoPage 종료
        /// </summary>
        public void Close();

        // MonoPage 종료 이벤트
        public Action OnClosed { set; }

        /// <summary>
        /// MonoPage 활성화 설정 함수
        /// </summary>
        public void SetActive(bool active);
    }
#endif

    /// <summary>
    /// PageContent가 제거될 때 제거를 요청하는 인터페이스
    /// * PageContent가 그룹(리스트) 형식으로 관리되는 경우 그룹상 제거를 위해
    /// </summary>
    public interface IPageContentRemoveReceiver
    {
        public void Remove(PageContent content);
    }

    /// <summary>
    /// [Observer] PageConent 활성화 수 변경
    /// </summary>
    public interface IObserverContentsCount
    {
        public void OnContentsCountChanged(int count);
    }

    /// <summary>
    /// [Subject] PageContent 활성화 수 변경
    /// </summary>
    public interface ISubjectContentsCount
    {
        public int Count { get; }
        public void Subscribe(IObserverContentsCount observer);
        public void Unsubscribe(IObserverContentsCount observer);
    }
}