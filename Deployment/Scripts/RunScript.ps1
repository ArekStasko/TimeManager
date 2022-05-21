$variables = $PSScriptRoot+"../Variables.ps1"

$version = "1.0.0"

Write-Host "Running sql scripts"

Write-Host "Executing DDL scripts ..."
Invoke-Sqlcmd -ServerInstance $ServerName -Username "SA" -Password $PassWord -Verbose -InputFile "$PSScriptRoot\$version\DDL.sql"
Write-Host "Success" -ForegroundColor green

Write-Host "Executing DML scripts ..."
Invoke-Sqlcmd -ServerInstance $ServerName -Username "SA" -Password $PassWord -Verbose -InputFile "$PSScriptRoot\$version\DML.sql"
Write-Host "Success" -ForegroundColor green

Write-Host "Executing DQL scripts ..."
Invoke-Sqlcmd -ServerInstance $ServerName -Username "SA" -Password $PassWord -Verbose -InputFile "$PSScriptRoot\$version\DQL.sql"
Write-Host "Success" -ForegroundColor green