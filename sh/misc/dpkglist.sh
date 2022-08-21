#!/bin/sh

# # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #
# Dump a list of package names; Re-install packages from list #
#                                                             #
# By: gh0st                     ver: 0.0.1                    #
# ----------------------------------------------------------- #
$apt = ""
echo "Welcome " $(whoami) " to dpkglist!"
echo "\nGrabbing your current package list...";
dpkg --get-selections | sed -ne '/\tinstall$/{s/[[:space:]].*//;p}' | sort > ~/dpkglist.selections
for i in $(cat < ~/dpkglist.selections);
do
	
