# Parser in C#

_(WIP)_

A parser implemented in C# as a final requirement for my CCS 238 Programming Languages class for **Dr. Felipe P. Vista IV**.

Demonstrates compiler design theory from:

```
Scanner (Lexical Analysis) -> Parser (Syntax Analysis)
```

Progress:

- [x] Scanner Tokenization
- [ ] Parse Tree
- [ ] Expression Output

```
Written by:
- 🤓 Carlo Antonio T. Taleon
- 👧 Glecy S. Elizalde
- 🤠 Christopher Joseph T. Rubinos
```

## Get started

> Make sure to install [.Net SDK](https://dotnet.microsoft.com/en-us/download) if you haven't yet

1. Clone this repo and change your directory

```sh
# >
git clone https://github.com/Blankeos/cs-parser
cd cs-parser
# cs-parser>
```

2. Run the project in your terminal

```sh
# cs-parser>
dotnet run
```

## Introducing: The 🤓 "Carlo" Programming Language

It's basically like you're talking to some dude named Carlo.

### Features

- [x] Variables with `create`
- [x] Print to console with `say`
- [x] Arithmetic `+` `-` `*` `/`
- [x] Comments with `%`

### Example usage

```m
% filename: input.carlo

create age = 21

say age
% 21

say age - 1
% 20

func sayHello(name, age)
    say "Hello " + name + "! You are " + age

sayHello "Carlo" 21
% Hello Carlo! You are 21
```
