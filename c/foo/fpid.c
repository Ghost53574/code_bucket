#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <fcntl.h>
#include <errno.h>
#include <sys/stat.h>


void fatal(char* err,char* prog);
char* fname(FILE* fd, int pid);

int main(int argc, char **argv)
{
	const int LEN = 128;
	if (argc != 2)
		fatal("Usage is %s [pid]\n", argv[0]);
    char buf[LEN], pbuf[LEN], cbuf[LEN];
    if (atoi(argv[1]) > 128 && atoi(argv[1]) < 0)
        fatal("PID was in invalid format %s\n", argv[1]);
    strncpy(buf, "/proc/", sizeof(buf));
    strncat(buf, argv[1], sizeof(buf));
    char* file = &buf[0];
    struct stat _sts;
	if (stat(file, &_sts) == -1 || errno == ENONET)
        fatal("The process for PID:%s does not exist!\n", argv[1]);
	strncpy(cbuf, "ps -p ", sizeof(cbuf));
	strncat(cbuf, argv[1], sizeof(cbuf));
	strncat(cbuf, " -o comm=", sizeof(cbuf));
	FILE* cmd = popen(cbuf,"r");
	if (cmd == NULL)
		fatal("popen failed to create FILE stream: %s",cbuf);
    printf("FILE BUFFER:%s\n",cbuf);
	if (fgets(pbuf,LEN,cmd) == NULL)
		fatal("fgets failed!",argv[1]);
	pid_t _pid = strtol(pbuf,NULL,10);
	pclose(cmd);
	printf("Selected PID is: %d\n",_pid);
	printf("Location is: %s\n",fname(cmd,atoi(argv[1])));
	printf("Device ID: %lu\n" \
	       "Inode Num: %lu\n" \
           "UID: %lu\n" \
           "GID: %lu\n" \
           "Last access: %lu\n" \
           "Last perm change: %lu\n" \
           "Number of links: %lu\n", 
           _sts.st_dev,
           _sts.st_ino,
           _sts.st_uid,
           _sts.st_gid,
           _sts.st_atime,
           _sts.st_ctime,
           _sts.st_nlink);
    return 0;
}

void fatal(char* err, char* prog) {
	printf(err,prog);
	exit(1);
}

char* fname(FILE* fd, int pid) {
    static char name[256];
    int _fd = fileno(fd);
    if (_fd == -1)
        fatal("File Stream is not valid! %d\n","-1");
    sprintf(name, "/proc/%d/fd/%d", pid, _fd);
    return name;
}
