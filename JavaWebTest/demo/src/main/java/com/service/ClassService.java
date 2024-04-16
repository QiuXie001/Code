package com.service;

import com.model.Class;
import java.util.ArrayList;
import java.util.List;

public class ClassService {
    // 创建一个List来存储班级信息
    public static List<Class> list = new ArrayList<Class>();
	// 静态初始化块，用于初始化List
	static {
		// 循环创建从1到8的班级信息
		for (int i = 1; i <= 8; i++) {
			Class tmp = new Class();
			// 设置班级ID
			tmp.setClassId(i);
			// 设置班级名称
			tmp.setClassName(i + "班");
			// 将班级信息添加到List中
			list.add(tmp);
		}
	}

    // 获取所有班级信息
    public static List<Class> getAllClass() {
		// TODO Auto-generated method stub

		// 返回班级信息List
		return list;
	}
	// 根据班级ID获取班级名称
    public static String getClassNameByClassId(int id) {
		// TODO Auto-generated method stub
		// 遍历班级信息List
		for (int i = 0; i < list.size(); i++) {
			// 如果班级ID与传入的ID相等
			if (list.get(i).getClassId() == id) {
				// 返回该班级的名称
				return list.get(i).getClassName();
			}
		}
		// 如果没有找到对应的班级ID，则返回空字符串
		return "";
	}
	// 根据班级ID获取班级信息
    public static Class getOneClassById(int id) {
		// TODO Auto-generated method stub
		// 遍历班级信息List
		for (int i = 0; i < list.size(); i++) {
			// 如果班级ID与传入的ID相等
			if (list.get(i).getClassId() == id) {
				// 返回该班级的信息
				return list.get(i);
			}
		}
		// 如果没有找到对应的班级ID，则返回null
		return null;
	}
	

}