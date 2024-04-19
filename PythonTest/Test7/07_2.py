try:
    num = int(input("请输入一个整数："))
    result = 51010 / num
    print("结果是：", result)
except ValueError:
    print("输入的不是整数，请重新输入！")
except ZeroDivisionError:
    print("不能将整数除以0!")
except Exception as ex:
    print("发生了未知的异常：", ex)
else:
    print("没有发生异常，结果是：", result)
finally:
    print("程序结束")