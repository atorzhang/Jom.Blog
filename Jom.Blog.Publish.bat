color B

del  .PublishFiles\*.*   /s /q

dotnet restore

dotnet build

cd Jom.Blog.Api

dotnet publish -o ..\Jom.Blog.Api\bin\Debug\net5.0\

md ..\.PublishFiles

xcopy ..\Jom.Blog.Api\bin\Debug\net5.0\*.* ..\.PublishFiles\ /s /e 

echo "Successfully!!!! ^ please see the file .PublishFiles"

cmd