import re

# 正则表达式匹配
pattern = r'\d+'
text = "There are 123 apples, 456 oranges, and 789 bananas."
match = re.search(pattern, text)
if match:
    print("匹配成功，匹配到的内容是：", match.group())
else:
    print("匹配失败")

# 正则表达式替换
pattern = r'\d+'
repl = 'XX'
text = "There are 123 apples, 456 oranges, and 789 bananas."
result = re.sub(pattern, repl, text)
print("替换后的内容是：", result)

# 正则表达式分割
pattern = r'\s+'
text = "This is a\ttest."
result = re.split(pattern, text)
print("分割后的内容是：", result)

# 正则表达式匹配分组
pattern = r'(\d+)\s+(oranges)'
text = "There are 123 apples, 456 oranges, and 789 bananas."
match = re.search(pattern, text)
if match:
    print("匹配成功，匹配到的内容是：", match.group())
    print("第一个分组是：", match.group(1))
    print("第二个分组是：", match.group(2))
else:
    print("匹配失败")

# 正则表达式匹配所有
pattern = r'\d+'
text = "There are 123 apples, 456 oranges, and 789 bananas."
matches = re.findall(pattern, text)
print("匹配到的所有数字是：", matches)
