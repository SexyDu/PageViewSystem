namespace SexyDu.PageViewSystem
{
    /// <summary>
    /// PageView 구성에 필요한 데이터 기반 클래스
    /// </summary>
    public class InitializeArgumentBase
    {
        /// <summary>
        /// 이전 페이지에 대한 정보 (이름)
        /// </summary>
        private readonly string from = string.Empty;
        public string From { get { return from; } }

        public InitializeArgumentBase(string from)
        {
            this.from = from;
        }
    }
}