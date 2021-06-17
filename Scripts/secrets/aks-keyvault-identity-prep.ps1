$akvTenantId = "9b718cd7-f494-420b-bbd8-697aeac235cc"
$akvTenantIdBytes = [System.Text.Encoding]::UTF8.GetBytes($akvTenantId)
$akvTenantIdBase64 = [Convert]::ToBase64String($akvTenantIdBytes)
Write-Host "Azure Key Vault Tenant Id Base 64: " $akvTenantIdBase64

$akvEndpoint = "https://keyvaultdemo001.vault.azure.net/"
$akvEndpointBytes = [System.Text.Encoding]::UTF8.GetBytes($akvEndpoint)
$akvEndpointBase64 = [Convert]::ToBase64String($akvEndpointBytes)
Write-Host "Azure Key Vault Endpoint Base 64: " $akvEndpointBase64

$akvClientId = "7e6b45a4-3870-445b-a95d-7459b704380e"
$akvClientIdBytes = [System.Text.Encoding]::UTF8.GetBytes($akvClientId)
$akvClientIdBase64 = [Convert]::ToBase64String($akvClientIdBytes)
Write-Host "Client Id Base 64: " $akvClientIdBase64

$akvClientSecret = "w2Y9HDYiHE73FTlegOep_6Qu8T..Xh~XR_"
$akvClientSecretBytes = [System.Text.Encoding]::UTF8.GetBytes($akvClientSecret)
$akvClientSecretBase64 = [Convert]::ToBase64String($akvClientSecretBytes)
Write-Host "Client Secret 64: " $akvClientSecretBase64