# coding=UTF-8
import urllib2
import sys
from HTMLParser import HTMLParser
from htmlentitydefs import name2codepoint
from htmlentitydefs import entitydefs 

class HappyParser(HTMLParser):
    def __init__(self, gameInfoDic):
        self.taglevels=[]
        self.handletags=[]
        self.processing=None
        self.gameInfoDic = gameInfoDic
        self.currentFlag=0
        self.controllFlag = {'game_info':1}
        HTMLParser.__init__(self)
    def handle_starttag(self, tag, attrs):
        if tag == 'div':
            for name, val in attrs:
                if name == 'class' and val == 'r-top':
                    self.currentFlag = self.controllFlag['game_info']
                    #print self.currentFlag
        if tag == 'span' and self.currentFlag == self.controllFlag['game_info']:
            self.processing = tag
            self.data = ''
    def handle_data(self, data):
        if self.processing:
            self.data += data
    def handle_endtag(self, tag):
        if tag==self.processing and self.currentFlag == self.controllFlag['game_info']:
            self.processing = None
            self.data.decode('utf-8')
            list = self.data.split("：")
            print self.data
            self.gameInfoDic.update({list[0]:list[1]})
        if tag == 'div':
            self.currentFlag = 0
    def handle_entityref(self,name): 
        if entitydefs.has_key(name): 
            self.handle_data(entitydefs[name]) 
        else: 
            self.handle_data('&'+name+';') 

    def handle_charref(self, name):
        if name.startswith('x'):
            c = unichr(int(name[1:], 16))
        else:
            c = unichr(int(name))
        print "Num ent  :", c
        
if __name__ == '__main__':
    sysCharType = sys.getfilesystemencoding()
    print "Welcome to HappyParser sysCharType :", sysCharType
    dic = {}
    parser = HappyParser(dic)
    r = urllib2.urlopen("http://lolbox.duowan.com/matchList/ajaxMatchDetail2.php?matchId=17069455328&serverName=%E7%94%B5%E4%BF%A1%E4%B8%80&playerName=%E6%88%91%E5%BE%88%E5%8E%89%E5%AE%B3%E4%BC%9A%E5%8F%91%E5%85%89%E5%93%9F&favorate=0")
    #print r.read()
    r.encoding = 'gb18030'
    raw_data = r.read()
    #print chardet.detect(raw_data)
    parser.feed(raw_data)
    #str(dic).decode(sysCharType).encode('utf-8')
    for name in dic:
        print name, dic[name]
    