using System;

namespace SexyDu.PageViewSystem
{
    /// <summary>
    /// PageView 관리 싱글톤
    /// </summary>
    public sealed class PageViewLoader
    {
        #region Singleton
        private static readonly Lazy<PageViewLoader> instance = new Lazy<PageViewLoader>(() => new PageViewLoader());
        public static PageViewLoader Instance { get { return instance.Value; } }
        #endregion

        private MonoPageRoot current = null;
        public MonoPageRoot Current { get { return current; } }

        /// <summary>
        /// 현재 관리되는 PageRoot 설정
        /// </summary>
        public void SetPageRoot(MonoPageRoot pageRoot)
        {
            if (current != null)
            {
                UnityEngine.Debug.LogWarningFormat("이미 PageRoot({0})가 있지만 새로운 PageRoot({1})가 설정됩니다.",
                    current.name, pageRoot.name);
            }

            current = pageRoot;
        }

        /// <summary>
        /// 현재 관리되는 PageRoot 해제
        /// </summary>
        public void ReleasePageRoot(MonoPageRoot pageRoot)
        {
            if (current.Equals(pageRoot))
                current = null;
        }
    }
}