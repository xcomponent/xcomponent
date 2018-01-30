@echo off
for /d %%i in (xc.*) do (
    echo.
    echo Building %%i... 
    echo.

    cd %%i
    if exist build.ps1 (
        powershell.exe -NoProfile -ExecutionPolicy Bypass -Command ./build.ps1
    ) else (
        echo Build script not found!
    )
    cd..
)
