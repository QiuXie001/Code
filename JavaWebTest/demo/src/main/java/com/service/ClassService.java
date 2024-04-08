package com.service;

import com.model.Class;
import java.util.ArrayList;
import java.util.List;

public class ClassService {
    public static List<Class> list = new ArrayList<Class>();
	static {
		for (int i = 1; i <= 8; i++) {
			Class tmp = new Class();
			tmp.setClassId(i);
			tmp.setClassName(i + "班");
			list.add(tmp);
		}
	}

    public static List<Class> getAllClass() {
		// TODO Auto-generated method stub

		return list;
	}
	public static String getClassNameByClassId(int id) {
		// TODO Auto-generated method stub
		for (int i = 0; i < list.size(); i++) {
			if (list.get(i).getClassId() == id) {
				return list.get(i).getClassName();
			}
		}
		return "";
	}
	public static Class getOneClassById(int id) {
		// TODO Auto-generated method stub
		for (int i = 0; i < list.size(); i++) {
			if (list.get(i).getClassId() == id) {
				return list.get(i);
			}
		}
		return null;
	}
	

}
