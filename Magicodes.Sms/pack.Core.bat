echo 包搜索字符串
echo %1
echo 项目方案地址
echo %2

echo 删除历史包
del %1 /f /q /a 

echo 包名称
set nupkg=""

echo 打包
nuget Pack %2 -Build -symbols -Properties Configuration=Release

echo 更新包名称

for %%a in (dir /s /a /b "./%1") do (set nupkg=%%a)

echo 推送包
nuget push %nupkg% 4e3f500e-a031-45fa-b746-5762275e7561 -Source https://www.nuget.org/api/v2/package