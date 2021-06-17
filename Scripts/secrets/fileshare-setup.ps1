$connectTestResult = Test-NetConnection -ComputerName aksstorage001.file.core.windows.net -Port 445
if ($connectTestResult.TcpTestSucceeded) {
    # Save the password so the drive will persist on reboot
    cmd.exe /C "cmdkey /add:`"aksstorage001.file.core.windows.net`" /user:`"Azure\aksstorage001`" /pass:`"Zm72XdnnrtgKioKpqb6hKxhF217iFWOUpxsn/DSmeEcwcHBVQaxYWkJEKGwqrYWYP6/GE2dCyRMiYPbM8JsGdw==`""
    # Mount the drive
    New-PSDrive -Name W -PSProvider FileSystem -Root "\\aksstorage001.file.core.windows.net\aksvolume" -Persist
} else {
    Write-Error -Message "Unable to reach the Azure storage account via port 445. Check to make sure your organization or ISP is not blocking port 445, or use Azure P2S VPN, Azure S2S VPN, or Express Route to tunnel SMB traffic over a different port."
}