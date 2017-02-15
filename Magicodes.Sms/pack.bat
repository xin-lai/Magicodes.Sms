echo 包搜索字符串
echo %1
echo 项目方案地址
echo %2

echo 打包
nuget Pack %2 -Build -Properties Configuration=Release
echo 推送包
nuget push %1 -s https://www.nuget.org 4e3f500e-a031-45fa-b746-5762275e7561