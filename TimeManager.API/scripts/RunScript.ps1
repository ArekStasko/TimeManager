if (-not (Get-Command Invoke-Sqlcmd -ErrorAction SilentlyContinue)) {
    Write-Error "Unabled to find Invoke-SqlCmd cmdlet"
}

if (-not (Get-Module -Name SqlServer | Where-Object {$_.ExportedCommands.Count -gt 0})) {
    Write-Error "The SqlServer module is not loaded"
}

if (-not (Get-Module -ListAvailable | Where-Object Name -eq SqlServer)) {
    Write-Error "Can't find the SqlServer module"
}

Import-Module SqlServer -ErrorAction Stop

$SQLServer = "DESKTOP-59AMNOB\PROJECTS"
$Database = 'TimeManager'
$Location = Get-Location

try
{
Write-Host "Start executing DDL scripts"

<#  
Instead of creating sqlcmd for each file, there will be configuration file from which ps
will get sql files to execute in for loop to get the code cleaner
#>

Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -InputFile $Location"\1.0.0\dbo.Activities.Create.sql" -Verbose *> $Location"\Logs\ScriptLogs.log"
Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -InputFile $Location"\1.0.0\dbo.Categories.Create.sql" -Verbose *> $Location"\Logs\ScriptLogs.log"

Write-Host "DDL scripts successfully done" -ForegroundColor Green


Write-Host "Start executing DML scripts"

Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -InputFile $Location"\1.0.0\dbo.Activities.Insert.sql" -Verbose *> $Location"\Logs\ScriptLogs.log"
Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -InputFile $Location"\1.0.0\dbo.Categories.Insert.sql" -Verbose *> $Location"\Logs\ScriptLogs.log"

Write-Host "DML scripts successfully done" -ForegroundColor Green

Write-Host "Building db succesfully done" -ForegroundColor Green
}
catch 
{
    Write-Host "Error has occured, look to log file" -ForegroundColor Red
}