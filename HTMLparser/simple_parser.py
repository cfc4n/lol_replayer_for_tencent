from htmlentitydefs import entitydefs 
import HTMLParser 
class TitleParser(HTMLParser.HTMLParser): 
    def __init__(self): 
        self.taglevels=[] 
        self.handledtags=['title','body'] 
        self.processing=None 
        HTMLParser.HTMLParser.__init__(self) 
    def handle_starttag(self,tag,attrs): 
        if tag in self.handledtags: 
            print "the content of tag = " + tag
            self.data='' 
            self.processing=tag 
    def handle_data(self,data): 
        if self.processing: 
            self.data +=data 
    def handle_endtag(self,tag): 
        if tag==self.processing: 
            print str(tag)+':'+str(tp.gettitle()) 
            self.processing=None 
    def handle_entityref(self,name): 
        if entitydefs.has_key(name): 
            self.handle_data(entitydefs[name]) 
        else: 
            self.handle_data('&'+name+';') 
    def gettitle(self): 
        return self.data 
fd=open('test1.html') 
tp=TitleParser() 
tp.feed(fd.read()) 