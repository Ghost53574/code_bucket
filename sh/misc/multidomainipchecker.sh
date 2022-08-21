#!/bin/bash 
#
# Need bash, dig, whois, echo, grep, sed, cut
# I donno linux but in FreeBSD works fine.
# Put your text of domains in domains.txt w/delimiter char13/ is [ENTER](doh)
# script will give stdout per domain checked, no IP/whois/dig result will be skipped fast
# seek for the details.csv for the result/dumped, looked like below:
# hwgozzqhjagrweqm.pro,,
# zjgiempwmciorhrf.pro,,
# wjpcjomepafcdwfj.pro,,
# 0day.jp,218.110.83.105,[NameServer]                   ns1.dnspark.net
# [NameServer]                   ns2.dnspark.net
# [NameServer]                   ns3.dnspark.net
# ondailybasis.com,108.162.193.173
# 108.162.193.73,ART.NS.CLOUDFLARE.COM
# DANA.NS.CLOUDFLARE.COM
#
# Original usage: 
# dig $line +short >> ip address 
# whois $line >> Lists full details including the name servers 
# whois $line | grep "Name Server" | cut -d ":" -f 2 | sed 's/ //' | sed -e :a -e '$!N;s/ \n/,/;ta'`  
while read domain 
do 
 echo $domain 
  ipaddress=`dig $domain +short` 
  nameserver=`whois $domain | grep "Name Server" | cut -d ":" -f 2 |  sed 's/ //' | sed -e :a -e '$!N;s/ \n/,/;ta'` 
  echo -e "$domain,$ipaddress,$nameserver" >> details.csv
done < domains.txt 