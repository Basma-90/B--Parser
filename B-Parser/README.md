# B-Parser

A simple custom parser for a Python-like language built as part of the **Programming Languages Design (PLD)** course at **Mansoura University**.

---

## About

B-Parser parses a small scripting language supporting variables, expressions, conditionals, loops, functions, and increment/decrement operators. It handles indentation-based blocks and is case sensitive.

---

## Features

- Variables and arithmetic expressions  
- `if-else` statements  
- `for` and `while` loops  
- Functions with parameters  
- Increment/decrement operators (`++`, `--`)  
- Return and print statements  

---

## User Interface

B-Parser includes a Windows Forms application with:

- A textbox where users type their code  
- A listbox that displays parsing messages in real-time, including errors and expected tokens  

---

## Usage Example

Type code like this in the textbox:

```basma
Basma
x = 10
if x > 5:
{
    print("x is big")
}
End

