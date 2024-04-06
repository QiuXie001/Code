# 循环
numbers = [1, 2, 3, 4, 5]

for number in numbers:
    if(number == 3):
        continue
    print("这是第", number, "个数字")

count = 0
while count < 5:
    print("这是第", count + 1, "次循环")
    count += 1
    if(count == 3):
        break

for i in range(1,10):
    print("\n")
    for j in range(1,i+1):
        print(i * j, end="\t")
