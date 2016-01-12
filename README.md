# lol_replayer_for_tencent
League Of Legends 英雄联盟，腾讯游戏助手TGP录像的解析代码，可搭建录像服务器，启动游戏进行观看录像。


go get github.com/collinglass/mw
go get github.com/gorilla/mux
go get github.com/pborman/getopt

cd 项目目录
shell/build.sh



使用：
在 http://api.pallas.tgp.qq.com/core/get_ob_list 中，有很多ob.pallas.tgp.qq.com/ob_data/1_1789151000.ob 字样的录像文件，下载下来
bin/launcher -f  1_1789151000.ob
windows平台需要在编译时，填写LOL游戏所在目录
