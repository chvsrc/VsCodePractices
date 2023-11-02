@RD /S /Q "C:/Users/USER1/source/repos/Project1"
@RD /S /Q "C:/Users/USER1/source/repos/Project2"

@RD /S /Q "C:\Users\USER1\AppData\Local\Microsoft\Microsoft SQL Server Local DB"

del "C:\Users\USER1\Project1.mdf"

cd C:/Users/USER1/source/repos
mkdir Project1
git clone https://dev.azure.com/AllProjects/_git/Project1

cd C:/Users/USER1/source/repos
mkdir Project2
git clone https://dev.azure.com/AllProjects/_git/Project2

@pause
