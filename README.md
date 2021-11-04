<div align="center"><h1 align="center">Admin.NET</a></h1></div>
<div align="center"><h3 align="center">前后端分离架构，开箱即用，紧随前沿技术</h3></div>

<div align="center">

[![star](https://gitee.com/dotnetchina/Furion/badge/star.svg?theme=gvp)](https://gitee.com/dotnetchina/Furion/stargazers)
[![star](https://gitee.com/Run2948/Admin.NET/badge/star.svg?theme=dark)](https://gitee.com/Run2948/Admin.NET/stargazers)
[![fork](https://gitee.com/Run2948/Admin.NET/badge/fork.svg?theme=dark)](https://gitee.com/Run2948/Admin.NET/members)
[![GitHub stars](https://img.shields.io/github/stars/Run2948/Admin.NET?logo=github)](https://github.com/Run2948/Admin.NET/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/Run2948/Admin.NET?logo=github)](https://github.com/Run2948/Admin.NET/network)
[![GitHub license](https://img.shields.io/badge/license-Apache2-yellow)](https://gitee.com/dotnetchina/Furion/blob/master/LICENSE)

</div>

### 🍟 概述

* 基于.NET 5实现的通用管理平台。整合最新技术，模块插件式开发，前后端分离，开箱即用。
* 后台基于Furion框架，vue2前端基于小诺框架，vue3前端基于Vben-Admin框架。
* 集成EF Core、多租户、缓存、数据校验、鉴权、事件总线、动态API、通讯、远程请求、任务调度、gRPC等众多黑科技。
* 核心模块包括：用户、角色、职位、组织机构、菜单、字典、日志、多应用管理、文件管理、定时任务等功能。
* 代码简洁、易扩展，让开发更简单、更通用、更流行！
* QQ交流群：[87333204](https://jq.qq.com/?_wv=1027&k=1t8iqf0G)
```
如果对您有帮助，点击右上角⭐Star⭐关注 ，感谢支持开源！
```
[![Stargazers over time](https://whnb.wang/stars/Run2948/Admin.NET)](https://whnb.wang)

### 🍁 框架拓展包

|                                                                 包类型                                                                             | 名称                              |                                                                                 版本                                                                                                     | 描述                   |
| :------------------------------------------------------------------------------------------------------------------------------------------------: | -------------------------------- | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: | ---------------------- |
|       [![nuget](https://shields.io/badge/-Nuget-yellow?cacheSeconds=604800)](https://www.nuget.org/packages/Furion.Extras.AspNetCore/)              | Furion.Extras.AspNetCore          |              [![nuget](https://img.shields.io/nuget/v/Furion.Extras.AspNetCore.svg?cacheSeconds=10800)](https://www.nuget.org/packages/Furion.Extras.AspNetCore/)                          | Admin.NET 核心包       |

```
可自行按照 Furion 框架脚手架初始化工程，然后引用此包即可，其他层配置见源代码。🔊此包会紧跟Furion版本更新而更新。
```

### 🍀 框架脚手架

|                                                                 模板类型                                                                           | 名称                              |                                                                                 版本                                                                                                     | 描述                   |
| :------------------------------------------------------------------------------------------------------------------------------------------------: | -------------------------------- | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: | ---------------------- |
| [![nuget](https://shields.io/badge/-Nuget-yellow?cacheSeconds=604800)](https://www.nuget.org/packages/Furion.Extras.Mixed.Template/) | Furion.Extras.Mixed.Template | [![nuget](https://img.shields.io/nuget/v/Furion.Extras.Mixed.Template.svg?cacheSeconds=10800)](https://www.nuget.org/packages/Furion.Extras.Mixed.Template/) | Admin.NET 一体框架模板 |
|       [![nuget](https://shields.io/badge/-Nuget-yellow?cacheSeconds=604800)](https://www.nuget.org/packages/Furion.Extras.AspNetCore.Template/)        | Furion.Extras.AspNetCore.Template |              [![nuget](https://img.shields.io/nuget/v/Furion.Extras.AspNetCore.Template.svg?cacheSeconds=10800)](https://www.nuget.org/packages/Furion.Extras.AspNetCore.Template/)              | Admin.NET 框架模板  |
| [![nuget](https://shields.io/badge/-Nuget-yellow?cacheSeconds=604800)](https://www.nuget.org/packages/Furion.Extras.Vue.Template/) | Furion.Extras.Vue.Template | [![nuget](https://img.shields.io/nuget/v/Furion.Extras.Vue.Template.svg?cacheSeconds=10800)](https://www.nuget.org/packages/Furion.Extras.Vue.Template/) | Admin.Vue 框架模板 |

**一体后端脚手架  (femt)**

```
打开 CMD 或 Powershell 执行dotnet命令

1、安装脚手架
dotnet new --install Furion.Extras.Mixed.Template

2、更新脚手架
dotnet new --install Furion.Extras.Mixed.Template

3、查看手脚架
dotnet new femt -h

4、使用脚手架（生成之后推荐将所有的 nuget 包更新到最新版本）
dotnet new femt -d 你的数据库类型 -E 是否启用租户（true/false） -n 你的项目名称

其实安装之后可以直接在VS里面进行可视化及创建工程
```

**后端脚手架  (feat)**

```
打开 CMD 或 Powershell 执行dotnet命令

1、安装脚手架
dotnet new --install Furion.Extras.AspNetCore.Template

2、更新脚手架
dotnet new --install Furion.Extras.AspNetCore.Template

3、查看手脚架
dotnet new feat -h

4、使用脚手架（生成之后推荐将所有的 nuget 包更新到最新版本）
dotnet new feat -d 你的数据库类型 -n 你的项目名称

其实安装之后可以直接在VS里面进行可视化及创建工程
```

**前端脚手架 (fevt)**

```
打开 CMD 或 Powershell 执行dotnet命令

1、安装脚手架
dotnet new --install Furion.Extras.Vue.Template

2、更新脚手架
dotnet new --install Furion.Extras.Vue.Template

3、查看手脚架
dotnet new fevt -h

4、使用脚手架（生成之后推荐将所有的 nuget 包更新到最新版本）
dotnet new fevt -E 是否启用租户（true/false） -n 你的项目名称

```

### 🐱‍🚀 模块/插件化开发

* 按照 Furion 框架脚手架或者本框架脚手架初始化工程。
* 创建自己业务的 Dll 插件库工程，引用 Furion.Extras.Admin.NET 包，编写自己的业务代码包括实体、服务等。
* 在 XXX.Web.Entry 层里面的 appsettings.json 配置此插件 Dll 的路径。[配置文档说明](https://dotnetchina.gitee.io/furion/docs/module-dev)
* 此时框架和自己业务实体可以同时做数据迁移，耦合度最低。也可以自行将数据库分系统库、业务库等。
* 将自己业务前端代码包括view和api文件复制到前端工程相应目录即可。

`仓库内 plugin 文件内为本框架模块/插件开发事例，供参考。`

### 🎭 插件市场

`欢迎大家勇于参与开源，贡献自己的应用插件，你我都可以做到，.NET正在迅速崛起，我们都是历史的见证人💪`

【核酸采集系统】

<table>
    <tr>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/covid19-1.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/covid19-2.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/covid19-3.png"/></td>
    </tr>
</table>

### 🎁 前后端一体化

将后台提供的Swagger接口直接生成对应前端的API文件，前端再也不需要手撸一个个的对应后后的API定义了。后台接口更新后，只需要重新生成一遍覆盖即可。

详细教程见群里面视频文件【Fur课堂_20201028前后端（第1部份）.mp4】、【Fur课堂_20201028前后端（第2部份）.mp4】

<table>
    <tr>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/bf-01.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/bf-02.png"/></td>
    </tr>
</table>
`增加了Vue3.0、Vite、Antd、TypeScript模式的UI框架，希望大家来一来完善各页面应用，感谢💖💖💖`

### 👑 多租户简介

框架目前采用基于共享数据库TenantId的方式实现，后期可无缝迁移转换到基于多库或者Schema模式。

* 平台超管对租户进行增删改查操作，对各租户进行权限（菜单）的分配，租户管理员密码默认123456
* 租户管理员根据平台分配的权限再对本租户内用户进一步权限划分
* 针对新开发的业务功能，平台超管可以针对性分配给各租户（比如某租户购买后才有此功能菜单等） 

### 🥞 更新日志

更新日志 [点击查看](https://gitee.com/Run2948/Admin.NET/commits/master)

### 🍿 在线体验

`感谢安徽合肥的网友🎉微信号Protear🎉提供的云服务器`

- 体验地址：[http://www.dilon.vip:8866/](http://www.dilon.vip:8866/)
- 开发者租户：用户名：superAdmin，密码：123456
- 公司1租户： zhujinrun@163.com 密码：123456
  - 普通用户：用户名：feat@163.com 密码：123456）           

### 🍄 快速启动

需要安装：VS2019（最新版）、npm或yarn（最新版）

* 启动后台：打开 backend/Admin.NET.sln 解决方案，直接运行（F5）即可启动（数据库默认SQLite）
* 启动前端：VSCode或HBuilder，打开 frontend 文件夹，进行依赖下载，运行 npm install 或 yarn install 命令，再运行npm run serve 或 yarn run serve
* 浏览器访问：`http://localhost:81` （默认前端端口为：81，后台端口为：5566）
<table>
    <tr>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/f1.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/f0.png"/></td>
    </tr>
</table>

### 🏀 分层说明
```
├─Admin.NET.Application             ->业务应用层，在此写您具体业务代码
├─Admin.NET.Core                    ->框架核心层
├─Admin.NET.Database.Migrations     ->架构维护层，主要存放迁移中间文件
├─Admin.NET.EntityFramework.Core    ->EF Core配置层，主要配置数据库及相关
├─Admin.NET.Web.Core                ->Web核心层，主要是服务注册及鉴权
├─Admin.NET.Web.Entry               ->Web入口层/启动层，可任意更换
├─Furion.Extras.Admin.NET           ->封装的框架核心层，已做成NuGet包
注：源码直接开发建议自己的业务代码直接写在【Admin.NET.Application】层里面，可随框架升级减少冲突。或直接用模板脚手架创建自己的工程。
```

### 📖 帮助文档

👉后台文档：
* Furion后台框架文档 [https://dotnetchina.gitee.io/furion/docs/source](https://dotnetchina.gitee.io/furion/docs/source)

👉前端文档：
* 小诺前端业务文档 [https://doc.xiaonuo.vip/snowy_vue/bizs/](https://doc.xiaonuo.vip/snowy_vue/bizs/)

1. Ant Design Pro of Vue 使用文档 [https://pro.antdv.com/docs/getting-started](https://pro.antdv.com/docs/getting-started)
2. Ant Design of Vue 组件文档 [https://www.antdv.com/docs/vue/getting-started-cn/](https://www.antdv.com/docs/vue/getting-started-cn/)
3. Vue 开发文档 [https://cn.vuejs.org/v2/guide/](https://cn.vuejs.org/v2/guide/)

👉快捷部署到 linux 文档：

- [Admin.NET 快捷部署到 linux 方案 | Wynnyo Blog](http://wynnyo.com/archives/publish-linux)
- [本地 md文件](./build/readme.md)

👉代码生成器使用教程：

- [本地 md文件](./doc/代码生成器使用.md)

👉fork项目后该这样做后续开发：

- [本地 md文件](./doc/fork项目后该这样做后续开发.md)

👉关于signalr使用：

-  [wynnyo/vue-signalr: Signalr client for vue js (github.com)](https://github.com/wynnyo/vue-signalr)

😎通读以上文档，您就可以玩转本项目了（其实您已经是高手了）。项目使用上的问题，文档中基本都可以找到答案。


### 🍎 效果图

<table>
    <tr>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/1.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/2.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/3.png"/></td>
    </tr>
    <tr>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/4.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/5.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/6.png"/></td>
    </tr>
    <tr>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/7.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/8.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/9.png"/></td>
    </tr>
    <tr>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/10.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/11.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/12.png"/></td>
    </tr>
    <tr>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/13.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/14.png"/></td>
        <td><img src="https://gitee.com/Run2948/Admin.NET/raw/master/doc/img/15.png"/></td>
    </tr>
</table>

### 🍖 详细功能

1. 主控面板、控制台页面，可进行工作台，分析页，统计等功能的展示。
2. 用户管理、对企业用户和系统管理员用户的维护，可绑定用户职务，机构，角色，数据权限等。
3. 应用管理、通过应用来控制不同维度的菜单展示。
4. 机构管理、公司组织架构维护，支持多层级结构的树形结构。
5. 职位管理、用户职务管理，职务可作为用户的一个标签，职务目前没有和权限等其他功能挂钩。
6. 菜单管理、菜单目录，菜单，和按钮的维护是权限控制的基本单位。
7. 角色管理、角色绑定菜单后，可限制相关角色的人员登录系统的功能范围。角色也可以绑定数据授权范围。
8. 字典管理、系统内各种枚举类型的维护。
9. 访问日志、用户的登录和退出日志的查看和管理。
10. 操作日志、用户的操作业务的日志的查看和管理。
11. 服务监控、服务器的运行状态，CPU、内存、网络等信息数据的查看。
12. 在线用户、当前系统在线用户的查看。
13. 公告管理、系统的公告的管理。
14. 文件管理、文件的上传下载查看等操作，文件可使用本地存储，阿里云oss，腾讯cos接入，支持拓展。
15. 定时任务、定时任务的维护，通过cron表达式控制任务的执行频率。
16. 系统配置、系统运行的参数的维护，参数的配置与系统运行机制息息相关。
17. 邮件发送、发送邮件功能。
18. 短信发送、短信发送功能，可使用阿里云sms，腾讯云sms，支持拓展。


### 💪 数据库操作

本框架ORM默认采用EF Core开发，理论上兼容并支持所有类型数据库。😜 目前支持所有的数据库类型可通过脚手架命令查看：

```cmd
> dotnet new feat -h

Furion Extras AspNetCore Template (C#)
作者: Run2948
选项:
  -d|--dbType  The type of DbProvider to use
                   SqlServer    - Microsoft.EntityFrameworkCore.SqlServer
                   MySql        - Pomelo.EntityFrameworkCore.MySql
                   Oracle       - Oracle.EntityFrameworkCore
                   Npgsql       - Npgsql.EntityFrameworkCore.PostgreSQL
                   Sqlite       - Microsoft.EntityFrameworkCore.Sqlite
               默认: Sqlite
```
【数据库初始化操作】

1.  启动项目设置为 `XXXX.Web.Entry`
2.  程序包管理控制台默认项目设置为 `XXXX.Database.Migrations`
3.  程序包管理控制台依次输入并回车执行
```cmd
Add-Migration Init -Context DefaultDbContext
Update-Database Init -Context DefaultDbContext 

Add-Migration Init -Context MultiTenantDbContext
Update-Database Init -Context MultiTenantDbContext
```
4. 后期添加/修改自己业务的数据类后通过更新版本号来更新数据库即可。

```cmd
Add-Migration v1.0.1 -Context DefaultDbContext
Update-Database v1.0.1 -Context DefaultDbContext 
    
Add-Migration v1.0.1 -Context MultiTenantDbContext
Update-Database v1.0.1 -Context MultiTenantDbContext
```
【EF批量操作】

 使用 [Zack.EFCore.Batch](https://hub.fastgit.org/yangzhongke/Zack.EFCore.Batch) 实现，使用脚手架创建项目时选择对应的数据库类型即可自动下载安装
1. MSSQL：Zack.EFCore.Batch.MSSQL
2. MySql：Zack.EFCore.Batch.MySQL.Pomelo
3. Npgsql：Zack.EFCore.Batch.Npgsql
4. Oracle：Zack.EFCore.Batch.Oracle
5. Sqlite：Zack.EFCore.Batch.Sqlite

### ⚡ 近期计划

- [x] 集成多租户功能
- [x] 集成代码生成器
- [x] 集成导入导出
- [x] 在线用户及黑名单
- [ ] 邮件发送
- [ ] 短信发送
- [ ] 集成微信开发
- [ ] 实现电商应用插件
- [ ] 集成工作流

### 🥦 补充说明

* 基于.NET 5平台 Furion 开发框架与小诺Antd Vue版本相结合，实时跟随基架升级而升级！
* 持续集百家所长，完善与丰富本框架基础设施，为.NET生态增加一种选择！
* 后期会推出基于此框架的相关应用场景案例，提供给大家使用！
* 有问题讨论的小伙伴可加群一起学习讨论。 QQ群1【87333204】 QQ群2【252381476】

### 🍻 贡献代码

`Admin.NET` 遵循 `Apache-2.0` 开源协议，欢迎大家提交 `PR` 或 `Issue`。

感谢每一位贡献代码的朋友。**感谢 [TLog 作者](https://gitee.com/bryan31) 提供的贡献者实时头像。**

[![Giteye chart](https://chart.giteye.net/gitee/zuohuaijun/Admin.NET/JRFF5WLM.png)](https://giteye.net/chart/JRFF5WLM)

### 💐 特别鸣谢

- 👉 Furion：  [https://dotnetchina.gitee.io/furion](https://dotnetchina.gitee.io/furion)
- 👉 xiaonuo：[https://gitee.com/xiaonuobase/snowy](https://gitee.com/xiaonuobase/snowy)
- 👉 Vben-Admin：[https://vvbin.cn/doc-next/](https://vvbin.cn/doc-next/)
- 👉 k-form-design：[https://gitee.com/kcz66/k-form-design](https://gitee.com/kcz66/k-form-design)
- 👉 MiniExcel：[https://gitee.com/dotnetchina/MiniExcel](https://gitee.com/dotnetchina/MiniExcel)
- 👉 SqlSugar：[https://gitee.com/dotnetchina/SqlSugar](https://gitee.com/dotnetchina/SqlSugar)
- 👉 IdGenerator：[https://github.com/yitter/idgenerator](https://github.com/yitter/idgenerator)
- 👉 ua-parser：[https://github.com/ua-parser/uap-csharp/](https://github.com/ua-parser/uap-csharp/)
- 👉 Zack.EFCore.Batch：[https://github.com/yangzhongke/Zack.EFCore.Batch](https://github.com/yangzhongke/Zack.EFCore.Batch)
- 👉 OnceMi.AspNetCore.OSS：[https://github.com/oncemi/OnceMi.AspNetCore.OSS](https://github.com/oncemi/OnceMi.AspNetCore.OSS)

如果对您有帮助，您可以点右上角 💘Star💘支持一下，这样我们才有持续下去的动力，谢谢！！！