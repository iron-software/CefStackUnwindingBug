using CefInterop;
// load interop function
var del = BugRepro.LoadInteropFunction();
// throw-and-catch null ref
/* > About to catch a null ref exception!
 * > System.NullReferenceException: Object reference not set to an instance of an object.
 * > Successfully try/caught null ref!
 */
BugRepro.ThrowAndCatchNullRef();
// initialize cef
del();
// throw-and-catch null ref
/* > About to catch a null ref exception!
 * .... (dead)
 */
BugRepro.ThrowAndCatchNullRef();
// THIS LINE IS NEVER REACHED
Console.WriteLine("exited successfully");