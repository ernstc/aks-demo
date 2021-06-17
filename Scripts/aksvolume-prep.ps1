$accountName = "aksstorage001"
$accountNameBytes = [System.Text.Encoding]::UTF8.GetBytes($accountName)
$accountNameBase64 = [Convert]::ToBase64String($accountNameBytes)
Write-Host "Account Name Base 64: " $accountNameBase64

$accountKey = "Zm72XdnnrtgKioKpqb6hKxhF217iFWOUpxsn/DSmeEcwcHBVQaxYWkJEKGwqrYWYP6/GE2dCyRMiYPbM8JsGdw=="
$accountKeyBytes = [System.Text.Encoding]::UTF8.GetBytes($accountKey)
$accountKeyBase64 = [Convert]::ToBase64String($accountKeyBytes)
Write-Host "Account Name Key 64: " $accountKeyBase64