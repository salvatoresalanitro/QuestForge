@echo off
setlocal enabledelayedexpansion

echo 🔄 Eseguo i test con coverage...
dotnet test --collect:"XPlat Code Coverage"

echo 🔍 Cerco il file coverage.cobertura.xml più recente...

set "latestFile="
set "latestTime=000000000000.00"

for /r %%f in (coverage.cobertura.xml) do (
    set "current=%%~tf"
    if "!current!" GTR "!latestTime!" (
        set "latestTime=!current!"
        set "latestFile=%%f"
    )
)

if defined latestFile (
    echo ✅ Ultimo file trovato: !latestFile!
    reportgenerator -reports:"!latestFile!" -targetdir:"coverage-report"
    echo 🌐 Apro il report in HTML...
    start "" "coverage-report\index.html"
) else (
    echo ❌ Nessun file coverage.cobertura.xml trovato!
)

endlocal