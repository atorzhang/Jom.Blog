﻿dotnet restore
dotnet build 
cd Jom.Blog.Api

dotnet publish 
echo "Successfully!!!! ^ please see the file ."
cd bin/Debug/net5.0/publish/

#rm -f appsettings.json
#\cp -rf /var/jenkins_home/workspace/SecurityConfig/Jom.Blog/appsettings.json appsettings.json

#docker stop apkcontainer
#docker rm apkcontainer
#docker rmi laozhangisphi/apkimg

chmod 777 StopContainerImg.sh
./StopContainerImg.sh apkcontainer laozhangisphi/apkimg

docker build -t laozhangisphi/apkimg .
docker run --name=apkcontainer -d -v /data/blogcore/appsettings.json:/app/appsettings.json -v /data/blogcore/Log/:/app/Log -v /etc/localtime:/etc/localtime -it -p 8081:8081 laozhangisphi/apkimg