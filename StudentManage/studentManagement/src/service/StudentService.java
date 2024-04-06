package service;

import java.util.List;

import model.ClassModel;
import model.Student;

public interface StudentService {

	// ��ȡȫ��ѧ����Ϣ
	public List<Student> getAllStudent();

	// ����ѧ����Ϣ
	public boolean addNewStudent(Student curInfo);

	// ����ѧ����Ϣ
	public boolean updateStudent(Student curInfo);

	// ɾ��ѧ����Ϣ
	public boolean deleteStudent(String curId);

	// ��ȡ����ѧ������Ϣ
	public Student getOneStudent(String studentId);

	public List<ClassModel> getAllClass();

	public String getOneClassById(int id);

}
