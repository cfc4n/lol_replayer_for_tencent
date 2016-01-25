#!/usr/bin/env bash
cd `dirname $0`/.. || exit 1;
projectpath=`pwd`
export GOPATH="${projectpath}:$GOPATH"
export GOBIN="${projectpath}/bin"
export PATH=$PATH:$projectpath

gobin=`which go`
exec ${gobin} install  -ldflags "-s -w" ./...
#exec ${gobin} install -v -gcflags "-N -l"  ./...
# ps -ef|grep "League"
# kill -9
