#include "Shlwapi.h"
#pragma comment (lib, "Shlwapi.lib")

void GetModuleDirectory(LPTSTR szPath)
{
    GetModuleFileName(NULL, szPath, MAX_PATH);

    LPTSTR pSlash = _tcsrchr(szPath, '\\');

    if (pSlash == 0)
        szPath[2] = 0;
    else
        *pSlash = 0;
}

bool UpdateAvailable()
{
    // Get the real path to wyUpdate.exe
    // (assumes it's in the same directory as this app)
    TCHAR szPath[MAX_PATH];
    szPath[0] = '\"';
    GetModuleDirectory(&szPath[1]);
    PathAppend(szPath, _T("wyUpdate.exe\" /quickcheck /justcheck /noerr"));


    STARTUPINFO si = {0}; si.cb = sizeof(si);
    PROCESS_INFORMATION pi = {0};

    // start wyUpdate
    if (!CreateProcess(NULL, szPath, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi))
    {
        // Failed to launch wyUpdate.
        return false;
    }

    // Wait until child process exits.
    WaitForSingleObject(pi.hProcess, INFINITE);

    // Get the exit code
    DWORD exitcode = 0;
    GetExitCodeProcess(pi.hProcess, &exitcode);

    // Close process and thread handles.
    CloseHandle(pi.hProcess);
    CloseHandle(pi.hThread);

    // exitcode of 2 means update available
    return exitcode == 2;
}