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
$Data = Get-Content -Path $Location"\configuration.json" | ConvertFrom-Json 

foreach($scriptSet in $Data.script.PSObject.Properties){
    $sqlCommand = $scriptSet.Name

    Write-Host "Start executing"$sqlCommand" scripts"

    if($Data.script.$sqlCommand.Length -lt 1){
        Write-Host "There is no scripts for"$sqlCommand -ForegroundColor Yellow
        continue
    }

    foreach ($scriptFile in $Data.script.$sqlCommand) 
    {
        Invoke-Sqlcmd -ServerInstance $SQLServer -Database $Database -InputFile $Location$scriptFile -Verbose *> $Location"\Logs\ScriptLogs.log"   
    }

    Write-Host $sqlCommand" scripts successfully done" -ForegroundColor Green
}

Write-Host "Building database succesfully done" -ForegroundColor Green

}
catch 
{
    Write-Host "Error has occured, look to log file" -ForegroundColor Red
}