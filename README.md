# InkFx.Express


**表达式计算算法**
<br/>
<br/>




[http://www.ink-fx.com/Source/38217B17B1774A2F80788496617E4246](http://www.ink-fx.com/Source/38217B17B1774A2F80788496617E4246)

![](http://ink-fx.com/Resources/Upload/ImgurFolder/190317/190317201641.png)

<br/>
<br/>






《『2015』InkFx.Express 表达式编程》

[http://ink-fx.com/Project/InkFx.Express/](http://ink-fx.com/Project/InkFx.Express/) 

![](http://ink-fx.com/Resources/Upload/ImgurFolder/190317/190317201343.png)

<br/>
<br/>






《『开源』也顺手写一个 科学计算器：重磅开源》

[https://www.cnblogs.com/shuxiaolong/p/20131112_001.html](https://www.cnblogs.com/shuxiaolong/p/20131112_001.html)  

![](http://ink-fx.com/Resources/Upload/ImgurFolder/190317/190317201350.png)





<br/>
<br/>
<br/>
<br/>
<br/>
<br/>
<br/>



<font color=#FFFFFF size=10px face="宋体">InkFx.Express
</font><br/><font color=#FFFFFF size=10px face="宋体">    ——最稳、最快、最易扩展的 表达式算法框架
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">Logo 表达式: 	REPLACE('InkFx.Express - Love Java.', 'Love Java', 'Love C#')
</font><br/><font color=#FFFFFF size=10px face="宋体">Logo 值: 	InkFx.Express - Love C#.
</font><br/><font color=#FFFFFF size=10px face="宋体">==================================================
</font><br/><font color=#FFFFFF size=10px face="宋体">按任意键 开始 InkFx.Express 性能测试...
</font><br/><font color=#FFFFFF size=10px face="宋体">==================================================
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 错误的表达式分析--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">以下表达式 发生异常, 即为测试通过.
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FF0000 size=10px face="宋体">执行 表达式: ZhangSan + LiSi 发生异常
</font><br/><font color=#FF0000 size=10px face="宋体">异常信息:未知的表达式片段或常量 'ZhangSan'.
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FF0000 size=10px face="宋体">执行 表达式: DoMethod('ZhangSan'+ ' | ' + 'LiSi') 发生异常
</font><br/><font color=#FF0000 size=10px face="宋体">异常信息:未知的表达式片段或常量 'DoMethod'.
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FF0000 size=10px face="宋体">执行 表达式: AskMarry('ZhangSan ', 'LiSi') 发生异常
</font><br/><font color=#FF0000 size=10px face="宋体">异常信息:未知的表达式片段或常量 'AskMarry'.
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FF0000 size=10px face="宋体">执行 表达式: ## 发生异常
</font><br/><font color=#FF0000 size=10px face="宋体">异常信息:未知的表达式片段或常量 '##'.
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FF0000 size=10px face="宋体">执行 表达式: AAA 发生异常
</font><br/><font color=#FF0000 size=10px face="宋体">异常信息:未知的表达式片段或常量 'AAA'.
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FF0000 size=10px face="宋体">执行 表达式: PI + TestInfo 发生异常
</font><br/><font color=#FF0000 size=10px face="宋体">异常信息:未知的表达式片段或常量 'TestInfo'.
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FF0000 size=10px face="宋体">执行 表达式: ＃￥％……＆％￥……（…………＆$%^&amp;PI_123$+INFO哈哈３２１２３４＃￥＠！＠＃％＆ 发生异常
</font><br/><font color=#FF0000 size=10px face="宋体">异常信息:未知的表达式片段或常量 '＃￥％……＆％￥……（…………＆$'.
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: '版权信息:' + COPYRIGHT 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 版权信息:InkFx.Express © ShuXiaolong 2015 QQ:514286339 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">==================================================
</font><br/><font color=#FF1493 size=10px face="宋体">-- 数据准备 对象集合(集合总数: 15328)--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FFFFFF size=10px face="宋体">Word 	Mean 	Demo 
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FFFFFF size=10px face="宋体">A 	a.一,一个,一只,一件. 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">a.m. 	上午&lt;br&gt;</font><br/><font color=#FFFFFF size=10px face="宋体">abbr. (ante meridiem的缩写)上午,午前&lt;br&gt;</font><br/><font color=#FFFFFF size=10px face="宋体">ad. 上午,由午夜至中午 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">abacus 	n. 算盘 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">abandon 	v. 放弃,遗弃,沉溺 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">abatement 	n. 减少,减轻,缓和 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">abbreviate 	v. 缩写,使...简略 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">abbreviation 	n. 缩写 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">ABC 	n. 基本要素,字母表&lt;br&gt;</font><br/><font color=#FFFFFF size=10px face="宋体">abbr. 美国广播公司&lt;br&gt;</font><br/><font color=#FFFFFF size=10px face="宋体">abbr. 澳大利亚广播公司 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">abdomen 	n. 腹部 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">abdominal 	a. 腹部的 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">abend 	异常结束 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">abide 	v. 遵守,忍受,居留 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">ability 	n. 才能,能力 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">able 	a. 能干的,有能力的 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">abnormal 	a. 反常的,不正常的,不规则的 	 
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 表达式的 集合检索--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Word] LIKE 'cat%' 
</font><br/><font color=#FFFFFF size=10px face="宋体">原始集合: 15328 筛选集合: 16
</font><br/><font color=#FFFFFF size=10px face="宋体">, 耗时 344.0197 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 44555.59 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Word] LIKE '%cat%g' 
</font><br/><font color=#FFFFFF size=10px face="宋体">原始集合: 15328 筛选集合: 4
</font><br/><font color=#FFFFFF size=10px face="宋体">, 耗时 236.0135 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 64945.44 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: ([Demo] LIKE '%三%') OR ([Mean] LIKE '%三%') 
</font><br/><font color=#FFFFFF size=10px face="宋体">原始集合: 15328 筛选集合: 189
</font><br/><font color=#FFFFFF size=10px face="宋体">, 耗时 697.0399 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 21990.13 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: ([Demo] LIKE '%四%') OR ([Mean] LIKE '%四%') 
</font><br/><font color=#FFFFFF size=10px face="宋体">原始集合: 15328 筛选集合: 148
</font><br/><font color=#FFFFFF size=10px face="宋体">, 耗时 688.0394 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 22277.79 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 表达式的 集合排序--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Word] 
</font><br/><font color=#FFFFFF size=10px face="宋体">原始集合: 15328 排序集合: 15328
</font><br/><font color=#FFFFFF size=10px face="宋体">, 耗时 857.049 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 17884.63 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Word] ASC 
</font><br/><font color=#FFFFFF size=10px face="宋体">原始集合: 15328 排序集合: 15328
</font><br/><font color=#FFFFFF size=10px face="宋体">, 耗时 543.0311 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 28226.74 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Mean] DESC 
</font><br/><font color=#FFFFFF size=10px face="宋体">原始集合: 15328 排序集合: 15328
</font><br/><font color=#FFFFFF size=10px face="宋体">, 耗时 771.0441 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 19879.54 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Word] DESC,[Mean] ASC 
</font><br/><font color=#FFFFFF size=10px face="宋体">原始集合: 15328 排序集合: 15328
</font><br/><font color=#FFFFFF size=10px face="宋体">, 耗时 776.0444 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 19751.45 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Demo] ASC 
</font><br/><font color=#FFFFFF size=10px face="宋体">原始集合: 15328 排序集合: 15328
</font><br/><font color=#FFFFFF size=10px face="宋体">, 耗时 666.0381 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 23013.7 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Word],[Mean],[Demo] 
</font><br/><font color=#FFFFFF size=10px face="宋体">原始集合: 15328 排序集合: 15328
</font><br/><font color=#FFFFFF size=10px face="宋体">, 耗时 928.0531 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 16516.3 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">==================================================
</font><br/><font color=#FF1493 size=10px face="宋体">-- 数据准备 对象集合--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FFFFFF size=10px face="宋体">Name 	Number 	Age 	Department 
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FFFFFF size=10px face="宋体">张三 	ZhangSan 	19 	InkFx.Express.Test.Department 
</font><br/><font color=#FFFFFF size=10px face="宋体">李四 	LiSi 	18 	InkFx.Express.Test.Department 
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 表达式的 对象属性计算01--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Department.School.Name] == '李湾小学' 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: True
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [this][1] 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: InkFx.Express.Test.Student
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Number] LIKE '%Zhang%'   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 
</font><br/><font color=#FFFFFF size=10px face="宋体">True
</font><br/><font color=#FFFFFF size=10px face="宋体">False 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4284.2451 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 1947.1113 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2334.13 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 102716.26 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [this].[Name] + '|' + [this].[Number]   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 
</font><br/><font color=#FFFFFF size=10px face="宋体">张三|ZhangSan
</font><br/><font color=#FFFFFF size=10px face="宋体">李四|LiSi 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7459.4266 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 1629.0932 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1340.59 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 122767.68 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [this].[Department].[School].[Name] == '李湾小学'   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 
</font><br/><font color=#FFFFFF size=10px face="宋体">False
</font><br/><font color=#FFFFFF size=10px face="宋体">True 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7458.4266 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 1921.1099 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1340.77 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 104106.49 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [this].[Department].[School].[Name] + ' | ' + [this].[Department].[Name] + ' | ' + [this].[Name]   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 
</font><br/><font color=#FFFFFF size=10px face="宋体">张湾小学 | 理科 | 张三
</font><br/><font color=#FFFFFF size=10px face="宋体">李湾小学 | 文科 | 李四 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 16635.9515 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 4395.2514 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 601.11 /s, 性能低于 预期 1000 /s
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 45503.65 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 表达式的 对象属性计算02--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">测试 用户参数:
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FFFFFF size=10px face="宋体">李四 	LiSi 	18 	InkFx.Express.Test.Department 
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Department.School.Name] == '李湾小学' 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: True 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [Department].[School].[Name] == '李湾小学' 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: True 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [this].[Department].[School].[Name] == '李湾小学' 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: True 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">测试 用户参数 (索引参数):
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FFFFFF size=10px face="宋体">张三 	ZhangSan 	19 	InkFx.Express.Test.Department 
</font><br/><font color=#FFFFFF size=10px face="宋体">李四 	LiSi 	18 	InkFx.Express.Test.Department 
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [this][1].[Department.School.Name] 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 李湾小学 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: [this][1].[Department].[School].[Name] 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 李湾小学 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">==================================================
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 时间函数表达式 01 (完全兼容SQLServer语法)--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(YEAR, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2026/12/14 11:55:19 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5391.3083 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 248.0142 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1854.84 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 403202.72 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(YY, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2026/12/14 11:55:24 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4942.2827 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 241.0138 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2023.36 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 414914 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(YYYY, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2026/12/14 11:55:30 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5342.3056 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 254.0145 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1871.85 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 393678.31 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(QUARTER, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2019/6/14 11:55:36 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5678.3248 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 408.0233 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1761.08 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 245084.04 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(QQ, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2019/6/14 11:55:42 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5281.3021 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 262.0149 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1893.47 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 381657.68 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(Q, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2019/6/14 11:55:47 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5200.2974 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 338.0193 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1922.97 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 295841.1 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(MONTH, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2017/10/14 11:55:53 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5765.3298 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 266.0152 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1734.51 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 375918.37 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(MM, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2017/10/14 11:56:00 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5810.3324 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 292.0167 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1721.07 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 342446.17 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(M, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2017/10/14 11:56:05 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4989.2854 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 265.0152 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2004.3 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 377336.85 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(DAYOFYEAR, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/24 11:56:11 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5865.3354 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 241.0138 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1704.93 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 414914 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(DY, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/24 11:56:16 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4976.2846 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 236.0135 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2009.53 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 423704.58 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(Y, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/24 11:56:21 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4919.2814 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 239.0136 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2032.82 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 418386.23 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(DAY, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/24 11:56:27 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5143.2941 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 250.0143 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1944.28 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 399977.12 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(DD, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/24 11:56:32 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5251.3004 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 233.0133 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1904.29 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 429160.05 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(D, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/24 11:56:38 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5320.3043 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 254.0145 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1879.59 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 393678.31 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(WEEK, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2017/2/22 11:56:44 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5416.3097 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 250.0143 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1846.28 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 399977.12 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(WK, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2017/2/22 11:56:49 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5128.2933 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 275.0157 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1949.97 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 363615.6 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(WW, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2017/2/22 11:56:55 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5338.3054 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 246.014 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1873.25 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 406480.93 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(WEEKDAY, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/24 11:57:00 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5570.3186 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 308.0177 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1795.23 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 324656.67 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(DW, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/24 11:57:06 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5052.2889 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 249.0143 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1979.3 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 401583.36 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(HOUR, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 21:57:11 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5270.3015 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 333.019 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1897.42 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 300283.17 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(HH, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 21:57:17 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5218.2985 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 254.0145 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1916.33 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 393678.31 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(MINUTE, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 12:07:23 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6047.3459 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 288.0164 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1653.62 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 347202.45 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(MI, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 12:07:29 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5267.3013 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 254.0145 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1898.51 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 393678.31 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(N, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 12:07:34 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5026.2875 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 249.0143 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1989.54 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 401583.36 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(SECOND, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 11:57:50 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5605.3206 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 252.0144 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1784.02 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 396802.72 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(SS, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 11:57:56 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5418.3099 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 276.0158 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1845.59 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 362298.1 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(S, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 11:58:01 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4963.2839 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 260.0149 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2014.8 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 384593.34 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(MILLISECOND, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 11:57:58 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6473.3703 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 337.0192 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1544.79 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 296719 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(MS, 10, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 11:58:03 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5370.3071 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 289.0166 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1862.09 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 346000.89 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(YEAR, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 116 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6411.3667 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 623.0356 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1559.73 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 160504.47 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(YY, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 116 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6101.349 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 558.0319 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1638.98 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 179201.22 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(YYYY, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 116 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6245.3572 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 616.0352 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1601.19 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 162328.39 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(QUARTER, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 468 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6761.3867 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 648.0371 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1478.99 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 154312.15 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(QQ, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 468 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6310.3609 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 705.0403 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1584.7 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 141835.86 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(Q, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 468 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5936.3396 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 627.0358 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1684.54 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 159480.53 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(MONTH, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1403 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6814.3898 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 671.0384 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1467.48 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 149022.77 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(MM, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1403 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6404.3664 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 627.0358 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1561.43 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 159480.53 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(M, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1403 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5883.3365 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 702.0401 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1699.72 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 142442.01 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(DAYOFYEAR, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42716 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7017.4014 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 563.0322 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1425.03 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 177609.74 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(DY, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42716 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5993.3428 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 581.0332 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1668.52 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 172107.2 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(Y, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42716 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5876.3361 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 568.0325 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1701.74 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 176046.26 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(DAY, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42716 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6335.3623 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 588.0336 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1578.44 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 170058.31 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(DD, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42716 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5998.3431 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 564.0323 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1667.13 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 177294.81 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(D, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42716 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5926.339 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 570.0326 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1687.38 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 175428.56 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(WEEK, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 6102 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6187.3539 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 666.0381 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1616.2 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 150141.56 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(WK, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 6102 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6993.4 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 602.0344 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1429.92 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 166103.47 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(WW, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 6102 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7480.4278 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 980.0561 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1336.82 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 102034.98 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(WEEKDAY, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42716 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6766.3871 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 809.0462 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1477.89 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 123602.34 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(DW, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42716 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 8423.4818 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 1050.0601 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1187.16 /s, 性能满足 预期 1000 /s
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 95232.64 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(HOUR, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1025196 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 10159.5811 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 1094.0626 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 984.29 /s, 性能低于 预期 1000 /s
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 91402.45 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(HH, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1025196 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 9763.5584 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 1045.0598 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1024.22 /s, 性能满足 预期 1000 /s
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 95688.3 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(MINUTE, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 61511761 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 9899.5663 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 1062.0607 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1010.15 /s, 性能满足 预期 1000 /s
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 94156.58 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(MI, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 61511761 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 9016.5157 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 893.0511 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1109.08 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 111975.68 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(N, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 61511761 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 8234.471 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 908.0519 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1214.41 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 110125.86 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(SECOND, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 3690705689 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 9034.5167 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 907.0519 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1106.87 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 110247.27 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(SS, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 3690705698 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 8371.4788 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 911.0521 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1194.53 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 109763.21 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(S, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 3690705707 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 8271.4731 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 880.0503 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1208.97 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 113629.87 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(MILLISECOND, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 3690705718811 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 9877.565 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 1004.0574 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1012.4 /s, 性能满足 预期 1000 /s
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 99595.9 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(MS, '1900-01-01', GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 3690705728735 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 8722.4989 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 1188.068 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1146.46 /s, 性能满足 预期 1000 /s
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 84170.27 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(YEAR, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6397.3659 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 297.017 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1563.14 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 336681.07 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(YY, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6503.372 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 275.0157 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1537.66 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 363615.6 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(YYYY, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7176.4105 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 346.0198 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1393.45 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 289000.8 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(QUARTER, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 4 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6733.3851 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 320.0183 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1485.14 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 312482.13 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(QQ, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 4 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6119.35 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 283.0162 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1634.16 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 353336.66 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(Q, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 4 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6059.3466 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 332.0189 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1650.34 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 301187.67 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(MONTH, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 12 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6701.3833 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 343.0196 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1492.23 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 291528.53 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(MM, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 12 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6274.3588 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 335.0192 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1593.79 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 298490.36 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(M, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 12 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6194.3543 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 400.0229 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1614.37 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 249985.69 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(DAYOFYEAR, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 349 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7563.4327 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 376.0215 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1322.15 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 265942.24 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(DY, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 349 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6473.3702 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 336.0193 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1544.79 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 297601.95 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(Y, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 349 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6087.3482 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 353.0202 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1642.75 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 283269.91 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(DAY, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 14 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6459.3695 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 322.0184 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1548.14 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 310541.26 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(DD, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 14 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6367.3642 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 408.0234 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1570.51 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 245083.98 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(D, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 14 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6110.3494 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 345.0198 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1636.57 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 289838.44 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(WEEK, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 51 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6582.3765 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 459.0262 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1519.21 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 217852.49 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(WK, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 51 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6149.3517 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 424.0243 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1626.19 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 235835.54 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(WW, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 51 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6497.3717 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 415.0237 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1539.08 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 240950.1 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(WEEKDAY, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 4 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6706.3836 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 377.0215 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1491.12 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 265236.86 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(DW, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 4 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5951.3404 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 349.0199 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1680.29 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 286516.61 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(HOUR, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 12 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 8601.492 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 550.0315 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1162.59 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 181807.77 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(HH, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 12 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 8895.5088 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 390.0223 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1124.16 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 256395.6 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(MINUTE, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 4 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 9663.5528 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 506.0289 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1034.82 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 197617.17 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(MI, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 5 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 9211.5269 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 513.0294 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1085.6 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 194920.6 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(N, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 5 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6623.3789 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 366.0209 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1509.8 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 273208.44 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(SECOND, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 18 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7220.413 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 439.0251 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1384.96 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 227777.41 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(SS, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 26 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7293.4172 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 466.0266 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1371.1 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 214580.03 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(S, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 33 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6810.3896 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 368.021 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1468.34 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 271723.62 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(MILLISECOND, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 781 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7955.4551 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 433.0247 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1257 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 230933.71 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(MS, GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 584 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6373.3646 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 416.0238 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1569.03 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 240370.86 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: YEAR(GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4463.2552 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 138.0079 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2240.52 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 724596.2 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: MONTH(GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 12 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4741.2712 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 141.008 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2109.14 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 709179.62 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DAY(GETDATE())   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 14 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4626.2646 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 166.0095 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2161.57 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 602375.17 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: GETDATE()   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 12:06:06 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 3018.1726 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 53.003 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 3313.26 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1886685.66 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: GETUTCDATE()   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 4:06:09 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 3105.1776 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 27.0016 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 3220.43 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 3703484.24 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: ISDATE('1900-01-01')   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4875.2788 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 8.0005 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2051.16 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 12499218.8 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 时间函数表达式 02 (完全兼容SQLServer语法)--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: GETDATE ( ) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016/12/14 12:06:14 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(YEAR, '1989-12-24') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1989 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 10 + (DATEPART(YEAR, '1989-12-24')) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1999 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 时间函数表达式 03 (完全兼容SQLServer语法)--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: PI 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 3.14159265358979 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: E 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2.71828182845905 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 10 + (PI + DATEPART(MONTH, '1989-12-24')) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 25.1415926535898 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: E+10 + (PI + DATEPART(MONTH, '1989-12-24')) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 27.8598744820488 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: E+10 + (PI + DATEPART(MONTH, '1989-12-24')) + 12.232E-3 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 27.8721064820488 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: LEN("INK" + GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 22 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: LEN("INK" + GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 22 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: LEN("INK" + GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 22 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 时间函数表达式 04 (完全兼容SQLServer语法)--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(YEAR, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2016 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(QUARTER, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 4 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(MONTH, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 12 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(DAYOFYEAR, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 349 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(DAY, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 14 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(WEEK, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 51 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(WEEKDAY, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 4 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(WEEKDAY, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 4 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(HOUR, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 12 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(MINUTE, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 6 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(SECOND, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 14 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEPART(MILLISECOND, GETDATE()) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 254 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 时间函数表达式 05 (完全兼容SQLServer语法)--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(YEAR, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2900/1/1 0:00:00 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(QUARTER, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 2150/1/1 0:00:00 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(MONTH, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1983/5/1 0:00:00 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(DAYOFYEAR, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1902/9/28 0:00:00 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(DAY, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1902/9/28 0:00:00 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(WEEK, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1919/3/3 0:00:00 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(WEEKDAY, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1902/9/28 0:00:00 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(HOUR, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1900/2/11 16:00:00 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(MINUTE, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1900/1/1 16:40:00 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(SECOND, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1900/1/1 0:16:40 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEADD(MILLISECOND, 1000, '1900-01-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1900/1/1 0:00:01 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 时间函数表达式 06 (完全兼容SQLServer语法)--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(YEAR, '1900-01-01', '2015-11-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 115 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(QUARTER, '1900-01-01', '2015-11-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 464 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(MONTH, '1900-10-31', '2015-11-01') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1381 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(DAYOFYEAR, '1900-01-01', '2015-11-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42329 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(DAY, '1900-01-01', '2015-11-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42329 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(WEEK, '1900-01-01', '2015-11-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 6047 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(WEEK, '1900-01-01', '2015-11-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 6047 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(WEEKDAY, '1900-01-01', '2015-11-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 42329 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(HOUR, '1900-01-01', '2015-11-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1015896 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(MINUTE, '1900-01-01', '2015-11-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 60953760 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(SECOND, '1900-01-01', '1910-11-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 343699200 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: DATEDIFF(MILLISECOND, '1900-01-01', '1900-01-23') 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1900800000 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">==================================================
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 最基本表达式计算01--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: "AABBCC" LIKE "%BB%" AND 300&gt;100 AND -0.000021323E+12 OR 34.543 AND True OR false AND 5697.000021323E+12 OR -45678.424123 AND [FName] IN ("ZhangSan","LiSi")   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: False 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 59755.4178 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 287.0164 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 167.35 /s, 性能低于 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 348412.15 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 23 IN (12,23,34)   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: True 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5565.3184 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 11.0006 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1796.84 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 9090413.25 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 2 + Max(12,23,34)   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 36 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6545.3744 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 6.0003 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1527.8 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 16665833.37 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: Max("AAA","BBB","CCC")   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: CCC 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5686.3252 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 9.0006 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1758.61 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 11110370.42 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: Min("AAA","BBB","CCC")   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: AAA 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5912.3381 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 7.0004 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1691.38 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 14284898.01 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: Max("1989-11-27","1990-07-19")   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1990-07-19 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6511.3724 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 7.0004 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1535.77 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 14284898.01 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: Min("1989-11-27","1990-07-19")   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1989-11-27 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6072.3474 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 14.0008 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1646.81 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 7142449 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: "AABBCC" LIKE "%BB%"   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: True 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4913.281 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 11.0006 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2035.3 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 9090413.25 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: "ZhangSan" IN ("ZhangSan","LiSi")   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: True 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6746.3859 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 6.0003 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1482.28 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 16665833.37 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: LEN("ZhangSan")   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 8 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 3945.2256 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 6.0004 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2534.71 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 16665555.63 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: LEN("ZhangSan"+"LiSi")   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 12 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5977.3419 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 6.0003 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1672.98 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 16665833.37 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: NEWID()   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: f8398ed9-a795-4f32-9078-8ecb766ae063 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 1887.108 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 66.0037 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 5299.11 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1515066.58 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: NEWID() LIKE '%ABC%'   
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: False 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5690.3255 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 1916.1096 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1757.37 /s, 性能满足 预期 1000 /s
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 52189.08 /s, 性能低于 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: (1234+987)*765   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1699065 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7040.4027 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 10.0006 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1420.37 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 9999400.04 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: (122+5654)*(2+976)   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 5648928 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 9630.5508 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 10.0006 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1038.36 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 9999400.04 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: (2+8)*(1+2+77+(12+8))   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1000 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 16169.9249 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 12.0007 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 618.43 /s, 性能低于 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 8332847.25 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: (11111===2222)?111:222   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 222 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 9756.558 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 7.0004 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1024.95 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 14284898.01 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: -0.21323E+2   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: -21.323 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 2015.1153 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 9.0005 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 4962.5 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 11110493.86 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: -0.000021323E+12   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: -21323000 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 2659.1521 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 11.0007 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 3760.6 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 9090330.62 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 100-50+50-50   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 50 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7707.4409 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 7.0004 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1297.45 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 14284898.01 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 11111===11111   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: True 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4003.229 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 10.0005 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2497.98 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 9999500.02 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 1234*546   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 673764 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 2952.1689 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 6.0003 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 3387.34 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 16665833.37 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 123+65+234+132+432   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 986 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 9531.5452 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 11.0006 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1049.15 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 9090413.25 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 1+1+1+1+1   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 5 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7941.4542 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 7.0004 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1259.22 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 14284898.01 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: -2+5*(-2+7)   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 23 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 7476.4276 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 6.0003 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1337.54 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 16665833.37 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 123*654*907   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 72960894 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4628.2647 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 15.0009 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2160.64 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 6666266.69 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 2+(235*(2+3))   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 1177 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 8108.4638 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 6.0003 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1233.28 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 16665833.37 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 3^4   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 81 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 2661.1522 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 8.0005 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 3757.77 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 12499218.8 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 345*657   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 226665 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 2945.1684 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 8.0005 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 3395.39 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 12499218.8 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 4*3/6*9/2   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 9 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 8037.4597 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 6.0004 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1244.17 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 16665555.63 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 7868*989+5678   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 7787130 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5262.3009 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 6.0004 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1900.31 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 16665555.63 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 81^(1/4)   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 3 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 5905.3377 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 10.0006 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1693.38 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 9999400.04 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 10-1+2-3+4-5+6   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 13 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 11592.6631 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 7.0004 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 862.61 /s, 性能低于 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 14284898.01 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: "QWERTYUIOP{}:" LIKE "%ERT%U%"   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: True 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 6187.3539 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 7.0004 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 1616.2 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 14284898.01 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: ("QWERTYUIOP{}:" LIKE "%ERT%U")?1111+1111:2222+2222   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 4444 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 15812.9045 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 9.0005 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 632.39 /s, 性能低于 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 11110493.86 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: (REPLACE(REPLACE("AAAAAAAAKKK","K","M"),"A","B") == "BBBBBBBBMMM")?"HHHHHHHHH":"IIIIIIIIII"   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: HHHHHHHHH 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 20707.1844 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 7.0004 毫秒
</font><br/><font color=#FFFF00 size=10px face="宋体">平均 482.92 /s, 性能低于 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 14284898.01 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">表达式: False?111:222   [预]
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 222 
</font><br/><font color=#FFFFFF size=10px face="宋体">分析 10000 次, 耗时 4354.249 毫秒
</font><br/><font color=#FFFFFF size=10px face="宋体">执行 100000 次, 耗时 7.0004 毫秒
</font><br/><font color=#00FF00 size=10px face="宋体">平均 2296.61 /s, 性能满足 预期 1000 /s
</font><br/><font color=#00FF00 size=10px face="宋体">平均 14284898.01 /s, 性能满足 预期 100000 /s
</font><br/><font color=#FFFFFF size=10px face="宋体"> 
</font><br/><font color=#FFFFFF size=10px face="宋体">--------------------------------------------------
</font><br/><font color=#FF1493 size=10px face="宋体">-- 测试 最基本表达式计算02--
</font><br/><font color=#FF1493 size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: LEN("ZhangSan"+"LiSi") 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 12 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 81^(1/4) 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 3 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: True ? 11+22 : 100/0 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 33 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">表达式: 100/0 
</font><br/><font color=#FFFFFF size=10px face="宋体">最后结果: 正无穷大 
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/><font color=#FFFFFF size=10px face="宋体">按任意键 退出测试...
</font><br/><font color=#FFFFFF size=10px face="宋体"></font><br/></div>