# AspCoreMarch2022
Lop ASP.NET Core KG 17/03/2022

## Buổi 11 (14/04/2022) - jquery validation

# JS Regular Expression
Syntax:
```
/pattern/modifiers;
```

## Modifier
* i: phân biệt hoa thường (case-insensitive )
* g: tìm toàn bộ - global match (find all matches rather than stopping after the first match)
* m: Multiple matching

## Regular Expression Patterns

* [abc]: Hoặc a, hoặc b, hoặc c
* [0-9]: Lấy 1 kí số từ 0 --> 9 (tương đương \d)
* (a|b): Hoặc a, hoặc b (a, b có thể là biểu thức)
* \s: khoảng trắng

### Quantifiers 
* n*: Lặp n: 0 --> n lần
* n+: Lặp n: 1 --> n (tối thiểu là 1)
* n?: Lặp n: 0 hoặc 1 lần
* {m}: Lặp chính xác m lần
* {m,n}: Lặp từ m đến n lần


### The test()

It searches a string for a pattern, and returns *true* or *false*, depending on the result.