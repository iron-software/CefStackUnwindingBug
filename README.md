# CEF Interop / Stack Unwinding Bug Reproduction
_5/1/23_
## Build Steps
1. Build `CefInterop/CefInterop/CefInterop.csproj` for **net6.0/Debug/AnyCPU**
2. Build `CMakeLists.txt` in the root directory to generate native assets
3. Run `./copy.sh` from the root directory, to copy native assets into .NET app directory
4. Ensure the necessary Linux dependencies are installed (via apt-get) for CEF usage
5. Verify your .NET app runtime directory contains **CefInteropStackUnwinding.so, CefSubprocess, libcef.so**, and all of the other files necesssary for CEF runtime
## Run Steps
1. Either run CefInterop.dll via Visual Studio OR via command-line `dotnet CefInterop.dll`
## Expected Behavior
1. dotnet console app completes successfully without segmentation fault
2. dotnet console app prints `Successfully try/caught null ref!` TWO TIMES (once before Cef initialization, once afterwards)
## Observed Behavior
1. dotnet console app successfully catches any exceptions prior to CEF initialization, but fails to catch exceptions after CEF initialization
2. dotnet console app is unable to use breakpoints after CEF initialization (since `SIGTRAP` is just an exception anyway)
## Notes/Research
My best guess is that CEF breaks stack unwinding after intialization via interop, perhaps due to using `jmp` and/or the nature of the stack pointer during interop calls.