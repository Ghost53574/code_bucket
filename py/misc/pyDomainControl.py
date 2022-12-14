#!/usr/bin/env python
# Settings
from datetime import date, datetime, timedelta
import urllib2
import sys, os

# Function definitions
def datespan(startDate, endDate, delta=timedelta(days=1)):
    currentDate = startDate
    while currentDate < endDate:
        yield currentDate
        currentDate += delta

# Banner
def Banner():
    print("=================================================")
    print("domaincontrol transfer v0.1                      ")
    print("=================================================")

# Usage
def help_menu(cmd):
    print("Usage: %s <start_Date> <endDate>\n") % (cmd)
    print("<startDate> - DD/MM/YYYY\n")
    print("<endDate> - DD/MM/YYYY\n")

# Main Program
def main(startDate,endDate):
    D1 = startDate.split('/')
    D2 = endDate.split('/')
    for day in datespan(date(int(D1[2]),int(D1[1]),int(D1[0])), date(int(D2[2]),int(D2[1]),int(D2[0])), delta=timedelta(days=1)):
        url = "http://www.dailychanges.com/export/domaincontrol.com/%s/export.csv" % (day)
        u = urllib2.urlopen(url)
        szFileName = str(day) + "-export.csv"
        localFile = open(szFileName, 'w')
        print("Saving %s\n" % szFileName)
        localFile.write(u.read())        
        localFile.close()
    
if __name__ == '__main__':
    Banner()
    if len(sys.argv)<3:
        help_menu(sys.argv[0])
    else:
        startDate = sys.argv[1]
        endDate = sys.argv[2]
        main(startDate,endDate)