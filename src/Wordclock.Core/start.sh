#!/bin/bash

if [ -d "update" ]; then
	rm *.pdb
	rm *.dll
	rm *.config
	rm *.py

	cp update/* .
fi

/usr/bin/mono "Wordclock.exe" &
