#!/bin/sh

PROG="$(which curl)"
ARGS="-k -#"
OUT="-o "

download ( ) {
    $($PROG $ARGS $OUT $1 $2)
}

main ( ) {
    if [ ! -x $PROG ];
    then
        echo "Does curl exist in /usr/bin/ ?"
        return 1
    fi
    download 'libmicrohttpd.tar.gz' 'https://ftp.gnu.org/gnu/libmicrohttpd/libmicrohttpd-latest.tar.gz'
    download 'timsort4net.zip' 'https://codeplexarchive.blob.core.windows.net/archive/projects/timsort4net/timsort4net.zip'
    download '' ''
}

main
