import os
import shutil
import pickle

# 文件读写
def file_read_write():
    file_path = 'test.txt'
    content = 'Hello, World!'

    # 写入文件
    with open(file_path, 'w') as f:
        f.write(content)

    # 读取文件
    with open(file_path, 'r') as f:
        read_content = f.read()
        print(read_content)

# 相对路径与绝对路径
def relative_path_absolute_path():
    current_path = os.path.abspath(__file__)
    print(f'当前文件的绝对路径: {current_path}')

    relative_path = 'test.txt'
    absolute_path = os.path.join(os.path.dirname(current_path), relative_path)
    print(f'相对路径转换为绝对路径: {absolute_path}')

# 二进制方法读写pickle模块
def binary_read_write_pickle():
    data = {'name': 'xiexin', 'age': 51010}

    # 写入pickle文件
    with open('data.dat', 'wb') as f:
        pickle.dump(data, f)

    # 从pickle文件中读取数据
    with open('data.dat', 'rb') as f:
        read_data = pickle.load(f)
        print(read_data)

# os模块
def os_module():
    current_dir = os.getcwd()
    print(f'当前目录: {current_dir}')

    file_list = os.listdir(current_dir)
    print(f'当前目录下的文件列表: {file_list}')

    # 创建一个新文件
    new_file = 'new_file.txt'
    with open(new_file, 'w') as f:
        f.write('This is a new file.')

    # 删除一个文件
    # os.remove(new_file)

# shutil模块
def shutil_module():
    source_file = 'test.txt'
    destination_file = 'test_copy.txt'

    # 复制文件
    shutil.copy(source_file, destination_file)

    # 移动文件
    shutil.move(destination_file, 'test_move.txt')

    # 删除文件
    os.remove('test_move.txt')

if __name__ == '__main__':
    file_read_write()
    relative_path_absolute_path()
    binary_read_write_pickle()
    os_module()
    shutil_module()