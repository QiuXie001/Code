package service.impl;

import java.util.List;

import dao.ClassDao;
import dao.StudentDao;
import dao.impl.ClassDaoImpl;
import dao.impl.StudentDaoImp;
import model.ClassModel;
import model.Student;
import service.StudentService;

public class StudentServiceImpl implements StudentService {

	StudentDao dao = new StudentDaoImp();
	ClassDao daoClass = new ClassDaoImpl();

	@Override
	public List<Student> getAllStudent() {
		// TODO Auto-generated method stub
		return dao.selectAllStudent();
	}

	@Override
	public boolean addNewStudent(Student curInfo) {
		// TODO Auto-generated method stub
		return dao.insertStudentInfo(curInfo);
	}

	@Override
	public boolean updateStudent(Student curInfo) {
		// TODO Auto-generated method stub
		return dao.updateStudentInfo(curInfo);
	}

	@Override
	public boolean deleteStudent(String curId) {
		// TODO Auto-generated method stub
		return dao.deleteStudentInfo(curId);
	}

	@Override
	public Student getOneStudent(String studentId) {
		// TODO Auto-generated method stub
		return dao.selectOneStudent(studentId);
	}

	@Override
	public List<ClassModel> getAllClass() {
		// TODO Auto-generated method stub
		return daoClass.getAllClass();
	}

	@Override
	public String getOneClassById(int id) {
		// TODO Auto-generated method stub
		return daoClass.getClassNameByClassId(id);
	}

}
