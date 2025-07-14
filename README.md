# OWASP-10-A04-insecure-design-III

### **Brief Summary**

This repository serves as a practical lab focusing on the functionality of fuzzers for security testing, specifically demonstrating the use of **SharpFuzz** within a .NET environment. The project explores the challenges and approaches to fuzzing .NET applications, including console applications and REST APIs, building upon insights gained from working with fuzzers like American Fuzzy Lop (AFL++) and WuppieFuzz. The primary goal is to understand how to apply code-driven fuzzing for identifying vulnerabilities, particularly in the context of managed languages.

### **Lessons Learned**

Based on the practical experience documented, here are the key takeaways regarding fuzzers and their application:

* **Language Focus**: Many open-source fuzzers, such as AFL and AFL++, are primarily designed for C and C++ projects, focusing on memory-corruption vulnerabilities. This necessitates the use of wrappers or specialized fuzzers for managed languages like C\# or Java.  
* **Wrapper Ecosystem**: There's a significant ecosystem of wrappers (e.g., SharpFuzz for .NET) that adapt the core functionality of established fuzzers to specific languages and frameworks.  
* **Narrow Scope**: Fuzzers like SharpFuzz are most effective when applied to small, isolated pieces of code (e.g., static classes, utility functions) that can process varied inputs without extensive configuration or external dependencies.  
* **Input Guidance**: The quality and structure of the initial input (corpus) are crucial. Well-crafted inputs can significantly guide the fuzzing process, influencing success rates and execution timings.  
* **Instrumentation Importance**: Advanced fuzzing often involves instrumentation, which allows for fine-tuning and directing the fuzzing process to achieve better code coverage and bug detection. This can be complex but is highly beneficial for thorough testing.  
* **Time Investment vs. Long-Term Benefit**: Fuzzing requires a considerable initial investment in understanding, configuration, and instrumentation. However, in the long term, it offers significant benefits, especially when integrated into automated pipelines (e.g., CI/CD) for continuous security testing.  
* **API Fuzzing Workaround**: For fuzzing REST APIs, a practical workaround involves running the API host in parallel and configuring the fuzzer's console program to act as an HTTP client, sending fuzzed requests to the running API.  
* **Exception Handling**: Standard exception handling middleware in frameworks can prevent fuzzers from reporting crashes, as they often look for program termination. Modifying the fuzzer's target code to re-throw or specifically catch and re-trigger crashes can be necessary.

### **Code Examples**

#### **Console Program (owasp10.A04.fuzzer/Program.cs)**

This example demonstrates a typical structure for a SharpFuzz console application. The LibFuzzer.Run method takes a byte array as input, which is automatically provided by the fuzzer with generated test cases. The application then processes these bytes, often attempting operations that might expose vulnerabilities (e.g., deserialization, file path manipulation, or API calls).

```
using owasp10.A04.library.wrapper;
using SharpFuzz;

namespace owasp10.A04.fuzzer;

public class Program
{
    public static void Main(string[] args)
    {
        Fuzzer.LibFuzzer.Run(bytes =>
        {
            try
            {
                var result = DllWrapper.FuzzOwaspWebApi(bytes);

                if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var responseMessage = result.Content.ReadAsStringAsync();

                    responseMessage.Wait();

                    throw new Exception(responseMessage.Result);
                }
            }
            catch (Exception) { throw; }
        });
    }
}
```

### **Execution Examples (PowerShell)**

These commands demonstrate how to execute the SharpFuzz console program using the provided PowerShell script (fuzz-libfuzzer.ps1) against different test case corpuses.

* **Fuzzing JsonSerializer**: This command initiates fuzzing targeting the JSON deserialization logic within the console application, using input examples from the Testcases/JsonDeserializer directory.
  
```scripts/fuzz-libfuzzer.ps1 \-libFuzzer "./libfuzzer-dotnet-windows.exe" \-project owasp10.A04.fuzzer/owasp10.A04.fuzzer.csproj \-corpus Testcases/JsonDeserializer```

* **Fuzzing Path**: This command runs the fuzzer against the Path manipulation logic, utilizing test cases from the Testcases/Path directory.  

```scripts/fuzz-libfuzzer.ps1 \-libFuzzer "./libfuzzer-dotnet-windows.exe" \-project owasp10.A04.fuzzer/owasp10.A04.fuzzer.csproj \-corpus Testcases/Path```

* **Fuzzing OwaspWebApi**: This command targets the OwaspWebApi interaction logic within the fuzzer, using inputs from Testcases/OwaspWebApi. This typically involves the fuzzer generating inputs that are then used to craft HTTP requests to a separately running instance of the OwaspWebApi project.  

```scripts/fuzz-libfuzzer.ps1 \-libFuzzer "./libfuzzer-dotnet-windows.exe" \-project owasp10.A04.fuzzer/owasp10.A04.fuzzer.csproj \-corpus Testcases/OwaspWebApi```

### **Disclaimer**

The fuzz-libfuzzer.ps1 PowerShell script used for executing the fuzzer is part of the original [SharpFuzz](https://github.com/Metalnem/sharpfuzz) library and is included here for convenience. Please refer to the official SharpFuzz repository for the most up-to-date version and detailed usage instructions.

### **Source article**


