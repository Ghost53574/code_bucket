#!/bin/sh
( /usr/local/bin/rkhunter --versioncheck /usr/local/bin/rkhunter --update /usr/local/bin/rkhunter --cronjob ) | /usr/bin/mail -s "rkhunter output" $1

