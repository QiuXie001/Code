my_list = [1, 2, 3, 4, 5]
print("My list:", my_list)

print("First element:", my_list[0])
print("Last element:", my_list[-1])
print("2nd to 4th elements:", my_list[1:4])
print("Elements from 2nd to last:", my_list[1:])
print("Reversed list:", my_list[::-1])

my_list.append(6)
print("Appended list:", my_list)

my_list.extend([7, 8])
print("Extended list:", my_list)

my_list.insert(1, 9)
print("Inserted list:", my_list)

my_list.remove(7)
print("Removed 7:", my_list)

my_list.pop()
print("Popped element:", my_list)

my_list.clear()
print("Cleared list:", my_list)

my_tuple = (1, 2, 3, 4, 5)
print("My tuple:", my_tuple)

print("First element:", my_tuple[0])
print("Last element:", my_tuple[-1])
print("2nd to 4th elements:", my_tuple[1:4])
print("Elements from 2nd to last:", my_tuple[1:])
print("Reversed tuple:", my_tuple[::-1])

my_dict = {"name": "Alice", "age": 30, "city": "New York"}
print("My dictionary:", my_dict)

print("Value of 'name':", my_dict["name"])
print("Value of 'age':", my_dict["age"])

my_dict["job"] = "Engineer"
print("Updated dictionary:", my_dict)

my_set = {1, 2, 3, 4, 5}
print("My set:", my_set)

my_set.add(6)
print("Set with 6 added:", my_set)

my_set.update([7, 8])
print("Set with 7 and 8 added:", my_set)

my_set.remove(7)
print("Set with 7 removed:", my_set)

my_set.discard(8)
print("Set with 8 discarded:", my_set)

my_set.clear()
print("Cleared set:", my_set)
