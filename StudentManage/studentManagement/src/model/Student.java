package model;

import java.util.Date;

public class Student {

	private String stuCode; // ѧ��
	private String stuName; // ����
	private int age; // ����
	private int sex; // �Ա� 0���У�1��Ů
	private Date birthday;// ��������
	private int belongClass;// �����༶
	private String belongClassName;// �����༶

	public String getStuCode() {
		return stuCode;
	}

	public void setStuCode(String stuCode) {
		this.stuCode = stuCode;
	}

	public String getStuName() {
		return stuName;
	}

	public void setStuName(String stuName) {
		this.stuName = stuName;
	}

	public int getAge() {
		return age;
	}

	public void setAge(int age) {
		this.age = age;
	}

	public int getSex() {
		return sex;
	}

	public void setSex(int sex) {
		this.sex = sex;
	}

	public Date getBirthday() {
		return birthday;
	}

	public void setBirthday(Date birthday) {
		this.birthday = birthday;
	}

	public int getBelongClass() {
		return belongClass;
	}

	public void setBelongClass(int belongClass) {
		this.belongClass = belongClass;
	}

	public String getBelongClassName() {
		return belongClassName;
	}

	public void setBelongClassName(String belongClassName) {
		this.belongClassName = belongClassName;
	}

}
