//DecompileSingle.java
// Ghidra headless script that decompiles a single function by address.
// Usage: analyzeHeadless <project_dir> <project_name> -import <binary>
//        -postScript DecompileSingle.java <address> <output_file>
//        -scriptPath <dir_containing_this_script>
//
// Args[0] = function address (hex string, e.g. "0x1a2b3c4")
// Args[1] = output file path for the decompiled C code

import ghidra.app.decompiler.DecompInterface;
import ghidra.app.decompiler.DecompileResults;
import ghidra.app.script.GhidraScript;
import ghidra.program.model.address.Address;
import ghidra.program.model.listing.Function;
import ghidra.program.model.listing.FunctionManager;
import ghidra.util.task.ConsoleTaskMonitor;

import java.io.FileWriter;
import java.io.PrintWriter;

public class DecompileSingle extends GhidraScript {

    @Override
    public void run() throws Exception {
        String[] args = getScriptArgs();

        if (args.length < 2) {
            println("Usage: DecompileSingle.java <address> <output_file>");
            println("Got " + args.length + " arguments");
            return;
        }

        String addressStr = args[0].replaceAll("^0x", "");
        String outputPath = args[1];

        long addressValue = Long.parseUnsignedLong(addressStr, 16);
        Address targetAddr = toAddr(addressValue);

        FunctionManager fm = currentProgram.getFunctionManager();
        Function func = fm.getFunctionAt(targetAddr);

        if (func == null) {
            func = fm.getFunctionContaining(targetAddr);
        }

        if (func == null) {
            println("No function found at address: " + args[0]);
            PrintWriter pw = new PrintWriter(new FileWriter(outputPath));
            pw.println("// No function found at address 0x" + addressStr);
            pw.flush();
            pw.close();
            return;
        }

        DecompInterface decomp = new DecompInterface();
        decomp.openProgram(currentProgram);

        ConsoleTaskMonitor monitor = new ConsoleTaskMonitor();
        DecompileResults results = decomp.decompileFunction(func, 60, monitor);

        PrintWriter pw = new PrintWriter(new FileWriter(outputPath));

        if (results != null && results.decompileCompleted()) {
            String cCode = results.getDecompiledFunction().getC();
            pw.println("// Function: " + func.getName());
            pw.println("// Address: 0x" + Long.toHexString(func.getEntryPoint().getOffset()));
            pw.println("// Signature: " + func.getSignature().getPrototypeString());
            pw.println();
            if (cCode != null) {
                pw.print(cCode);
            } else {
                pw.println("// Decompiled code was null");
            }
        } else {
            pw.println("// Decompilation failed for function: " + func.getName());
            pw.println("// Address: 0x" + Long.toHexString(func.getEntryPoint().getOffset()));
            if (results != null) {
                pw.println("// Error: " + results.getErrorMessage());
            }
        }

        pw.flush();
        pw.close();
        decomp.dispose();
        println("Decompilation saved to: " + outputPath);
    }
}
