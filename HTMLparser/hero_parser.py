# encoding=utf-8
import urllib2
from bs4 import BeautifulSoup
import sys
import json

#r = urllib2.urlopen("http://ddragon.leagueoflegends.com/tool/")
#print r.read()
file = open('tool.htm', 'r')
#print file.read()
soup = BeautifulSoup(file.read(), "html.parser")


c = soup.find_all('div', {"class":'name'})
#print c
for each in c:
    #ChampionTable.Add(266 ,"Aatrox")
    line = each.get_text().encode('utf-8')
    list = line.split("—")
    name = list[0]
    id = list[1].split("/")[0]
    #print name, id
    
    print "ChampionTable.Add(" + id + ",\"" +  name +"\");"