# coding=UTF-8
import urllib2
from bs4 import BeautifulSoup
import sys
import json

from langconv import *

def tradition2simple(line):  
    # 将繁体转换成简体  
    line = Converter('zh-hans').convert(line.decode('utf-8'))  
    line = line.encode('utf-8')  
    return line 
    
if __name__ == '__main__':
    
    file = open('ID.json', 'w')
    
    serverName = '电信一'
    playerName = tradition2simple(sys.argv[1].decode('big5').encode('utf-8'))
    #playerName = '我很厉害会发光哟'
    input_url = "http://lolbox.duowan.com/matchList.php?" + 'serverName=' + serverName + "&playerName=" + playerName

    r = urllib2.urlopen(input_url)
    #r = urllib2.urlopen('http://lolbox.duowan.com/matchList.php?serverName=电信一&playerName=我很厉害会发光哟')

    list = []
    # create soup obejct for input_url
    soup = BeautifulSoup(r.read(), 'html.parser')
    # find out all div with class = l-box
    content = soup.find('div', {'class':'l-box'}).find_all('li')
    # iterator in each sub tag
    for each in content:
        data = each.get('id').encode('utf-8')
        data = data.split('cli')[1]
        # record every target which satisfy our requests
        list.append(data)
    # output json file
    list_str = json.dumps(list)
    file.write(list_str)
    file.close()