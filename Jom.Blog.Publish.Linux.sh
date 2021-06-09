git pull;
rm -rf .PublishFiles;
dotnet build;
dotnet publish -o /home/Jom.Blog/Jom.Blog.Api/bin/Debug/net5.0;
cp -r /home/Jom.Blog/Jom.Blog.Api/bin/Debug/net5.0 .PublishFiles;
echo "Successfully!!!! ^ please see the file .PublishFiles";