## 🧭 Step-by-Step Plan to Build Your RISC-V Simulator

---

### ✅ **1. Understand the Scope**

You’re building two main components:

- A **disassembler**: Converts 32-bit binary instructions to readable RISC-V assembly (e.g. `addi x1, x2, 5`)
- A **simulator (emulator)**: Executes those instructions in a simulated environment with registers and memory

Supported instruction sets: **RV32I** + **RV32M**

---

### ✅ **2. Set Up Your Project Structure**

Since you’re using C#, keep your files organized:

- `Program.cs` – Main entry point
- Subfolders:

  - `Core/` – Emulator, Disassembler, InstructionDecoder, etc.
  - `Memory/` – InstructionMemory, DataMemory
  - `CPU/` – RegisterFile
  - `Utils/` – Helpers (sign extension, bit masking)
  - `SamplePrograms/` – Test binaries in `uint[]` form

---

### ✅ **3. Load a Program into Memory**

Use the provided binary data (like `squarefct_0_0`) and load it into your instruction memory:

- Store each 32-bit instruction in order
- Ensure instructions are loaded into an array or list for easy access

---

### ✅ **4. Build the Disassembler**

For each instruction:

- Parse the **opcode**, then:

  - For each instruction type (R, I, S, B, U, J), extract relevant fields (rd, rs1, rs2, imm, etc.)

- Match opcode + funct3 + funct7 to known instructions
- Output a **human-readable string**

⚠️ Pay attention to **immediate fields** – they are encoded non-linearly (especially in B, J types)

---

### ✅ **5. Build the Emulator Core**

Create a loop that:

- Fetches the instruction from memory
- Decodes it (reuse disassembler logic or decode again)
- Executes the instruction:

  - Read/write registers
  - Perform ALU ops
  - Update PC
  - Access data memory (if needed)

---

### ✅ **6. Implement Instruction Types Gradually**

Start small:

- R-type: `add`, `sub`, `mul`
- I-type: `addi`, `lw`
- S-type: `sw`
- B-type: `beq`, `bne`
- J-type: `jal`, `jalr`

Once one type works, test it thoroughly before adding the next.

---

### ✅ **7. Manage the CPU State**

You’ll need to manage:

- 32 **general-purpose registers**

  - `x0` is **always zero**

- A **program counter (PC)**
- **Data memory** (for `lw`, `sw`, etc.)

All this lives inside your `Emulator` class or a CPU model.

---

### ✅ **8. Display Final State**

After execution finishes:

- Print register values (especially useful for debugging)
- Optionally show memory content if you've used `lw` or `sw`

---

### ✅ **9. Test Thoroughly**

Use the provided `squarefct_0_0` test case:

- First disassemble all instructions and verify the output matches expected RISC-V assembly
- Then simulate and verify that registers contain expected values at the end

Add more test cases as needed.

---

### ✅ **10. (Optional) Add Features**

Once the basics are working:

- Implement exception handling for invalid opcodes
- Add a step-by-step execution mode (for debugging)
- Allow loading `.bin` files from disk
- Track executed instructions for statistics

---

## 🔚 Final Advice

Take it one small step at a time:

> **Disassembler first → Basic emulator → R-type → I-type → Memory access → Branches**

Testing every step will make the project much easier to debug and more satisfying.

---

Would you like a printable checklist for these steps or a simple project tracking sheet (as Markdown or Excel)?
