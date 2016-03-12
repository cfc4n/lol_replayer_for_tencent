import urllib2

if __name__ == '__main__':
    for index in range(1001, 3933):
        print index
        input_rul = "http://ddragon.leagueoflegends.com/cdn/6.5.1/img/item/" + str(index) + ".png"
        req = urllib2.Request(input_rul)
        try:
            resp = urllib2.urlopen(req)
        except urllib2.HTTPError as e:
            if e.code == 404:
                # do something...
                print str(index) + ' 404 not found'
        else:
            # 200
            file = open( 'items/'+str(index)+'.png', 'wb')
            file.write(resp.read())