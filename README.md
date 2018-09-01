# ExcelTools
Motion ExcelTools是一个表格导出工具。可以帮助策划把Excel表格导出为二进制文件（.bytes）和文本文件（.txt），并自动生产客户端和服务器读取的代码文件（.cs）。

## 特点
1. 支持定义各类数值，列表，枚举，BOOL，字符串，自定义结构。几乎可以满足策划所有格式需求。
2. 一键导出客户端，逻辑服务器，战斗服务器文件。
3. 相比各类传统文本格式，生成的二进制文件平均节省40%大小。
4. 字节流的解析方式，速度非常快，全程零GC。
5. 不依赖于任何库，核心源代码只有八百行。

## 工程
VS2017 && .net framework 4.6
NuGet package : NPOI
NuGet package : SharpZipLib

## 说明
![image](https://github.com/gmhevinci/ExcelTools/raw/master/image.JPG?imageMogr2/auto-orient/strip)

1. 第一行为导出名称：代码里的字段名称，首字母会自动生成为大写。
2. 第二行为导出类型
3. 第三行为类型补充：只有枚举和自定义结构需要。
4. 第四行为导出标记：C客户端，B战斗服务器，S逻辑服务器。

## 注意事项
1. 需要导出的Excel页签，其名称前需要加前缀t_
2. Excel结尾的地方需要加//end
3. 表格里的策划备注列不会被导出。
4. 枚举类型支持索引值或索引名字，选择索引名字的优点是在程序改动枚举值时表格不需要改动，而且索引名称更加直观。
5. wrapper类型为自定义结构，详细请见教程文档。
6. 枚举类型目前不支持list
