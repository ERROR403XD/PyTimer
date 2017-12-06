# -*- coding: utf-8 -*-
import sys
sys.path.append(r"E:\Program Files (x86)\IronPython 2.7\Lib")
import os
fileName = os.listdir('./')
print(fileName)
for file in fileName:
    if((str)(file).__contains__(".txt")):
        os.remove(file)