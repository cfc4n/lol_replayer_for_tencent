# coding=UTF-8
import urllib2
from bs4 import BeautifulSoup
import sys
import json

class Player:
    def __init__(self):
        ''' 
        Initialize the class,
        and there are seven variables to keep each player's info
        '''
        self.role = None
        self.name = None
        self.incoming = 0
        self.KDA = None
        #http://img.lolbox.duowan.com/zb/2031_24x24.jpg
        self.equipments = []
        self.farm = 0
        self.img_src = None

class Table:
    def __init__(self):
        '''
        Initialize the class. A table stores the info of one of teams in the game.
        And, each team has five players so the function creates a list recording five players' info in the beginning.
        '''
        self.player_list = []
        for i in range(0,5):
            self.player_list.append(Player())
    def getTableInfo(self, soup, tableID):
        '''
        Acquire information from API and parse html file by beautifilsoup
        '''
        content = soup.find("div", {"id":tableID}).find("table")
        c = content.find_all("tr")
        count = 0
        for each in c:
            col1 = each.find("td", {"class":"col1"})
            self.player_list[count].img_src = col1.find("span", {"class":"avatar"}).img.get('src').encode('utf-8')
            #print self.player_list[count].img_src
            self.player_list[count].role = self.player_list[count].img_src.split('/')[-1].split('_')[0].encode('utf-8')
            #print self.player_list[count].role
            self.player_list[count].name = col1.a.text.encode('utf-8')
            #print self.player_list[count].name
            self.player_list[count].incoming = float(each.find("td", {"class":"col2"}).text.encode('utf-8').split("k")[0])
            #print self.player_list[count].incoming
            self.player_list[count].KDA = each.find("td", {"class":"col3"}).text.encode('utf-8')
            #print self.player_list[count].KDA
            weapons = each.find('div', {'class':'u-weapon'})
            equipments = weapons.find('ul', {'class':'chuzhuang'}).find_all('img')
            for eq in equipments:
                self.player_list[count].equipments.append(eq.get('src').encode('utf-8').split('/')[-1].split('_')[0])
            #print self.player_list[count].equipments
            self.player_list[count].farm = int(weapons.find('span', {'class':'minions-killed'}).text.encode('utf-8').split('：')[-1])
            #print self.player_list[count].farm
            count += 1

class GameInfo:
    def __init__(self):
        '''
        Game information shows the basic info about the game and is also parsed from html file
        '''
        self.type = None
        self.gameLength = 0
        self.finishingTime = None
        self.kill = []
        self.money = []
        self.dic = {}
    def getGameInfo(self, soup):
        '''
        Acquire game information by beautifilsoup
        '''
        content = soup.find("div", attrs={'class':'r-top'}).find_all("span")
        dic = {}
        for child in content:
            raw_data = child.get_text().encode('utf-8')
            list = raw_data.split("：")
            dic[list[0]] = list[1]
        # debug message
        ''' 
        for name in dic.keys():
            print name, dic[name]
        '''
        self.gameLength = dic['时长']
        self.dic['gameLength'] = self.gameLength
        self.type = dic['类型']
        self.dic['type'] = self.type
        self.finishingTime = dic['结束']
        self.dic['finishingTime'] = self.finishingTime
        self.kill = dic['人头']
        self.dic['kill'] = self.kill
        self.money = dic['金钱']
        self.dic['money'] = self.money
    def __str__(self):
        # debug msg
        '''
        print "type: " + self.type
        print "gameLength: " + self.gameLength
        print "Finishing time: " + self.finishingTime
        print "Kill: " + self.kill
        print "Money: " + self.money
        '''
        return str(self.dic)
def obj2dict(obj):
    #convert object to a dict
    d =  {}
    d[ '__class__' ] =  obj.__class__.__name__
    d[ '__module__' ] =  obj.__module__
    d.update(obj.__dict__)
    return  d
    
if __name__ == '__main__':
    # print "Welcome to HappyParser"
    if len(sys.argv) is not 3:
        print "usage : HappyParser.py matchId playerName"
        #return
    matchId = sys.argv[1]
    serverName = '電信一'
    playerName = sys.argv[2]
    
    input_url = "http://lolbox.duowan.com/matchList/ajaxMatchDetail2.php?" + "matchId=" + matchId + "&serverName=" + serverName + "&playerName=" + playerName + "&favorate=0"
    #print input_url
    
    #r = urllib2.urlopen("http://lolbox.duowan.com/matchList/ajaxMatchDetail2.php?matchId=17069455328&serverName=%E7%94%B5%E4%BF%A1%E4%B8%80&playerName=%E6%88%91%E5%BE%88%E5%8E%89%E5%AE%B3%E4%BC%9A%E5%8F%91%E5%85%89%E5%93%9F&favorate=0")
    r = urllib2.urlopen(input_url)
    
    soup = BeautifulSoup(r.read(), "html.parser")
    
    r.close()
    
    info = GameInfo()
    info.getGameInfo(soup)
    
    tableA = Table()
    tableA.getTableInfo(soup, "zj-table--A")
    tableB = Table()
    tableB.getTableInfo(soup, "zj-table--B")
    
    gameInfo_str = json.dumps(info, default = obj2dict, ensure_ascii=False, indent=4)
    tableA_str = json.dumps(tableA, default = obj2dict, ensure_ascii=False, indent=4)
    tableB_str = json.dumps(tableB, default = obj2dict, ensure_ascii=False, indent=4)
    
    # write game information to the info.out
    #file = codecs.open("info.out", 'w', 'utf-8')
    file = open("info.out", 'w')
    file.write(gameInfo_str)
    file.close()
    # write the information of table A to the tableA.out
    file = open("tableA.out", 'w')
    file.write(tableA_str)
    file.close()
    # write the information of table B to the tableB.out
    file = open("tableB.out", 'w')
    file.write(tableB_str)
    file.close()