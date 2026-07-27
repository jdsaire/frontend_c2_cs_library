# Grading Criteria Breakdown

15 points across three criteria. Exactly where each is satisfied in [`../src/Program.cs`](../src/Program.cs):

## 1. Search (5 pts)
- Prompts for a title to search for: lines 75–76.
- Case-insensitive match via `FindBookCaseInsensitive` (defined lines 178–188), called at line 82.
- Found → "That book is available in the collection.": line 88.
- Not found → "That book is not in the collection.": line 84.

## 2. Borrowing Limit (5 pts)
- `borrowedCount` tracks how many books are currently checked out: declared line 10.
- Capped at 3 — a new checkout is refused once the count is reached: condition line 113, message line 115.
- Incremented on checkout: line 120. Decremented on check-in: line 110. Also decremented if a checked-out book is removed from the collection, so the count never drifts out of sync: line 67.

## 3. Check-out Flag (5 pts)
- `checkedOut` parallel boolean array, one flag per book slot: declared line 9.
- Flags a book as checked out: line 119 (inside the `checkout` action, lines 91–124).
- The same `checkout` action checks a book back in if it's already flagged, clearing the flag: lines 107–111.
