# PS Script to run your ADF v2 pipeline
# Will execute the pipeline 1x and then show activity run status via monitoring API

<#

.SYNOPSIS
Use this script to execute a single activity run from your new ADF V2 pipeline

.DESCRIPTION
Execute pipeline 1x and also monitor the status

.EXAMPLE
.\runmonitor.ps1 -resourceGroupName "azure-data-lake-sample" -DataFactoryName "<adfName>" -PipelineName "ADLS2ADLSCopyPipeline"
.\runmonitor.ps1 -resourceGroupName "azure-data-lake-sample" -DataFactoryName "<adfName>" -PipelineName "USQLPipeline"

.NOTES
Required params: -resourceGroupName -DataFactoryName -PipelineName

#>

param (
    [string] $resourceGroupName,
    [string] $DataFactoryName,
    [string] $PipelineName
)

if(-not($resourceGroupName)) { Throw "You must supply a value for -resourceGroupName" }
if(-not($DataFactoryName)) { Throw "You must supply a value for -DataFactoryName" }
if(-not($PipelineName)) { Throw "You must supply a value for -PipelineName" }

$runId = Invoke-AzureRmDataFactoryV2Pipeline -DataFactoryName $DataFactoryName -ResourceGroupName $resourceGroupName -PipelineName $PipelineName

while ($True) {
$run = Get-AzureRmDataFactoryV2PipelineRun -ResourceGroupName $resourceGroupName -DataFactoryName $DataFactoryName -PipelineRunId $runId
if ($run) {
if ($run.Status -ne 'InProgress') {
Write-Host "Pipeline run finished. The status is: " $run.Status -foregroundcolor "Yellow"
$run
break
}
Write-Host  "Pipeline is running...status: InProgress" -foregroundcolor "Yellow"
}
Start-Sleep -Seconds 20
}



Write-Host "Activity run details:" -foregroundcolor "Yellow"
$result = Get-AzureRmDataFactoryV2ActivityRun -DataFactoryName $DataFactoryName -ResourceGroupName $resourceGroupName -PipelineRunId $runId -RunStartedAfter (Get-Date).AddMinutes(-30) -RunStartedBefore (Get-Date).AddMinutes(30)
$result

Write-Host "Activity 'Output' section:" -foregroundcolor "Yellow"
$result.Output -join "`r`n"

Write-Host "\nActivity 'Error' section:" -foregroundcolor "Yellow"
$result.Error -join "`r`n"