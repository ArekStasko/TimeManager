$time = Get-Date -Format HH:mm:ss
$txt = "Time Manager deploy started at "
$message = $txt + $time


$variables = $PSScriptRoot+"\Variables.ps1"
. $variables

Write-Host $message -ForegroundColor yellow

docker pull mcr.microsoft.com/mssql/server:2019-latest

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=$PassWord" `
   -p 1433:1433 --name $ServerName --hostname sql1 `
   -d mcr.microsoft.com/mssql/server:2019-latest

Write-Host "Your Docker Containers :"
docker ps -a

Write-Host "Changing SA password"

docker exec -it $ServerName /opt/mssql-tools/bin/sqlcmd `
   -S localhost -U SA -P "$PassWord" `
   -Q "ALTER LOGIN SA WITH PASSWORD="$PassWord""

Write-Host "Success" -ForegroundColor green

Write-Host "Installing sqlServer module"
Install-Module -Name SqlServer
Write-Host "Done"

$runScript = $PSScriptRoot+"\Scripts\RunScript.ps1"
. $runScript

Write-Host "Your DB version : $version"
Write-Host "Successfully completed db scripts" -ForegroundColor green

$time = Get-Date -Format HH:mm:ss
$txt = "Time Manager deploy completed at "
$message = $txt + $time


Write-Host $message -ForegroundColor yellow