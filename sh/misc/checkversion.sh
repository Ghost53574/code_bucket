#!/bin/sh
wget -O - https://www.hiawatha-webserver.org/latest > /dev/null && cat /dev/stdout
wget -O - http://www.banshee-php.org/latest > /dev/null | echo $@
