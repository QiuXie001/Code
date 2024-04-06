package dao;

import java.util.List;

import model.Student;

public interface StudentDao {

	// 提取所有学生信息
	public List<Student> selectAllStudent();

	// 增加一条学生信息
	public boolean insertStudentInfo(Student curStudent);

	// 修改一条学生信息
	public boolean updateStudentInfo(Student curStudent);

	// 删除一条学生信息
	public boolean deleteStudentInfo(String curStudentId);

	// 根据Id提取一条学生信息
	public Student selectOneStudent(String id);
}
