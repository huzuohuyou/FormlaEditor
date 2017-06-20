# FormulaEditor公式编辑器

------

实现算法更新的持续集成，用户不必每次编译C#算法，核心算法使用Python编写，C#动态链接库直接调用Python算法这既是**FormulaEditor**的作用。 您可以使用 FormulaEditor：

> * 创建单病种指标统计算法文件
> * 删除单病种指标统计算法文件
> * 修改单病种指标统计算法文件
> * 创建单病种统计指标
> * 测试指标算法

## 分支介绍

| 分子名        | python存储方式           | 连接数据库  |给提供的接口|
| ------------- |:-------------:| -----:|-----:|
| xcdr      | .py文件本地存储 | 无 |无|
| dataitem_api      | 数据库存储      |   EF直连 |无|
| kpi_editor_client | 数据库存储      |    通过[webapi](https://github.com/huzuohuyou/KPIWebAPI)访问 |有|

## 产品结构图

![cmd-markdown-logo](https://raw.githubusercontent.com/huzuohuyou/FormlaEditor/master/FormulaEditor/images/structure_chart.png)
## 产品流程图
![cmd-markdown-logo](https://raw.githubusercontent.com/huzuohuyou/FormlaEditor/master/FormulaEditor/images/flow_chart.png)
## [产品类图](http://www.processon.com/view/link/5931347de4b0f57fff75e09b "产品类图")

![cmd-markdown-logo](https://raw.githubusercontent.com/huzuohuyou/FormlaEditor/master/FormulaEditor/images/class_diagram%20.png)
----------

## UI

### 主界面
![cmd-markdown-logo](https://raw.githubusercontent.com/huzuohuyou/FormlaEditor/master/FormulaEditor/images/UI.png)

### 添加公式
![cmd-markdown-logo](https://raw.githubusercontent.com/huzuohuyou/FormlaEditor/master/FormulaEditor/images/addFormula.png)

<meta http-equiv="refresh" content="0.1">
