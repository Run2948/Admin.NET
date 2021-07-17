@echo off
@echo Deleting all BIN, OBJ, .VS folders ...
for /d /r . %%d in (bin,obj,.vs)  do @if exist "%%d" rd /s/q "%%d"
@echo.
@echo Folders successfully deleted :) Close the window.
@echo.
@echo.
pause > nul