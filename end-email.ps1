param (
    [string]$smtpServer,
    [int]$smtpPort,
    [string]$smtpUser,
    [string]$smtpPassword,
    [string]$fromEmail,
    [string]$toEmail,
    [string]$subject,
    [string]$body
)

$message = New-Object system.net.mail.mailmessage
$message.from = $fromEmail
$message.To.Add($toEmail)
$message.Subject = $subject
$message.Body = $body

$smtp = New-Object Net.Mail.SmtpClient($smtpServer, $smtpPort)
$smtp.EnableSsl = $true
$smtp.Credentials = New-Object System.Net.NetworkCredential($smtpUser, $smtpPassword)

try {
    $smtp.Send($message)
    Write-Host "Email sent successfully."
}
catch {
    Write-Host "Failed to send email. Error: $_"
}
