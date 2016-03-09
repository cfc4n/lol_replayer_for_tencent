# coding=UTF-8
import urllib2
from bs4 import BeautifulSoup
class gameInfo:
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
    
    #soup = BeautifulSoup(r.read().decode('utf-8', 'ignore'), from_encoding='utf-8')
    #soup = BeautifulSoup(f.read().decode('utf-8').encode('utf-8'))
    soup = BeautifulSoup(r.read(), "html.parser")
    
    r.close()
    
    info = gameInfo()
    info.getGameInfo(soup)
    print info

    