#!/bin/bash

mkdir $1
cd $1

mkdir part1
cd part1
  mkdir Console
  cd Console
    dotnet new console
  cd ..
  mkdir Test
  cd Test
    dotnet new nunit
  cd ..
  dotnet new sln
  dotnet sln add Test
  dotnet sln add Console
  touch testInput.txt
  touch realInput.txt
cd ..

mkdir part2
cd part2
  mkdir Console
  cd Console
    dotnet new console
  cd ..
  mkdir Test
  cd Test
    dotnet new nunit
  cd ..
  dotnet new sln
  dotnet sln add Test
  dotnet sln add Console
  touch testInput.txt
  touch realInput.txt
cd ..