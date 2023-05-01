### Global Project Values
cmake_minimum_required (VERSION 3.8)
project ("CefSubprocess")
file(GLOB SOURCES
    "${CMAKE_CURRENT_SOURCE_DIR}/*.h"
    "${CMAKE_CURRENT_SOURCE_DIR}/*.cpp"
)
# Add executable target
add_executable (CefSubprocess ${SOURCES})
# Remove any automatically added file prefix
set_target_properties(CefSubprocess PROPERTIES PREFIX "")
### Linux
# Include header files
target_include_directories(CefSubprocess
	PRIVATE "${CMAKE_SOURCE_DIR}/LinuxIncludes"
)
# Link!
target_link_libraries(CefSubprocess
	PRIVATE CefWrapper
	PRIVATE Cef
)
