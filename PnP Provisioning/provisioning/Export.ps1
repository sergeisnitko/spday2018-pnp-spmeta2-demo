. "$PSScriptRoot\lib\Functions.ps1";

$Context = Get-SpAuthContext -Path $SETTINGS_PrivateCongigFilePath;

Write-Host "`n=== Exporting $($Context.siteUrl) ===`n";

Connect-PnPOnline -Url $Context.siteUrl -Credentials $Context.Credentials;
Get-PnPProvisioningTemplate -Force -Out "$PSScriptRoot/../01.Export-Import_site_template/exported-template.xml";