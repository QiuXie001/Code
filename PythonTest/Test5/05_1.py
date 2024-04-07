a = """
    这是一段测试字符串
    这是第二段
"""
b = "这是一段测试字符串\n这是第二段"
c=a+b
d=chr(100)
e = c.split('\t',-1)
print(a)
print(b)
print(c)
print(d)
print(len(c))
print(c[25:])
print(e)
print("bAcd".upper())
import jieba
f = jieba.cut(a.replace('\n','').replace('\t','').replace(' ',''))
for g in f:
    print(g)