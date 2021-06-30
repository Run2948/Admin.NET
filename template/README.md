* 参考文档

  * [使用C#脚手架初始化自己的项目（以NetCore项目举例）](https://zhuanlan.zhihu.com/p/348550362)
  * [想创建自己的dotnet模板么？看这里](https://www.cnblogs.com/laozhang-is-phi/p/10205495.html)
  * [打造自己的.NET Core项目模板](https://www.cnblogs.com/catcher1994/p/10061470.html)
  * [Runnable Project Templates](https://github.com/dotnet/templating/wiki/Runnable-Project-Templates)
  * [.nuspec 引用](https://docs.microsoft.com/zh-cn/nuget/reference/nuspec)  - [NuGet.Client/**nuspec.xsd**](https://github.com/NuGet/NuGet.Client/blob/dev/src/NuGet.Core/NuGet.Packaging/compiler/resources/nuspec.xsd)

* 生成模板

  ```bash
  > dotnet new -i Admin.NETTemplate
  ```

* 卸载模板

  ```bash
  > dotnet new -u
  > dotnet new -u Admin.NETTemplate
  ```

*  创建工程

  ```bash
  # 查看可选参数
  > dotnet new feat -h
  Furion Extras AspNetCore Template (C#)
  Author: Run2948
  Options:
    -d|--dbType  The type of DbProvider to use
                     SqlServer    - Microsoft.EntityFrameworkCore.SqlServer
                     MySql        - Pomelo.EntityFrameworkCore.MySql
                     Oracle       - Oracle.EntityFrameworkCore
                     Npgsql       - Npgsql.EntityFrameworkCore.PostgreSQL
                     Sqlite       - Microsoft.EntityFrameworkCore.Sqlite
                 Default: Sqlite
  
  # 指定参数创建项目               
  > dotnet new feat -n My.Project -d MySql
  ```

* 生成Nupkg包

  ```bash
  nuget pack Admin.NETTemplate\Furion.Extras.AspNetCore.Template.nuspec
  ```

* 上传Nupkg包

  ```bash
  nuget push Furion.Extras.AspNetCore.Template.1.0.23.nupkg -ApiKey {Your Nuget Key} -Source https://api.nuget.org/v3/index.json
  ```

* 删除Nupkg包 (无法真正删除，只是设置为不展示)

  ```bash
  nuget delete Furion.Extras.AspNetCore.Template 1.0.23 -ApiKey {Your Nuget Key} -Source https://api.nuget.org/v3/index.json
  ```

  

