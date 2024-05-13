package com.service;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

import com.model.Student;

public class StudentService {
	private static final String URL = "jdbc:mysql://110.40.171.227:3306/studentmanage";
	private static final String USER = "root";
	private static final String PASSWORD = "root";
	private static final String INSERT_STUDENT_SQL = "INSERT INTO Student (stuCode, stuName, age, sex, belongClass, belongClassName, telephone, address) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
    private static final String SELECT_ALL_CLASSES_SQL = "SELECT * FROM Student";
    private static final String UPDATE_STUDENT_SQL = "UPDATE Student SET stuName = ?, age = ?, sex = ?, belongClass = ?, belongClassName = ?, telephone = ?, address = ? WHERE stuCode = ?";
    private static final String DELETE_STUDENT_SQL = "DELETE FROM Student WHERE stuCode = ?";

	static List<Student> students = new ArrayList<>();

	public static List<Student> getAllStudents() {
		try {
			java.lang.Class.forName("com.mysql.cj.jdbc.Driver");
			Connection conn = DriverManager.getConnection(URL, USER, PASSWORD);
			PreparedStatement stmt = conn.prepareStatement(SELECT_ALL_CLASSES_SQL);
			ResultSet rs = stmt.executeQuery();
			students.clear();
			while (rs.next()) {
				Student student = new Student();
				student.setStuCode(rs.getString("stuCode"));
				student.setStuName(rs.getString("stuName"));
				student.setAge(rs.getInt("age"));
				student.setSex(rs.getInt("sex"));
				student.setBelongClass(rs.getInt("belongClass"));
				student.setBelongClassName(rs.getString("belongClassName"));
				student.setTelephone(rs.getString("telephone"));
				student.setAddress(rs.getString("address"));
				students.add(student);
			}
			rs.close();
			stmt.close();
			conn.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return students;
	}

	public static boolean insertStudent(Student student) {
		try {
			
            java.lang.Class.forName("com.mysql.cj.jdbc.Driver");
			Connection conn = DriverManager.getConnection(URL, USER, PASSWORD);
			PreparedStatement stmt = conn.prepareStatement(INSERT_STUDENT_SQL);
			stmt.setString(1, student.getStuCode());
			stmt.setString(2, student.getStuName());
			stmt.setInt(3, student.getAge());
			stmt.setInt(4, student.getSex());
			stmt.setInt(5, student.getBelongClass());
			stmt.setString(6, student.getBelongClassName());
			stmt.setString(7, student.getTelephone());
			stmt.setString(8, student.getAddress());
			int rowsInserted = stmt.executeUpdate();
			stmt.close();
			conn.close();
			return rowsInserted > 0;
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
	}

	public static boolean updateStudent(Student student) {
		try {
			java.lang.Class.forName("com.mysql.cj.jdbc.Driver");
			Connection conn = DriverManager.getConnection(URL, USER, PASSWORD);
			PreparedStatement stmt = conn.prepareStatement(UPDATE_STUDENT_SQL);
			stmt.setString(1, student.getStuName());
			stmt.setInt(2, student.getAge());
			stmt.setInt(3, student.getSex());
			stmt.setInt(4, student.getBelongClass());
			stmt.setString(5, student.getBelongClassName());
			stmt.setString(6, student.getTelephone());
			stmt.setString(7, student.getAddress());
			stmt.setString(8, student.getStuCode());
			int rowsUpdated = stmt.executeUpdate();
			stmt.close();
			conn.close();
			return rowsUpdated > 0;
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
	}

	public static boolean deleteStudent(String stuCode) {
		try {
			java.lang.Class.forName("com.mysql.cj.jdbc.Driver");
			Connection conn = DriverManager.getConnection(URL, USER, PASSWORD);
			PreparedStatement stmt = conn.prepareStatement(DELETE_STUDENT_SQL);
			stmt.setString(1, stuCode);
			int rowsDeleted = stmt.executeUpdate();
			stmt.close();
			conn.close();
			return rowsDeleted > 0;
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
	}

	public static Student selectOneStudent(String id) {
		for (int i = 0; i < students.size(); i++) {
			if (students.get(i).getStuCode().equals(id)) {
				return students.get(i);
			}
		}
		return null;
	}
}
