@echo off
SETLOCAL EnableExtensions
set EXE=pawnshop.exe
FOR /F %%x IN ('tasklist /NH /FI "IMAGENAME eq %EXE%"') DO IF %%x == %EXE% goto FOUND 
echo Not running
pause
goto FIN 
:FOUND
echo Running
Taskkill /F /IM pawnshop.exe
pause
:FINALIZE
