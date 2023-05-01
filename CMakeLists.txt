### Global Project Values
cmake_minimum_required (VERSION 3.8)
project (IronLibCefWebLinux)
### Define imported libraries
add_library(CefWrapper STATIC IMPORTED GLOBAL)
add_library(Cef SHARED IMPORTED GLOBAL)
### Definitions
if (​CMAKE_BUILD_TYPE EQUAL "Debug")
    add_definitions(-D_DEBUG)
endif(​CMAKE_BUILD_TYPE EQUAL "Debug")
add_definitions(-std=c++17) # Needed for std::to_string() (copied from cef source)
add_compile_definitions(_GLIBCXX_USE_CXX11_ABI=0)
#add_compile_definitions(TEST_SAVE_DOC_BYTES_TO_DISK)
### Linux
# Linux defines
add_compile_definitions(LINUX UNIX_ENV XMP_UNIXBuild)
# Set flags
set(CMAKE_EXE_LINKER_FLAGS ${CMAKE_EXE_LINKER_FLAGS} "-fvisibility=hidden -static-libgcc -static-libstdc++ -Wl,-rpath,$ORIGIN")
set(CMAKE_SHARED_LINKER_FLAGS ${CMAKE_SHARED_LINKER_FLAGS} "-fvisibility=hidden -static-libgcc -static-libstdc++ -Wl,-rpath,$ORIGIN")
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++17 -pthread")
# Library Locations
set_target_properties(Cef PROPERTIES IMPORTED_LOCATION "${CMAKE_SOURCE_DIR}/LinuxReferences/libcef.so")
set_target_properties(CefWrapper PROPERTIES IMPORTED_LOCATION "${CMAKE_SOURCE_DIR}/LinuxReferences/libcef_dll_wrapper.debug.a")
# More flags
set(CMAKE_POSITION_INDEPENDENT_CODE ON)
# Build Components
add_subdirectory (CefSubprocess)
add_subdirectory (CefInteropStackUnwinding)