## 1. symbols and tachyonGrid

`symbols` has 17 items because the file ends with a newline. `tachyonGrid` has 16 items because `[..^1]` removes the last item.

## 2. posX and character

`posX` increases from 0, and `character` is the character at that position. A normal `foreach` gives the character but not its position.

## 3. processSplitter edge case

Both splitters write a beam into the shared middle square, so it remains one `|`. This is correct for displaying the grid, but the split count is not updated.

## 4. Incorrect total

The grid output is correct, but `totalCount` stays 0 because the program never increments it. The expected total is 21.