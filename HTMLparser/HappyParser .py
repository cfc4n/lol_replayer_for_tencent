# coding=UTF-8
import urllib2
from bs4 import BeautifulSoup
class gameInfo:
    def __init__(self):
        self.type = None
        self.gameLength = 0
        self.time = []
        self.kill = []
        self.money = []
    def getGameInfo(self, soup):
        content = soup.find("div", attrs={'class':'r-top'}).find_all("span")
        #print content
        #print type(content)
        dic = {}
        for child in content:
            #print type(child)
            raw_data = child.get_text().encode('utf-8')
            list = raw_data.split("：")
            print list
            print raw_data
    def __str__(self):
        print "type: " + self.type
        print "gameLength: " + self.gameLength
        print "Finishing time: " + self.time
        print "Kill: " + self.kill
        print "Money: " + self.money
if __name__ == '__main__':
    #print "Welcome to HappyParser"

    r = urllib2.urlopen("http://lolbox.duowan.com/matchList/ajaxMatchDetail2.php?matchId=17069455328&serverName=%E7%94%B5%E4%BF%A1%E4%B8%80&playerName=%E6%88%91%E5%BE%88%E5%8E%89%E5%AE%B3%E4%BC%9A%E5%8F%91%E5%85%89%E5%93%9F&favorate=0")
    #r.encoding = 'gb18030'
    #soup = BeautifulSoup(r.read().decode('utf-8', 'ignore'), from_encoding='utf-8')
    soup = BeautifulSoup(r.read(), "html.parser")
    #soup = BeautifulSoup(f.read().decode('utf-8').encode('utf-8'))
    r.close()
    
    info = gameInfo()
    info.getGameInfo(soup)
    

    