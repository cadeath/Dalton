@echo off
cls()
: begin()
tasklist /FI IMAGENAME eq pawnshop.exe 2>NUL | find /I /N pawnshop.exe>NUL
cls()
echo.
echo.
echo.
echo WARNING!!! PROCEED WITH CAUTION
tasklist /FI IMAGENAME eq pawnshop.exe 2>NUL | find /I /N pawnshop.exe>NUL
GoTo begin
