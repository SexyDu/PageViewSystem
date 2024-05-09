#define USE_IMONOPAGE

using System;

namespace SexyDu.PageViewSystem
{
#if USE_IMONOPAGE
    /// <summary>
    /// 생성된 GameObject에 있는 IMonoPage를 상속받은 Component가 없는 경우의 Exception
    /// </summary>
    public class NotImplementedMonoPageException : Exception
    {
        private const string DefaultExceptionMessage = "NotImplementedMonoPageException : Resource에서 IMonoPage(interface) Component를 찾을 수 없습니다.";

        public NotImplementedMonoPageException() : base(DefaultExceptionMessage) { }

        public NotImplementedMonoPageException(string message) : base(message) { }
    }

    public class NotFoundMonoPageResourceException : Exception
    {
        private const string DefaultExceptionMessage = "NotFoundMonoPageResourceException : 지정된 경로에서 리소스를 찾을 수 없습니다. [Resources.Load]";

        public NotFoundMonoPageResourceException() : base(DefaultExceptionMessage) { }

        public NotFoundMonoPageResourceException(string message) : base(message) { }
    }
#else
    /// <summary>
    /// 생성하려는 MonoPageView(Prefab)을 찾지 못한 경우의 Exception
    /// </summary>
    public class NotFoundPageViewException : Exception
    {
        private const string DefaultExceptionMessage = "NotFoundPageViewException : Not found 'MonoPageView' resource [Resources.Load]";

        public NotFoundPageViewException() : base(DefaultExceptionMessage) { }

        public NotFoundPageViewException(string message) : base(message) { }
    }
#endif
}