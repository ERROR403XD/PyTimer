# -*- coding: utf-8 -*-
import sys
#sys.path.append(r"c:\python27\lib")
#sys.path.append(r"C:\Users\User\AppData\Local\Programs\Python\Python36\Lib")
#sys.path.append(r"C:\Users\User\AppData\Local\Programs\Python\Python36\libs")
#sys.path.append(r"C:\\Users\\User\\AppData\\Local\\Programs\\Python\\Python36\\lib\\site-packages")
sys.path.append(r"E:\Program Files (x86)\IronPython 2.7\Lib")
import random
print("\\Create\\"+(str)(random.uniform(1, 100))+".txt")
file = open("五"+(str)(random.uniform(1, 100))+".txt", 'w')
file.close()
