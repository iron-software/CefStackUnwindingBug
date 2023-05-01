#include "pch.h"
#include "CefProxy.h"

using namespace std;

int main (int c, char *v[])
{
    CefProxy proxy;
    CefMainArgs args(c,v);
    int result = CefExecuteProcess(args, &proxy, NULL);
    return result;
}
