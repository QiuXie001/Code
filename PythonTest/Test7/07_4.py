import os
import shutil

def move_files(folder_path):
    if not os.path.exists(folder_path):
        print("Folder does not exist.")
        return
    batches = {}
    for file in os.listdir(folder_path):
        if file.endswith(".txt"):
            batch, number = file.split("_")
            if batch not in batches:
                batches[batch] = []
            batches[batch].append(os.path.join(folder_path, file))

    for batch, files in batches.items():
        batch_folder = os.path.join("batch_files", batch)
        if not os.path.exists(batch_folder):
            os.makedirs(batch_folder)
        for file in files:
            shutil.copy(file, os.path.join(batch_folder, os.path.basename(file)))
if __name__ == "__main__":
    folder_path = "test_files"
    move_files(folder_path)
