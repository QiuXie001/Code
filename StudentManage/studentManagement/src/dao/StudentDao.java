package dao;

import java.util.List;

import model.Student;

public interface StudentDao {

	// ��ȡ����ѧ����Ϣ
	public List<Student> selectAllStudent();

	// ����һ��ѧ����Ϣ
	public boolean insertStudentInfo(Student curStudent);

	// �޸�һ��ѧ����Ϣ
	public boolean updateStudentInfo(Student curStudent);

	// ɾ��һ��ѧ����Ϣ
	public boolean deleteStudentInfo(String curStudentId);

	// ����Id��ȡһ��ѧ����Ϣ
	public Student selectOneStudent(String id);
}
