<#
.SYNOPSIS
    Pre-push hook script: runs tests before git push commands.
    Reads hook JSON input from stdin to detect git push operations.
#>
$input_json = [Console]::In.ReadToEnd() | ConvertFrom-Json

# Only intercept run_in_terminal tool calls that contain "git push"
$toolName = $input_json.toolName
$toolInput = $input_json.toolInput

$isGitPush = $false
if ($toolName -eq "run_in_terminal" -and $toolInput.command -match "git push") {
    $isGitPush = $true
}

if (-not $isGitPush) {
    # Not a push command, allow it through
    $result = @{ continue = $true } | ConvertTo-Json
    Write-Output $result
    exit 0
}

# Run tests before allowing push
Write-Host "Running tests before push..." -ForegroundColor Cyan
$testResult = dotnet test "$PSScriptRoot\..\..\tests\OrderService.Web.Tests\OrderService.Web.Tests.csproj" --no-restore --verbosity minimal 2>&1

if ($LASTEXITCODE -ne 0) {
    $result = @{
        hookSpecificOutput = @{
            hookEventName = "PreToolUse"
            permissionDecision = "deny"
            permissionDecisionReason = "Tests failed. Fix failing tests before pushing."
        }
    } | ConvertTo-Json -Depth 3
    Write-Output $result
    Write-Host "Tests FAILED — push blocked." -ForegroundColor Red
    exit 2
}

# Tests passed, allow push
Write-Host "All tests passed." -ForegroundColor Green
$result = @{
    hookSpecificOutput = @{
        hookEventName = "PreToolUse"
        permissionDecision = "allow"
        permissionDecisionReason = "All tests passed."
    }
} | ConvertTo-Json -Depth 3
Write-Output $result
exit 0
