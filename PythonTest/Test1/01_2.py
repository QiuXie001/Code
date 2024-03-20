NumList = [1, 0, 1, 0] 
CharList = ['x', 'i', 'e']
StringList = ["x", "i", "n"]
NumList[0] = 10
NumList[1] +=10
NumList[2] = NumList[0]+NumList[1]
a = 22
CharList[2] = CharList[0]+CharList[1]
print(id(NumList[2]))
print(id(CharList[2]))
print(id(StringList[2]))
print(id(a))
print(NumList)
print(CharList)
print(StringList)