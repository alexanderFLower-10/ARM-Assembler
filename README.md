# ARM Assembly Emulator

A C# implementation of an ARM assembly emulator that interprets and executes ARM assembly instructions based on the AQA instruction set.

## Project Overview

This project implements an ARM assembly emulator that can parse and execute ARM assembly instructions. It supports various instruction types including data processing, memory operations, branches, and logical operations.

### Features

- Complete support for the AQA ARM instruction set
- Multiple instruction types:
  - Data processing instructions (ADD, SUB, AND, ORR, EOR, MVN)
  - Memory operations (LDR, STR)
  - Branch instructions (B, BEQ, BNE, BLT, BGT)
  - Compare instructions (CMP)
  - Shift operations (LSL, LSR)
  - Program control (HALT)
- Various addressing modes:
  - Immediate addressing (#)
  - Direct register addressing (R)
  - Indirect register addressing ([])
  - Direct memory addressing
- Label support for branch instructions
- 16 general-purpose registers (R0-R15)
- Configurable memory size
- Educational tool for learning ARM assembly programming

## Project Structure

- `ARMEmulator.cs`: Core emulator implementation
- `BaseClass + Binary.cs`: Base class for all instructions, converting to binary operations etc
- `BranchExecutions.cs`: Handles execution of branch instructions
- `Branches.cs`: Implements branch and compare instructions
- `CustomExceptions.cs`: To implement many custom exceptions in the future
- `Program.cs`: Main program entry point and instruction parsing
- `ThreeParameterExecutes.cs`: Handles three-parameter instruction execution
- `ThreeParameters.cs`: Handles three-parameter instructions
- `TwoParameterExecutes.cs`: Handles two-parameter instruction execution
- `TwoParameterInst.cs`: Handles two-parameter instructions
  
  

## Usage

**[In Progress]**

This project is currently being developed into a working learning tool. The usage documentation will be updated once the interface and functionality are finalized.
UPDATE: Assembler is now complete and ready to use via loading data into text file and entering filepath, consoleGUI with appropriate error handling, syntax highlighting,
a debugging mode like Visual Studio with the ability to step and view variable (register and memory in this case) values. Will also implement the functionality
to create this into a leetcode like applications, with example solution to problems alongside testing users solutions to problems etc.

## Supported Instruction Set

The emulator supports the complete AQA ARM instruction set (And indirect addressing):

### Memory Operations
- `LDR Rd, <memory ref>`: Load the value from memory into register d
- `STR Rd, <memory ref>`: Store the value from register d into memory

### Data Processing
- `ADD Rd, Rn, <operand2>`: Add values and store result in register d
- `SUB Rd, Rn, <operand2>`: Subtract and store result in register d
- `MOV Rd, <operand2>`: Copy value into register d

### Comparison
- `CMP Rn, <operand2>`: Compare register n with operand2, setting flags

### Branch Instructions
- `B <label>`: Unconditional branch to label
- `BEQ <label>`: Branch if equal
- `BNE <label>`: Branch if not equal
- `BGT <label>`: Branch if greater than
- `BLT <label>`: Branch if less than

### Logical Operations
- `AND Rd, Rn, <operand2>`: Bitwise AND operation
- `ORR Rd, Rn, <operand2>`: Bitwise OR operation
- `EOR Rd, Rn, <operand2>`: Bitwise XOR (exclusive or) operation
- `MVN Rd, <operand2>`: Bitwise NOT operation

### Shift Operations
- `LSL Rd, Rn, <operand2>`: Logical shift left
- `LSR Rd, Rn, <operand2>`: Logical shift right

### Program Control
- `HALT`: Stop program execution

### Addressing Modes

- Immediate value: `#123`
- Register: `R0`, `R1`, etc.
- Indirect register: `[R0]`, `[R1]`, etc.
- Direct memory address: `100`, `200`, etc.
