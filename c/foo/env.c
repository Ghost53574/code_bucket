#include <stdio.h>
#include <stdlib.h>

int main(int argc, char *argv[]) {
	printf("%x\n", getenv(argv[1]));
	return 0;
}
