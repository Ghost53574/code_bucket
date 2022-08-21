#!/bin/sh
rpm2pcio $1 | cpio -idmv
