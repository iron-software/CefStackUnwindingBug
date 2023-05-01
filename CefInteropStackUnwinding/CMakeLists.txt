### Global Project Values
cmake_minimum_required (VERSION 3.8)
project ("CefInteropStackUnwinding")
file(GLOB SOURCES
    "${CMAKE_CURRENT_SOURCE_DIR}/*.h"
    "${CMAKE_CURRENT_SOURCE_DIR}/*.cpp"
    "${CMAKE_CURRENT_SOURCE_DIR}/*.def"
)
# Add shared library target
add_library (CefInteropStackUnwinding SHARED ${SOURCES})
# Remove any automatically added file prefix
set_target_properties(CefInteropStackUnwinding PROPERTIES PREFIX "")
# Position Independant Code
add_definitions(-fPIC)
### Linux
# Set Link options
target_link_options(CefInteropStackUnwinding PRIVATE -static-libgcc -static-libstdc++) 
# Include header files
target_include_directories(CefInteropStackUnwinding
	PRIVATE "${CMAKE_SOURCE_DIR}/LinuxIncludes"
)
# Link!
target_link_libraries(CefInteropStackUnwinding
	PRIVATE CefWrapper
	PRIVATE Cef
)