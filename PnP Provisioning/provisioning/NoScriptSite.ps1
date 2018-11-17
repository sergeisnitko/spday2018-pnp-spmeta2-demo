. "$PSScriptRoot\lib\Functions.ps1";

$Context = Get-SpAuthContext -Path $SETTINGS_PrivateCongigFilePath;

Write-Host "`n=== NoScriptSite $($Context.siteUrl) ===`n";

Connect-PnPOnline -Url $Context.siteUrl -Credentials $Context.Credentials;
Set-PnPTenantSite -Url $Context.siteUrl -NoScriptSite:$False;