# Preliminary Flowchart — Library Management System (Course 2)

**Project:** `C2_Master-Assignment-Report .txt` — Final Project (Part 4 build on top of the Part 3 optimized base)
**Reference style:** `JD_Warehouse_v8__Flowchart.png` (Course 1 capstone flowchart conventions)
**Status:** Preliminary — drafted before code is written, to plan control flow ahead of implementation. Not yet verified against final code line numbers.

---

## Scope

This flowchart covers the three graded features from the Master Assignment Report (15 pts total), layered onto the existing Part 3 base (5 fixed-slot book variables, `add`/`remove`/`exit` loop):

| Feature | Points | Requirement |
|---|---|---|
| Search | 5 | Prompt for a title; report found/not found. |
| Borrowing Limit | 5 | Track books borrowed by the user; cap at 3. |
| Check-out Flag | 5 | Flag a book as checked out; allow check-in to clear the flag. |

Per the assignment, this build reuses the Part 3 optimized code (case-insensitive `action`, full/empty guard clauses, null-safe display) as its starting point, then adds two new menu actions (`search`, `checkout`) and a borrow-count tracker.

---

## Diagram

```mermaid
flowchart TD
    Start([Program Start]) --> Init[Initialize 5 book slots<br/>+ 5 checkedOut flags<br/>+ borrowedCount = 0]
    Init --> Loop{Main Loop}

    Loop -->|prompt action| Input[/Input action:<br/>add / remove / search / checkout / exit/]
    Input --> Norm[Normalize input to lowercase]
    Norm --> Switch{Switch on action}

    %% ADD
    Switch -->|add| FullCheck{All 5 slots full?}
    FullCheck -->|Yes| FullMsg[Print: library is full]
    FullCheck -->|No| AddInput[/Input new book title/]
    AddInput --> FindSlot[Find first empty slot]
    FindSlot --> StoreBook[Store title in slot]
    StoreBook --> Loop
    FullMsg --> Loop

    %% REMOVE
    Switch -->|remove| EmptyCheck1{All slots empty?}
    EmptyCheck1 -->|Yes| EmptyMsg1[Print: library is empty]
    EmptyCheck1 -->|No| RemoveInput[/Input title to remove/]
    RemoveInput --> MatchRemove{Title matches<br/>a slot?}
    MatchRemove -->|Yes| ClearSlot[Clear slot<br/>clear its checkedOut flag]
    MatchRemove -->|No| NotFoundRemove[Print: book not found]
    ClearSlot --> Loop
    NotFoundRemove --> Loop
    EmptyMsg1 --> Loop

    %% SEARCH (new — Feature 1, 5 pts)
    Switch -->|search| SearchInput[/Input title to search for/]
    SearchInput --> MatchSearch{Title matches<br/>a non-empty slot?}
    MatchSearch -->|Yes| FoundMsg[Print: book is available]
    MatchSearch -->|No| NotFoundMsg[Print: not in the collection]
    FoundMsg --> Loop
    NotFoundMsg --> Loop

    %% CHECKOUT / BORROW + CHECK-IN (Features 2 & 3, 5+5 pts)
    Switch -->|checkout| CheckoutInput[/Input title to check out or in/]
    CheckoutInput --> MatchCheckout{Title matches<br/>a non-empty slot?}
    MatchCheckout -->|No| NotFoundCO[Print: book not found]
    MatchCheckout -->|Yes| FlagState{Is book already<br/>checked out?}

    FlagState -->|No, available| LimitCheck{borrowedCount &gt;= 3?}
    LimitCheck -->|Yes| LimitMsg[Print: borrowing limit<br/>reached, 3 books max]
    LimitCheck -->|No| SetFlag[Set checkedOut = true<br/>borrowedCount += 1]
    SetFlag --> CheckoutMsg[Print: book checked out]

    FlagState -->|Yes, checked out| ClearFlag[Set checkedOut = false<br/>borrowedCount -= 1]
    ClearFlag --> CheckinMsg[Print: book checked in]

    LimitMsg --> Loop
    CheckoutMsg --> Loop
    CheckinMsg --> Loop
    NotFoundCO --> Loop

    %% INVALID
    Switch -->|invalid| InvalidMsg[Print: invalid action]
    InvalidMsg --> Loop

    %% EXIT
    Switch -->|exit| Display[Print current book list<br/>skip empty slots]
    Display --> End([End Program])

    %% Loop also displays after every non-exit action
    ClearSlot -.display list.-> Display2[Print current book list]
    StoreBook -.display list.-> Display2
    FoundMsg -.display list.-> Display2
    NotFoundMsg -.display list.-> Display2
    CheckoutMsg -.display list.-> Display2
    CheckinMsg -.display list.-> Display2
    LimitMsg -.display list.-> Display2
    Display2 -.-> Loop
```

---

## Notes for implementation

- **Base carried forward from Part 3:** five fixed `string` slots (`book1`–`book5`), case-insensitive `action` comparison via `.ToLower()`, guard clauses before add/remove, null/empty-safe display loop. This flowchart does not re-derive that logic — see `C2_Master-Assignment-Report .txt`, Part 3, for the starting code.
- **New state needed:** a parallel boolean per slot (`book1CheckedOut`… `book5CheckedOut`, or a `bool[]` if refactored to arrays) and an `int borrowedCount`.
- **Open design question (flag on Program Start for Gate review):** should `checkout` be a single combined action (toggles based on current flag state, as drawn above), or two separate menu actions (`checkout` / `checkin`) matching the report's Step 3 wording more literally? The report's Step 3 instruction implies a single check-in path that inspects the existing flag, which is what's diagrammed here — confirm before building.
- **Borrowing limit scope:** the report doesn't specify whether the limit is global or per-book-slot; diagrammed here as a single global `borrowedCount`, incremented on checkout and decremented on check-in, capped at 3.
- **Not yet built:** this is a planning artifact only, per the project's Gate-based workflow (no code, `.cs` file, or repo changes in this step).

---

*Course 2 · Introduction to Programming With C# · Final Project (You Try It! Part 4 build) · Preliminary flowchart drafted before implementation, per Gate 3 of the standard workflow.*
