#!/usr/bin/env bash

succeededBuilds=()
failedBuilds=()

for b in $(find ./*/. | grep $1)
do
    cd $(dirname $b)
    eval $1
    if [ $? -eq 0 ]
    then
        succeededBuilds+=($b)
    else
        failedBuilds+=($b)
    fi
    cd -
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
