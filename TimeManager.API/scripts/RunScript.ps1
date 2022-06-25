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

$SQLServer = "DESKTOP-59AMNOB\\PROJECTS"
$Database = 'TimeManager'
$Location = Get-Location
$Username = 'sa'
$Password = 'password1234'

Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -Username $Username -Password $Password -InputFile $Location"\1.0.0\dbo.Activities.Create.sql" -Verbose *> $Location"\Logs\ScriptLogs.log"
Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -Username $Username -Password $Password -InputFile $Location"\1.0.0\dbo.Categories.Create.sql" -Verbose *> $Location"\Logs\ScriptLogs.log"

Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -Username $Username -Password $Password -InputFile $Location"\1.0.0\dbo.Activities.Insert.sql" -Verbose *> $Location"\Logs\ScriptLogs.log"
Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -Username $Username -Password $Password -InputFile $Location"\1.0.0\dbo.Categories.Insert.sql" -Verbose *> $Location"\Logs\ScriptLogs.log"