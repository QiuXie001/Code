import os
import random
import string

def random_string(length):
    return ''.join(random.choice(string.ascii_letters + string.digits) for _ in range(length))

def create_files(folder_path, num_files, file_length):
    if not os.path.exists(folder_path):
        os.makedirs(folder_path)

    files = set()
    while len(files) < num_files:
        file_name = str(len(files)) + '.txt'
        file_path = os.path.join(folder_path, file_name)
        file_content = random_string(file_length)
        files.add(file_content)

        with open(file_path, 'w') as f:
            f.write(file_content)

if __name__ == '__main__':
    folder_path = 'test_files'
    num_files = 5
    file_length = 100
    create_files(folder_path, num_files, file_length)
