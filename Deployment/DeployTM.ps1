$time = Get-Date -Format HH:mm:ss
$txt = "Time Manager deploy started at "
$message = $txt + $time


Write-Host $message -ForegroundColor yellow
