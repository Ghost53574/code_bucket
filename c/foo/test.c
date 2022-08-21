#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include </usr/include/libnet.h>

#define SIZE 256

void _fatal(char* err);

int main (void) {
    char buffer[SIZE];

    char* err;
    char* dev = "wlan0";
    libnet_t* _libnet_test;
    _libnet_test = libnet_init(0, dev, err);
    if (_libnet_test == NULL)
        _fatal("_libnet_test returned NULL");
    struct libnet_stats* _libnet_stats;
    libnet_stats(_libnet_test,_libnet_stats);
	return 0;
}

void _fatal(char* err) {
    printf("FATAL!: %s\n",err);
    exit(1);
}
