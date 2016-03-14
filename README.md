# lol_replayer_for_tencent 介绍

## Synopsis

League Of Legends 英雄联盟，腾讯游戏助手TGP录像的解析代码，可搭建录像服务器，启动游戏进行观看录像，支援MAC OS X上觀看國服。
除此之外，我們還提供了windows版本的GUI，透過多玩盒子API，獲取該場對戰的資訊。
(目前仍在建構中，敬請期待)

## Code Example

你可以透過我們的GUI，也可直接透過command使用我們的project

>在 http://api.pallas.tgp.qq.com/core/get_ob_list 中，有很多http://ob.pallas.tgp.qq.com/ob_data/1_1789151000.ob 字样的录像文件，下载下来
>透過這個指令，直接呼叫client端撥放replay

``cfc4n@cnxct:~/Project/github/lol_replayer_for_tencent/bin$./launcher -f  1_1789151000.ob``

>傳入玩家名稱，得到該玩家近十場遊戲的獨特ID

``~/lol_replayer_for_tencent/IDParser$ python IDParser.py player_ID```

>傳入每一場遊戲獨特的ID，可以藉由多玩盒子API獲得該場遊戲的資訊

``~/lol_replayer_for_tencent/HTMLparser$ python HTMLparser.py matchID``

## Motivation

Just for fun
## Pre-required


- Python 2.7
- go 
- beautifulsoup4 for python


## Installation

> 觀戰所需程式：
```
cfc4n@cnxct:~/Project/github/lol_replayer_for_tencent$go get github.com/collinglass/mw
cfc4n@cnxct:~/Project/github/lol_replayer_for_tencent$go get github.com/gorilla/mux
cfc4n@cnxct:~/Project/github/lol_replayer_for_tencent$go get github.com/pborman/getopt
```
cd 项目目录

``cfc4n@cnxct:~/Project/github/lol_replayer_for_tencent$sh shell/build.sh``

``备注 windows平台需要在编译时，填写LOL游戏所在目录``

> IDParser：
``~/lol_replayer_for_tencent/IDParser$ python setup.py py2exe``

> HTMLparser：
``~/lol_replayer_for_tencent/HTMLparser$ python setup.py py2exe``

## API Reference

- 在mac osx上看lol国服ob录像的技术分析： http://www.cnxct.com/how-to-watch-lol-tencent-ob-on-mac-osx/
- 多玩盒子：http://lol.duowan.com/zdl/

## TO-DO

預計還要完成抓下ob file時，順便獲取該場遊戲資訊，因為盒子API的ID與騰訊ID對不起來

## License


