Param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Debug"
)

$ErrorActionPreference = "Stop"

if (-not (Get-Command msbuild -ErrorAction SilentlyContinue)) {
    Write-Error -Message "MSBuild was not found in PATH. Please run this from a Visual Studio Developer PowerShell or add MSBuild.exe to the PATH variable." -Category ObjectNotFound
    exit 1
}

$solution = Join-Path $PSScriptRoot "SafeExamBrowser.sln"

$projects = @{
    "SafeExamBrowser.Client"         = "SafeExamBrowser.Client.exe"
    "SafeExamBrowser.Configuration"  = "SafeExamBrowser.Configuration.dll"
    "SafeExamBrowser.Runtime"        = "SafeExamBrowser.exe"
    "SafeExamBrowser.Monitoring"     = "SafeExamBrowser.Monitoring.dll"
}

foreach ($arch in @("x64", "x86")) {

    Write-Host ""
    Write-Host "=== Restoring & Building $Configuration | $arch ===" -ForegroundColor Cyan

    msbuild $solution `
        /p:Configuration=$Configuration `
        /p:Platform=$arch `
	    /p:RestoreSources="https://api.nuget.org/v3/index.json" `
	    /p:RestorePackagesConfig=true `
        /p:langversion=latest `
        /verbosity:minimal `
        /t:Restore

    if ($LASTEXITCODE -ne 0) {
        Write-Error -Message "Failed restoring packages (configuration: $Configuration, arch: $arch): msbuild returned error code $LASTEXITCODE." -Category InvalidResult
        exit 1
    }

    msbuild $solution `
        /p:Configuration=$Configuration `
        /p:Platform=$arch `
        /p:langversion=latest `
        /verbosity:minimal `
        /t:Build

    if ($LASTEXITCODE -ne 0) {
        Write-Error -Message "Failed compiling Safe Exam Browser Patch files (configuration: $Configuration, arch: $arch): msbuild returned error code $LASTEXITCODE." -Category InvalidResult
        exit 1
    }

    $resourceDir = Join-Path $PSScriptRoot "patch-seb\Resources\$arch"

    New-Item -ItemType Directory -Force -Path $resourceDir | Out-Null

    foreach ($project in $projects.Keys) {

        $file = $projects[$project]
        $source = Join-Path `
            $PSScriptRoot `
            "$project\bin\$arch\$Configuration\$file"

        if (!(Test-Path $source)) {
            Write-Error -Message "Expected output not found: $source" -Category ObjectNotFound
            exit 1
        }

        Copy-Item $source $resourceDir -Force

        Write-Host "Copied $file -> resources\$arch\" -ForegroundColor Green
    }
}

Write-Host ""
Write-Host "Safe Exam Browser Patch files compiled successfully!" -ForegroundColor Green
Write-Host ""
Write-Host "Compiling patcher..."
$project = Join-Path $PSScriptRoot "patch-seb\patch-seb.csproj"

msbuild $project `
        /p:Configuration=$Configuration `
        /p:langversion=latest `
        /verbosity:minimal `
        /t:Build

if ($LASTEXITCODE -ne 0) {
    Write-Error -Message "Failed compiling Safe Exam Browser patcher (configuration: $Configuration): msbuild returned error code $LASTEXITCODE." -Category InvalidResult
    exit 1
} else {
    Write-Host ""
    Write-Host "Patcher compiled successfully!" -ForegroundColor Green
}
