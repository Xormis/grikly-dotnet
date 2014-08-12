$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\src\GriklyApi.Portable\bin\Release\GriklyApi.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\deployment\Grikly.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\nuget\Grikly.compiled.nuspec

& $root\.nuget\NuGet.exe pack $root\deployment\Grikly.compiled.nuspec