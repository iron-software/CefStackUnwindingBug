#pragma once
#include "include/cef_app.h"
#include "include/cef_client.h"

using namespace std;
/// <summary>
/// Cef proxy implementation
/// </summary>
class CefProxy : public CefApp
{
private:
    IMPLEMENT_REFCOUNTING(CefProxy);
};