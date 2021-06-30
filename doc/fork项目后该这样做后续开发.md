##  Fork项目后该怎样开发

### 需求描述

- 在我们 fork 了一个项目后, 我们需要自己开发一些独特的功能, 但同时需要随时更新原有项目的新功能怎么办?
- 有时, 我们突发奇想, 想给原先的项目提一个 Pull Requests 又该怎么办?

### 解决方案

#### 新建一个分支来维护自己的代码

- 首先, 我们需要给你的项目添加一个针对远程fork地址的 `upstream` 来更新远程的新代码

  - 通过命令执行: `git remote add upstream https://gitee.com/Run2948/Admin.NET.git`

  - 也可以直接在 config文件中添加

    ```
    [remote "upstream"]
    	url = https://gitee.com/Run2948/Admin.NET.git
    	fetch = +refs/heads/*:refs/remotes/upstream/*
    ```

- 其次, 我们不建议直接在 master 分支中直接写业务代码, 所以我们新建一个分支, 并切换到当前分支

  - `git checkout -b test`

- 在这里, 我们开始初始化我们的项目, 这里重点讲下DB和EF相关的东西

  - 先看下项目中是否存在 Db 文件, 如 : Admin.NET.db, Admin.NET_SaaS.db, 如果存在, 删除了

  - 看下 Admin.NET.Database.Migrations 项目下是否存在Migrations 文件夹, 存在的话, 删除了

  - 添加 migration

    - vs: `Add-Migration Init -Context DefaultDbContext`, **这里需要注意的是需要设置启动项和选择当前项目**, 这里可以看官方介绍
    - cmd: `dotnet ef migrations add Init -c DefaultDbContext -p Admin.NET.Database.Migrations/Admin.NET.Database.Migrations.csproj -s Admin.NET.Web.Entry/Admin.NET.Web.Entry.csproj`, **注意这个是在 `backend` 路径下执行, 同时需要全局安装 dotnet ef, 安装命令: `dotnet tool install --global dotnet-ef`**

  - 执行完成后, 会在 Admin.NET.Database.Migrations  项目下生成对应的文件

    ![image-20210429102344986](http://images.wynnyo.com/Markdown/image-20210429102344986.png?x-oss-process=style/wynnyo-style)

  - 这个文件以后是要在这个分支下维护的, 所以我们使用 `git add .` 把他加入到git中

    - 注: 由于 Migrations 文件夹是在.gitignore中的, 我们需要去把那一行注释掉, 然后再 add

      ````
      # /backend/Admin.NET.Database.Migrations/Migrations
      ````
    
  - 更新数据库 `update database`

    - vs: `update-database -Context DefaultDbContext`, 注意事项和上边一样
    - cmd: `dotnet ef database update -c DefaultDbContext -p Admin.NET.Database.Migrations/Admin.NET.Database.Migrations.csproj -s Admin.NET.Web.Entry/Admin.NET.Web.Entry.csproj`

  - 再执行下 `git add .`

  - 这时我们用 `git status -s` 查看下当前操作文件

    ![image-20210429104619672](http://images.wynnyo.com/Markdown/image-20210429104619672.png?x-oss-process=style/wynnyo-style)

  - 然后 commit, `git commit -m '初始化我的分支'`

    ![image-20210429105228967](http://images.wynnyo.com/Markdown/image-20210429105228967.png?x-oss-process=style/wynnyo-style)

  - 最后 push, `git push origin test`

    ![image-20210429105800853](http://images.wynnyo.com/Markdown/image-20210429105800853.png?x-oss-process=style/wynnyo-style)

  - 到这里我们新的分支便完成了, 我们以后可以愉快的玩耍了

#### 新增自己的业务代码

- 在 Admin.NET.Core 项目 Entity文件夹中新增实体

  ```c#
  [Table("b_test")]
  [Comment("业务测试表")]
  public class BTest: DEntityBase
  {
      /// <summary>
      /// 名称
      /// </summary>
      [Comment("编码")]
      public string Code { get; set; }
  
      /// <summary>
      /// 名称
      /// </summary>
      [Comment("名称")]
      public string Name { get; set; }
  }
  ```

- 添加 migration: `dotnet ef migrations add Add_BTest -c DefaultDbContext -p Admin.NET.Database.Migrations/Admin.NET.Database.Migrations.csproj -s Admin.NET.Web.Entry/Admin.NET.Web.Entry.csproj`

- 更新数据库: `dotnet ef database update -c DefaultDbContext -p Admin.NET.Database.Migrations/Admin.NET.Database.Migrations.csproj -s Admin.NET.Web.Entry/Admin.NET.Web.Entry.csproj`

- 注: 在这两个操作中**不要删除**以前的 DB 文件 和 migration 文件

- 使用代码生成器生成业务, 详细文档可以查看 [传送门](./代码生成器使用.md)

- git管理

  ```shell
  # 在根目录下依次执行
  git add .
  git status -s
  git commit -m 新增业务测试代码
  git push origin test
  ```

- 这样就完成了一次业务开发

#### 合并远程fork更新的新的内容

- 当发现fork地址有新的更新时, 你需要先切换到 master 分支

  ```shell
  git checkout master
  git branch -a
  ```

  ![image-20210429112622432](http://images.wynnyo.com/Markdown/image-20210429112622432.png?x-oss-process=style/wynnyo-style)

- 在当前分支下, 拉取 upstream 修改, 并推送到自己的 master 分支上

  ```shell
  git pull upstream master
  git push origin master
  ```

  ![image-20210429113257461](http://images.wynnyo.com/Markdown/image-20210429113257461.png?x-oss-process=style/wynnyo-style)

- 合并 master 分支到 test分支

  ```shell
  git checkout test
  git branch -a
  git merge master
  ```

  ![image-20210429114232845](http://images.wynnyo.com/Markdown/image-20210429114232845.png?x-oss-process=style/wynnyo-style)

  注: **在合并的时候可能会有冲突, 这个最好用ide合并**(基本每次都有, 因为master 那边没忽略 db)

  - 如果是 Db 冲突, **这里一定要保留自己分支的**

  借助ide解决冲突

  ![image-20210429114309378](http://images.wynnyo.com/Markdown/image-20210429114309378.png?x-oss-process=style/wynnyo-style)

- 合并完冲突后, 一般数据会有一些变化, 这时, 我们需要做的是更新我们自己的 Db, 如果可以确定没有改 db相关的可以忽略

  ```shell
  # Merge_Master 这个名字依次累加
  dotnet ef migrations add Merge_Master1 -c DefaultDbContext -p Admin.NET.Database.Migrations/Admin.NET.Database.Migrations.csproj -s Admin.NET.Web.Entry/Admin.NET.Web.Entry.csproj
  dotnet ef database update -c DefaultDbContext -p Admin.NET.Database.Migrations/Admin.NET.Database.Migrations.csproj -s Admin.NET.Web.Entry/Admin.NET.Web.Entry.csproj
  ```

- 最后来一套 git 操作即可

  ```shell
  git add .
  git status -s
  git commit -m 合并master代码
  git push origin test
  ```

#### 提交自己的 pr

- **这个操作要在 master分支上操作**

- 切换到master分支, 后面的简单git操作, 代码不再重复写了

- 修改代码, 完事一套git操作

- 打开自己fork 项目, 点击 Pull Request 按钮

  ![image-20210429120115979](http://images.wynnyo.com/Markdown/image-20210429120115979.png?x-oss-process=style/wynnyo-style)

  ![image-20210429120426121](http://images.wynnyo.com/Markdown/image-20210429120426121.png?x-oss-process=style/wynnyo-style)

- 点击创建等待审批即可
- 这时你的 test 分支最好等待审批过了再合并你的 master 分支

