# 定义全局变量
global_var = "I am a global variable"

# 定义函数，查看函数定义
def view_definition():
    print("I am a function definition")

# 定义带有默认值参数的函数
def greet(name, greeting="Hello"):
    return f"{greeting}, {name}!"

# 定义带有命名参数的函数
def show_info(name, age, *args, **kwargs):
    print("Name:", name)
    print("Age:", age)
    print("Args:", args)
    print("Kwargs:", kwargs)

# 定义带有强制命名参数的函数
def calc(a, b, operation="+", *args):
    if operation == "+":
        return a + b
    elif operation == "-":
        return a - b
    elif operation == "*":
        return a * b
    else:
        return "Invalid operation"

# 定义lambda表达式
lambda_expression = lambda x: x ** 2

# 定义匿名函数
anonymous_function = lambda x: x * 2

# 定义递归函数
def recursive_function(n, limit=10):
    if n > limit:
        return "Error: n is greater than the limit"
    elif n == 0:
        return 0
    else:
        return n + recursive_function(n - 1)

# 定义嵌套函数
def outer_function():
    def inner_function():
        print("I am an inner function")

    inner_function()

# 主函数
def main():
    print("This is the main function")
    view_definition()
    print(greet("John"))
    show_info("John", 25)
    calc(3, 4)
    calc(3, 4, operation="-")
    show_info("John", 25, extra="Hello", another_extra="World")
    print(lambda_expression(5))
    print(anonymous_function(5))
    print(recursive_function(10))
    outer_function()

if __name__ == "__main__":
    main()
