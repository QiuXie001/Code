package com.service;

import com.model.*;
import com.model.Class;

import java.util.*;

import org.apache.commons.beanutils.BeanUtils;


public class StudentService {
    Student Stu = new Student();
    Class Class = new Class();
    public static List<Student> studentList = new ArrayList<Student>();
    static {
		try {
			Student tmp1 = new Student();
			Map<String, Object> curInfo1 = new HashMap<String, Object>();
			curInfo1.put("stuCode", "10001");
			curInfo1.put("stuName", "王小亮");
			curInfo1.put("age", 19);
			curInfo1.put("sex", 1); // 0表示男，1表示女
			curInfo1.put("belongClass", 8);
			curInfo1.put("belongClassName", "8班");
			curInfo1.put("telephone", "12345678901");
			curInfo1.put("address", "中国");

			Student tmp2 = new Student();
			Map<String, Object> curInfo2 = new HashMap<String, Object>();
			curInfo2.put("stuCode", "10002");
			curInfo2.put("stuName", "李小明");
			curInfo2.put("age", 20);
			curInfo2.put("sex", 0); // 0表示男，1表示女
			curInfo2.put("belongClass", 2);
			curInfo2.put("belongClassName", "2班");
			curInfo2.put("telephone", "12345670000");
			curInfo2.put("address", "中国second");

			BeanUtils.populate(tmp1, curInfo1);
			BeanUtils.populate(tmp2, curInfo2);

			studentList.add(tmp1);
			studentList.add(tmp2);
		} catch (Exception e) {
			e.printStackTrace();
		}
    }
    public static List<Student> getAllStudent() {
		// TODO Auto-generated method stub
		return studentList;
	}
    public static boolean insertStudentInfo(Student curStudent) {
		// TODO Auto-generated method stub
		studentList.add(curStudent);
		return true;
	}
	public static boolean updateStudentInfo(Student curStudent) {
		// TODO Auto-generated method stub
		for (int i = 0; i < studentList.size(); i++) {
			if (studentList.get(i).getStuCode().equals(curStudent.getStuCode())) {
				studentList.remove(studentList.get(i));
				studentList.add(curStudent);
			}
		}
		return true;
	}
	public static boolean deleteStudentInfo(String curStudentId) {
		// TODO Auto-generated method stub
		for (int i = 0; i < studentList.size(); i++) {
			if (studentList.get(i).getStuCode().equals(curStudentId)) {
				studentList.remove(studentList.get(i));
			}
		}
		return true;
	}
	public static Student selectOneStudent(String id) {
		// TODO Auto-generated method stub
		for (int i = 0; i < studentList.size(); i++) {
			if (studentList.get(i).getStuCode().equals(id)) {
				return studentList.get(i);
			}
		}
		return null;
	}
	
}
