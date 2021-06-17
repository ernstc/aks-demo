$akvTenantId = "<tenandId>"
$akvTenantIdBytes = [System.Text.Encoding]::UTF8.GetBytes($akvTenantId)
$akvTenantIdBase64 = [Convert]::ToBase64String($akvTenantIdBytes)
Write-Host "Azure Key Vault Tenant Id Base 64: " $akvTenantIdBase64

$akvEndpoint = "https://<keyvaultname>.vault.azure.net/"
$akvEndpointBytes = [System.Text.Encoding]::UTF8.GetBytes($akvEndpoint)
$akvEndpointBase64 = [Convert]::ToBase64String($akvEndpointBytes)
Write-Host "Azure Key Vault Endpoint Base 64: " $akvEndpointBase64

$akvClientId = "<clientId>"
$akvClientIdBytes = [System.Text.Encoding]::UTF8.GetBytes($akvClientId)
$akvClientIdBase64 = [Convert]::ToBase64String($akvClientIdBytes)
Write-Host "Client Id Base 64: " $akvClientIdBase64

$akvClientSecret = "<clientSecret>"
$akvClientSecretBytes = [System.Text.Encoding]::UTF8.GetBytes($akvClientSecret)
$akvClientSecretBase64 = [Convert]::ToBase64String($akvClientSecretBytes)
Write-Host "Client Secret 64: " $akvClientSecretBase64