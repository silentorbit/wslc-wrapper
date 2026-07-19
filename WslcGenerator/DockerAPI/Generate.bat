
dotnet tool install --global NSwag.ConsoleCore

nswag openapi2csclient ^
  /input:docker-api-v1.55.yaml ^
  /output:../../WslcWrapper/Docker/DockerModels.cs ^
  /namespace:SilentOrbit.WSLC.Docker ^
  /generateClientClasses:false ^
  /generateDataAnnotations:true ^
  /jsonLibrary:SystemTextJson