package dao.impl;

import java.lang.reflect.InvocationTargetException;
import java.text.SimpleDateFormat;
import java.util.*;

import org.apache.commons.beanutils.BeanUtils;

import dao.StudentDao;
import model.Student;

public class StudentDaoImp implements StudentDao {

	// 创建集合，模拟数据库中的数据
	public static List<Student> studentList = new ArrayList<Student>();
	static {
		try {
			Student tmp1 = new Student();
			Map<String, Object> curInfo1 = new HashMap<String, Object>();
			curInfo1.put("stuCode", "10001");
			curInfo1.put("stuName", "王小亮");
			curInfo1.put("age", 19);
			curInfo1.put("sex", 1); // 0表示男，1表示女
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
			curInfo1.put("birthday", sdf.parse("2004-11-11"));
			curInfo1.put("belongClass", 8);
			curInfo1.put("belongClassName", "8班");

			Student tmp2 = new Student();
			Map<String, Object> curInfo2 = new HashMap<String, Object>();
			curInfo2.put("stuCode", "10002");
			curInfo2.put("stuName", "李小明");
			curInfo2.put("age", 20);
			curInfo2.put("sex", 0); // 0表示男，1表示女
			curInfo2.put("birthday", sdf.parse("2004-03-11"));
			curInfo2.put("belongClass", 2);
			curInfo2.put("belongClassName", "2班");

			BeanUtils.populate(tmp1, curInfo1);
			BeanUtils.populate(tmp2, curInfo2);

			studentList.add(tmp1);
			studentList.add(tmp2);
		} catch (Exception e) {
			e.printStackTrace();
		}

		/*
		 * //批量生成信息 for(int i=0;i<20;i++) { Student tmp = new Student();
		 * tmp.setStuCode(Integer.toString(10000+i)); tmp.setStuName("xuesheng" +
		 * Integer.toString(10000+i)); tmp.setAge(22); tmp.setSex(1);
		 * studentList.add(tmp); }
		 */
	}

	@Override
	public List<Student> selectAllStudent() {

		// TODO Auto-generated method stub
		return studentList;
	}

	@Override
	public boolean insertStudentInfo(Student curStudent) {
		// TODO Auto-generated method stub
		studentList.add(curStudent);
		return true;
	}

	@Override
	public boolean updateStudentInfo(Student curStudent) {
		// TODO Auto-generated method stub
		for (int i = 0; i < studentList.size(); i++) {
			if (studentList.get(i).getStuCode().equals(curStudent.getStuCode())) {
				studentList.remove(studentList.get(i));
				studentList.add(curStudent);
			}
		}
		return true;
	}

	@Override
	public boolean deleteStudentInfo(String curStudentId) {
		// TODO Auto-generated method stub

		for (int i = 0; i < studentList.size(); i++) {
			if (studentList.get(i).getStuCode().equals(curStudentId)) {
				studentList.remove(studentList.get(i));
			}
		}
		return true;
	}

	@Override
	public Student selectOneStudent(String id) {
		// TODO Auto-generated method stub
		for (int i = 0; i < studentList.size(); i++) {
			if (studentList.get(i).getStuCode().equals(id)) {
				return studentList.get(i);
			}
		}
		return null;
	}

}
