$word = New-Object -ComObject Word.Application
$word.Visible = $false

$scriptPath = (Get-Item .).FullName
$htmlFiles = Get-ChildItem -Path $scriptPath -Filter "*.html"

foreach ($file in $htmlFiles) {
    try {
        Write-Host "Converting $($file.Name)..."
        $doc = $word.Documents.Open($file.FullName)
        
        # Save as DOCX (WdSaveFormat.wdFormatXMLDocument = 16)
        $docxPath = $file.FullName.Replace('.html', '.docx')
        $doc.SaveAs2($docxPath, 16)
        
        # Save as PDF (WdSaveFormat.wdFormatPDF = 17)
        $pdfPath = $file.FullName.Replace('.html', '.pdf')
        $doc.SaveAs2($pdfPath, 17)
        
        $doc.Close([ref]0)
        Write-Host "Success: $($file.Name)"
    } catch {
        Write-Host "Failed to convert $($file.Name): $($_.Exception.Message)"
    }
}

$word.Quit()
[System.Runtime.Interopservices.Marshal]::ReleaseComObject($word) | Out-Null
