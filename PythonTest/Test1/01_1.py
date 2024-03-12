def main():
    def add(a, b):
        return a + b

    def subtract(a, b):
        return a - b

    def multiply(a, b):
        return a * b

    def divide(a, b):
        if b == 0:
            raise ValueError("除数不能为0")
        return a / b

    def calculate():
        num1 = float(input("请输入第一个数(如:12021):\n"))
        num2 = float(input("请输入第二个数(如:051010):\n"))
        operation = input("请输入运算符(+、-、*、/):")

        if operation == "+":
            result = add(num1, num2)
        elif operation == "-":
            result = subtract(num1, num2)
        elif operation == "*":
            result = multiply(num1, num2)
        elif operation == "/":
            try:
                result = divide(num1, num2)
            except ValueError as e:
                print(e)
                return

        print("计算结果为：", result)

    # 调用函数
    calculate()
    

if __name__ == "__main__":
    main()
