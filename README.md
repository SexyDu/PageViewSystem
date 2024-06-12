# 유니티 PageViewSystem
* 무제한 페이지 Trace 시스템
* 유니티 내에서 여러 페이지(Prefab 등)를 서핑 해야하는 상황에서 로드된 소스/리소스가 증가함에 따른 성능 이슈 해결을 위해 고안된 방식

## 내용
* IMonoPage(샘플에선 class MonoPageView 사용)를 상속받아 구성된 페이지를 활성화된 MonoPageRoot(PageViewLoader.Current)에 로드<br>
* 지정된 수(PageContentsHandler.maxAlivePageViewCount)의 MonoPage만을 활성화하고 나머지는 해제(파괴)하여 메모리 관리
