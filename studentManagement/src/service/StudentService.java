package service;

import java.util.List;

import model.ClassModel;
import model.Student;

public interface StudentService {

	// 获取全部学生信息
	public List<Student> getAllStudent();

	// 新增学生信息
	public boolean addNewStudent(Student curInfo);

	// 新增学生信息
	public boolean updateStudent(Student curInfo);

	// 删除学生信息
	public boolean deleteStudent(String curId);

	// 获取单个学生的信息
	public Student getOneStudent(String studentId);

	public List<ClassModel> getAllClass();

	public String getOneClassById(int id);

}
