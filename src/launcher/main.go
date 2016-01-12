/*
 * Auther: CFC4N (cfc4n@cnxct.com)
 * WebSite: http://www.cnxct.com
 * Date: 2015/11/07
 */
package main

import (
	"fmt"
	"log"
	"net/http"
	"os"
	"path/filepath"
	"strconv"
	"strings"
	"command"
	"github.com/collinglass/mw"
	"github.com/gorilla/mux"
	"github.com/pborman/getopt"
	"replay"
)

const (
	DEFAULT_CLIENT_PORT uint16 = 8393                  //默认客户端连接的端口
	DEFAULT_GAME_PORT   uint16 = 8394                  //默认游戏程序连接的端口
	DEFAULT_REPLAY_PORT uint16 = 9527                  //默认录像回放服务的端口
	BUILD_DATE          string = "2015-12-09"          //发布时间
	LAUNCHER_VERSION    string = "beta 0.1"            //发布版本
	DOWNLOAD_URL        string = "https://github.com/cfc4n/lol_replayer_for_tencent" //下载地址
)


func main() {

	/*
	 *	lolclient connect port
	 *  lolclient path
	 *  game connect port
	 *  tgp parameter
	 *
	 */

	/*
	 *	本工具参数
	 */
	var lolclient_port uint16
	var lolroot_path string
	var lolobfile string
	var lolgame_port uint16
	var help bool = false
	//	var version bool = false
	fmt.Println()
	fmt.Println("版    本: lol_launcher_mac " + LAUNCHER_VERSION + " build at " + BUILD_DATE + " By CFC4N (cfc4n@cnxct.com)")
	fmt.Println("声    明: 本软件仅供技术交流，游戏娱乐，请勿用于非法用途。\n")

	s := getopt.New()

	/*
	 *	接收本工具参数
	 */
	//	s.StringVarLong(&lolroot_path, "path", 'X', "The root path of League of Legends games", "/Applications/League of Legends.app/")
	//	s.Uint16VarLong(&lolclient_port, "client_port", 'Y',"The port LolClient connected.")
	s.StringVarLong(&lolobfile, "obfile", 'f', "ob录像文件所在路径，建议放在replays目录下。")

	if help {
		s.PrintUsage(os.Stderr)
		return
	}

	lolroot_path = getCurrentDirectory()

	lolCommands := command.NewLolCommand()
	//设置游戏安装目录，以及日志目录
	lolCommands.LolSetConfigPath("/Applications/League of Legends.app/", lolroot_path)

	//获取游戏中，大厅程序以及游戏进程程序所在目录等配置
	lolCommands.LolGetConfig()

	/*
	 *
	 * 参数判断
	 */
	if lolclient_port <= 0 || lolclient_port >= 65535 {
		lolclient_port = DEFAULT_CLIENT_PORT
	}

	if lolgame_port <= 0 || lolgame_port >= 65535 {
		lolgame_port = DEFAULT_GAME_PORT
	}

	/*
	 *
	 */



		//观看录像模式
		log.Println("录像观看模式已启动...")
		filePath := lolroot_path + "/" + lolobfile
		log.Println("加载录像文件:", filePath)
		//加载分析OB文件
		err := replay.Loadfile(filePath)
		if err != nil {
			panic(err)
		}
		listenHost := "127.0.0.1:" + strconv.Itoa(int(DEFAULT_REPLAY_PORT))
		//		fmt.Println(replay.GameInfo)
		//		os.Exit(0)
		params := "spectator " + listenHost + " " + replay.GameInfo.Encryption_key + " " + strconv.Itoa(int(replay.GameInfo.Game_id)) + " " + replay.GameMetaData.GameKey.PlatformId

		// log.SetOutput(f)
		log.Println("录像回放服务已监听:", listenHost)

		r := mux.NewRouter()
		mw.Decorate(
			r,
			LoggingMW,
		)

		r.HandleFunc("/observer-mode/rest/featured", replay.FeaturedHandler)
		r.HandleFunc("/observer-mode/rest/consumer/version", replay.VersionHandler)
		r.HandleFunc("/observer-mode/rest/consumer/getGameMetaData/{platformId}/{gameId}/{yolo}/token", replay.GetGameMetaDataHandler)
		r.HandleFunc("/observer-mode/rest/consumer/getLastChunkInfo/{platformId}/{gameId}/{param}/token", replay.GetLastChunkInfoHandler)
		r.HandleFunc("/observer-mode/rest/consumer/getLastChunkInfo/{platformId}/{gameId}/null", replay.EndOfGameStatsHandler)
		r.HandleFunc("/observer-mode/rest/consumer/getGameDataChunk/{platformId}/{gameId}/{chunkId}/token", replay.GetGameDataChunkHandler)
		r.HandleFunc("/observer-mode/rest/consumer/getKeyFrame/{platformId}/{gameId}/{keyFrameId}/token", replay.GetKeyFrameHandler)

		http.Handle("/", r)
		//启动游戏
		//		log.Println("录像播放参数:",params)

		go lolCommands.LolGameCommand(strconv.Itoa(int(lolgame_port)), params)
		if err := http.ListenAndServe(listenHost, nil); err != nil {
			panic(err)
		}
		//监听系统关闭消息
		log.Println("软件退出。")
		os.Exit(0)

}

func checkError(err error) {
	if err != nil {
		log.Fatal(err)
	}
}

func substr(s string, pos, length int) string {
	runes := []rune(s)
	l := pos + length
	if l > len(runes) {
		l = len(runes)
	}
	return string(runes[pos:l])
}
func getParentDirectory(dirctory string) string {
	return substr(dirctory, 0, strings.LastIndex(dirctory, "/"))
}

func getCurrentDirectory() string {
	dir, err := filepath.Abs(filepath.Dir(os.Args[0]))
	if err != nil {
		log.Fatal(err)
	}
	return strings.Replace(dir, "\\", "/", -1)
}

func LoggingMW(h http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		log.Printf("Path: %s, Method: %s\n", r.URL.Path, r.Method)
		h.ServeHTTP(w, r)
	})
}
