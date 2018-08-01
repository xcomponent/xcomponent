#!/usr/bin/env bash

succeededBuilds=()
failedBuilds=()

for d in $(find . -maxdepth 1 -type d | grep 'xc*')
do
    #Do something, the directory is accessible with $d:
    cd $d
    if [ -f "build-osx.sh" ]
    then
        ./build-osx.sh
        if [ $? -eq 0 ]
        then
            succeededBuilds+=($d)
        else
            failedBuilds+=($d)
        fi
    else
        echo Build script not found!
    fi
    cd ..
done

echo -e "\n"
echo -e "========================================"
echo -e "|         GLOBAL BUILD REPORT          |"
echo -e "========================================"
echo -e "\n"

for succeededBuild in ${succeededBuilds[*]}
do
    echo -e "\e[32mProject $succeededBuild built successfully"
    echo -e "\e[39m"
done

echo -e "\n"

for failedBuild in ${failedBuilds[*]}
do
    echo -e "\e[31mProject $failedBuild failed to build"
    echo -e "\e[39m"
done

for failedBuild in ${failedBuilds[*]}
do
    exit 1
done
