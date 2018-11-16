[CmdletBinding()]
Param (
  [Parameter(Mandatory=$False)]
  [string]$SiteUrl,
  [Parameter(Mandatory=$False)]
  [boolean]$DebugMode = $True,
  [Parameter(Mandatory=$false)]
  [string]$Handlers,
  [Parameter(Mandatory=$false)]
  [switch]$ProvisionContentTypesToSubWebs,
  [Parameter(Mandatory=$false)]
  [switch]$ProvisionFieldsToSubWebs,
  [Parameter(Mandatory=$True)]
  [string]$SchemaPath

);

. "$PSScriptRoot\lib\Functions.ps1";

Function Main() {
    $StartTime = Get-Date;

    $Context = Get-SpAuthContext $SETTINGS_PrivateCongigFilePath; # "./config/private.json";

    If ([string]::IsNullOrEmpty($SiteUrl)) {
      $SiteUrl = $Context.siteUrl;
    }

    Write-Output "Target site: $SiteUrl";

    If ($DebugMode) {
      Set-PnPTraceLog -on -level Debug;
    }

    Connect-PnPOnline -Url $SiteUrl -Credential $Context.Credentials;
    Set-PnPTenantSite -Url $SiteUrl -NoScriptSite:$False;

    $stringToExec = 'Apply-PnPProvisioningTemplate -Path ' + $SchemaPath;
    if ($Handlers) {
      $stringToExec += ' -Handlers ' + $Handlers;
    }
    if ($ProvisionContentTypesToSubWebs) {
      $stringToExec += ' -ProvisionContentTypesToSubWebs';
    }
    if ($ProvisionFieldsToSubWebs) {
      $stringToExec += ' -ProvisionFieldsToSubWebs';
    }

    Invoke-Expression $stringToExec;

    $EndTime = Get-Date;
    $TimeSpan = New-TimeSpan $StartTime $EndTime;
    PrintSuccessMessage "Execution time: $timespan";
}

Main;