OS = linux
ifeq ($(OS),windows)
OS = windows
else
OS = linux
endif

TOP := $(dir $(CURDIR)/$(word $(words $(MAKEFILE_LIST)),$(MAKEFILE_LIST)))

all:
	cd $(TOP)src/ && make -f Makefile.$(OS)

minimal:
	cd $(TOP)src/ && make -f Makefile.$(OS) lib

install:
	cd $(TOP)src/ && make -f Makefile.$(OS) install

clean:
	cd $(TOP)src/ && make -f Makefile.$(OS) clean
