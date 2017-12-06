# -*- coding: utf-8 -*-
import sys
sys.path.append(r"c:\python27\lib")
sys.path.append(r"E:\Program Files (x86)\IronPython 2.7\Lib")
print(sys.path)

import shutil,os
#desktopPath = r"C:\Users\403\Desktop"
desktopPath = r"E:\Program Files (x86)\IronPython 2.7"
targetPath = r"D:\一些有趣的东西\有趣的图片集\炼金术师工厂"
fileName = os.listdir(desktopPath)
print(fileName)
for num in range(0,len(fileName)):
    if(fileName[num].__contains__(".gif") and fileName[num].__contains__("Opus Magnum")):
        soc = desktopPath+"\\"+fileName[num]
        tar = targetPath+"\\"+fileName[num]
        shutil.move(soc, tar)

