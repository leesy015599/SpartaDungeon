# SpartaDungeon

## 1. 프로젝트 설명
> 필수 요구사항을 기본으로 하되 추후에 확장할 가능성을 고려해 설계

### 1) 클래스 구조

<img width="948" alt="스크린샷 2023-08-23 오후 12 05 47" src="https://github.com/leesy015599/SpartaDungeon/assets/67689113/372bb07a-dcd3-4823-8363-f019e427a2e3">

a. Program
  - 메인 함수가 포함된, 프로그램 전체 루프가 돌아가는 과정을 담은 클래스.
  - 루프 실행 전 초기화 및 디폴트 값 설정. 이 때 기본 캐릭터와 기본 아이템 목록이 생성된다.

b. Page
  - 페이지의 공통적인 레이아웃에 대한 정보를 담은 클래스.
  - 어떤 페이지인지 타입에 따라 페이지 내용을 설정함.
  - `enum TypeName` 으로 페이지 타입을 분류한다.
    - Main, Status, Inventory, Equipment

c. Option
  - 선택지 문자열과 해당 선택지에 대한 결과를 포함하는 클래스.
  - `enum TypeName` 으로 선택지 타입을 분류한다.
    - Main, Status, Inventory, Equipment, GameOver, PreviousPage


d. Character
  - 캐릭터의 정보 (레벨, 이름, 직업, 공격력, 방어력, 체력, 소지금, 보유중인 아이템 리스트)
  - `struct OwnItemInfo` 으로 보유중인 아이템의 정보를 나타낸다.
    - `int itemNum`, `bool isEquipped`
    - 이 구조체의 리스트로 보유중인 아이템들을 캐릭터 필드에 포함한다.
  - 아이템 자체를 포함하지 않고 게임 내 아이템 리스트에 `itemNum`으로 접근한다.

e. Item
  - 아이템의 정보 (아이템 번호, 이름, 공격력, 체력, 가격, 설명)

f. ConsoleIO
  - 콘솔 입출력을 담당하는 클래스.
  - 결국 페이지를 보여주는 것이기 때문에 `class Page`에 의존성이 있다.


### 2) 프로그램 전체 흐름 설명

<img width="734" alt="스크린샷 2023-08-22 오후 8 36 33" src="https://github.com/leesy015599/SpartaDungeon/assets/67689113/59caae91-2b68-4d78-b0ee-8098721273db">

#### (1) 프로그램 시작 및 루프 시작

a. `Initialize()` → `history.Push(current.Page)`
* 이 프로그램은 `int currentPageType` 이라는 변수를 `(int)Page.TypeName.Main`으로 초기화한 상태에서 시작한다. 매 루프마다 이 변수를 확인해서 해당하는 페이지를 출력한다.
* `Initialize()` 에서 해당 작업 및 기타 초기화(기본 캐릭터, 아이템 리스트)를 한다.
* 현재 페이지가 세팅되었으므로 페이지 내역을 저장하는 스택인 `history`에 현재 페이지를 푸쉬한다.

b. `WritePage()`
* 현재 페이지에 해당하는 내용을 출력한다.
  * 모든 페이지의 기본 레이아웃이 동일하기 때문에 순서는 다음과 같다
  * 지금까지의 히스토리 출력 → 현재 페이지 정보 출력 → 페이지 내용 출력(페이지 타입에 따라 달라짐) → 선택지 출력

c. `ReadInput()` → `IsProperInput()`
* 콘솔에서 입력을 받는다
* 현재 페이지의 선택지 개수를 범위로 적절한 입력값인지 확인한다.
* 적절한 입력값이 나올 때 까지 `ReadInput()`으로 돌아간다.

#### (2) 분기점 `Option == PrevPage`
* 현재 사용자가 입력한 선택지가 `이전 페이지로 가기` 일 경우이다.

a. `history.Pop()`
  * 우선 현재 페이지에서 빠져나오기 때문에 히스토리에서 제거한다.

b. `set currentPage = history.Peek()`
  * 히스토리에서 현재 페이지 제거 후 최상단의 element를 확인하면 이전 페이지를 알 수 있다. 이전 페이지가 다음 루프의 현재 페이지가 될 수 있도록 `currentPage = history.Peek()` 으로 값을 할당해준다.

c. `history.Pop()`
  * 메인 루프는 언제나 현재 페이지를 히스토리에 추가하며 시작된다.
  * 하지만 현재 history의 최상단 element는 이전페이지인 상태
  * 이 상태에서 그대로 진행하면 이전페이지가 연달아 두 번 푸쉬된다. 이를 처리하기 위해 한번 더 `history.Pop()`

#### (3) 분기점  `Option == GoPage`
* 현재 사용자가 입력한 선택지가 `특정 페이지로 가기` 일 경우이다.
* 상위 페이지에서 하위 페이지로 갈 경우에 해당한다. (history가 쌓이는 경우)

#### (3)-1 '다른 페이지로 이동'일 경우
* 위 Flow chart에서의 `(current == Equip) && (option == Equip)` 이 no(false)일 경우이다.
* `set currentPage = optionPage`
  * 단순히 다음 페이지 타입에 해당하는 값을 할당하고 다음 루프로 넘어가면 된다.
#### (3)-2 '같은 페이지로 이동'일 경우
* 위 Flow chart에서의 `(current == Equip) && (option == Equip)` 이 yes(true)일 경우이다.
* '장착 관리 페이지'에서 '장착 관리 페이지'로 이동, 다시 말해 '새로고침'의 역할을 한다.
* 장착 관리 페이지의 선택지에는 아이템이 포함되어 있다. 해당 아이템을 선택할 때 마다 탈착 여부를 설정할 수 있는데, 그 때 마다 페이지를 새로고침해서 콘솔에 업데이트 내용을 표시할 수 있다.
* `history.Pop()`
  * 이미 히스토리 최상단이 '장착관리'인 상태에서 다시 루프로 돌아가면 연달아 푸쉬된다. 이를 처리하기 위해 스택 팝으로 삭제해준다.

