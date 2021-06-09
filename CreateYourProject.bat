color 5
echo "if u install template error,pls use:>>dotnet new -i .template.config\Jom.Blog.Webapi.Template.2.5.2.nupkg"


color 3
dotnet new -i Jom.Blog.Webapi.Template::2.5.2

set /p OP=Please set your project name(for example:Baidu.Api):

md .1YourProject

cd .1YourProject

dotnet new blogcoretpl -n %OP%

cd ../


echo "Create Successfully!!!! ^ please see the folder .1YourProject"

dotnet new -u Jom.Blog.Webapi.Template


echo "Delete Template Successfully"

pause