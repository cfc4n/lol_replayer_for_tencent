# coding=UTF-8
import urllib2
from bs4 import BeautifulSoup
class Player:
    def __init__(self):
        self.role = None
        self.name = None
        self.incoming = 0
        self.KDA = None
        self.equipments = []
        self.farm = 0
        self.img_src = None

class Table:
    def __init__(self):
        self.player_list = []
        for i in range(0,5):
            self.player_list.append(Player())
    def getTableInfo(self, soup, tableID):
        content = soup.find("div", {"id":tableID}).find("table")
        c = content.find_all("tr")
        count = 0
        for each in c:
            col1 = each.find("td", {"class":"col1"})
            self.player_list[count].img_src = col1.find("span", {"class":"avatar"}).img.get('src')
            print self.player_list[count].img_src
            self.player_list[count].role = self.player_list[count].img_src.split('/')[-1].split('_')[0]
            print self.player_list[count].role
            self.player_list[count].name = col1.a.text.encode('utf-8')
            print self.player_list[count].name
            self.player_list[count].incoming = float(each.find("td", {"class":"col2"}).text.encode('utf-8').split("k")[0])
            print self.player_list[count].incoming
            self.player_list[count].KDA = each.find("td", {"class":"col3"}).text.encode('utf-8')
            print self.player_list[count].KDA
            weapons = each.find('div', {'class':'u-weapon'})
            equipments = weapons.find('ul', {'class':'chuzhuang'}).find_all('img')
            for eq in equipments:
                self.player_list[count].equipments.append(eq.get('src').encode('utf-8'))
            print self.player_list[count].equipments
            self.player_list[count].farm = int(weapons.find('span', {'class':'minions-killed'}).text.split('：')[-1].encode('utf-8'))
            print self.player_list[count].farm
            

class TabeInfo:
    def __init__(self):
        self.tableA = Table()
        self.tableB = Table()

class GameInfo:
    def __init__(self):
        self.type = None
        self.gameLength = 0
        self.finishingTime = None
        self.kill = []
        self.money = []
        self.dic = {}
    def getGameInfo(self, soup):
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

if __name__ == '__main__':
    # print "Welcome to HappyParser"

    r = urllib2.urlopen("http://lolbox.duowan.com/matchList/ajaxMatchDetail2.php?matchId=17069455328&serverName=%E7%94%B5%E4%BF%A1%E4%B8%80&playerName=%E6%88%91%E5%BE%88%E5%8E%89%E5%AE%B3%E4%BC%9A%E5%8F%91%E5%85%89%E5%93%9F&favorate=0")
    request = urllib2.urlopen("http://lolbox.duowan.com/matchList/ajaxMatchDetail2.php?matchId=17034797158&serverName=%E7%94%B5%E4%BF%A1%E4%B8%80&playerName=%E6%88%98%E4%B8%B6%E6%97%97TV%E7%BF%94%E7%BF%94&favorate=0")
    #soup = BeautifulSoup(r.read().decode('utf-8', 'ignore'), from_encoding='utf-8')
    #soup = BeautifulSoup(f.read().decode('utf-8').encode('utf-8'))
    #soup = BeautifulSoup(r.read(), "html.parser")
    soup = BeautifulSoup(request.read(), "html.parser")
    
    r.close()
    
    info = GameInfo()
    info.getGameInfo(soup)
    
    table = Table()
    table.getTableInfo(soup, "zj-table--A")
        
