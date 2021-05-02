dotnet sonarscanner begin /o:"christophe-debove" /k:"ChristopheDEBOVE_OpenHSK" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.cs.opencover.reportsPaths="**/TestResults/**/coverage.opencover.xml" -d:sonar.cs.vstest.reportsPaths="**/TestResults/*.trx"
del OpenHSK.Domain.Test\TestResults /s /Q
dotnet test  --logger trx --collect:"XPlat Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover
dotnet build
dotnet sonarscanner end